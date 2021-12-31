using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateWeapon : MonoBehaviour, IWeapon
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
