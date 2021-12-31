using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWeapon : MonoBehaviour, IWeapon
{
    public Transform weaponOwnerPos;

    [SerializeField]string weaponId;
    [SerializeField]GameObject burstBullet;
    [SerializeField]Transform bulletSpawnPosition;
    [SerializeField]float burstSpeed;
    [SerializeField]int bulletAmount;

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
        timer = burstSpeed;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        StartCoroutine(Burst());
    }

    IEnumerator Burst()
    {
        for(int i = 0; i<bulletAmount;i++)
        {
            GameObject bulletObj = GetPooledBullet();
            if(bulletObj!=null)
            {
                bulletObj.transform.position = bulletSpawnPosition.position;
                bulletObj.transform.rotation = bulletSpawnPosition.rotation;
                bulletObj.GetComponent<BulletModel>().owner = weaponOwnerPos;
                bulletObj.tag = this.gameObject.tag;
                bulletObj.SetActive(true);
            }
            else
            {
                GameObject newBulletObj = (GameObject)Instantiate(burstBullet, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                newBulletObj.tag = this.gameObject.tag;
                bulletPool.Add(newBulletObj);
            }
            yield return new WaitForSeconds(burstSpeed);
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
