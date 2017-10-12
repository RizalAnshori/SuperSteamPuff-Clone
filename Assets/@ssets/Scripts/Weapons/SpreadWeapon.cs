using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : MonoBehaviour,IWeapon {

    [SerializeField]
    string weaponId;
    string weaponOwner;
    public GameObject bullet;
    public Transform[] bulletSpawnPosition;

    List<GameObject> bulletPool = new List<GameObject>();

    public string WeaponId
    {
        get
        {
            return weaponId;
        }
    }

    public string WeaponOwner
    {
        set
        {
            WeaponOwner = weaponOwner;
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < bulletSpawnPosition.Length; i++)
        {
            GameObject bulletObj = GetPooledBullet();
            if (bulletObj != null)
            {
                bulletObj.transform.position = bulletSpawnPosition[i].position;
                bulletObj.transform.rotation = bulletSpawnPosition[i].rotation;
                bulletObj.SetActive(true);
            }
            else
            {
                GameObject newBulletObj = (GameObject)Instantiate(bullet, bulletSpawnPosition[i].position, bulletSpawnPosition[i].rotation);
                bulletPool.Add(newBulletObj);
            }
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
