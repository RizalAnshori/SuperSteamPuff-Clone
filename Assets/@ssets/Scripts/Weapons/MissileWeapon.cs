using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : MonoBehaviour, IWeapon
{
    public Transform weaponOwnerPos;

    [SerializeField]string weaponId;
    [SerializeField]GameObject bullet;
    [SerializeField]Transform bulletSpawnPosition;
    [SerializeField]float coolDownTime;

    private float timer;
    private List<GameObject> bulletPool = new List<GameObject>();

    public string WeaponId
    {
        get
        {
            return weaponId;
        }
    }

    public Transform OwnerPos
    {
        get
        {
            return weaponOwnerPos;
        }
        set
        {
            weaponOwnerPos = value;
        }
    }

    void Start()
    {
        timer = coolDownTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject bulletObj = GetPooledBullet();
        if (bulletObj != null)
        {
            bulletObj.transform.position = bulletSpawnPosition.position;
            bulletObj.transform.rotation = bulletSpawnPosition.rotation;
            bulletObj.GetComponent<BulletModel>().owner = weaponOwnerPos;
            bulletObj.tag = this.gameObject.tag;
            bulletObj.SetActive(true);
        }
        else
        {
            GameObject newBulletObj = (GameObject)Instantiate(bullet, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            newBulletObj.GetComponent<BulletModel>().owner = weaponOwnerPos;
            newBulletObj.tag = this.gameObject.tag;
            bulletPool.Add(newBulletObj);
        }
    }

    GameObject GetPooledBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].gameObject.activeSelf)
            {
                return bulletPool[i].gameObject;
            }
        }
        return null;
    }
}
