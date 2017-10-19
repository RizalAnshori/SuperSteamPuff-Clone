using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : MonoBehaviour,IWeapon {

    public Transform weaponOwnerPos;

    [SerializeField]string weaponId;
    [SerializeField]GameObject spreadBullet;
    [SerializeField]Transform[] bulletSpawnPosition;

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

    public void Shoot()
    {
        //Spread();
        for (int i = 0; i < bulletSpawnPosition.Length; i++)
        {
            GameObject bulletObj = GetPooledBullet();
            if (bulletObj != null)
            {
                bulletObj.transform.position = bulletSpawnPosition[i].position;
                bulletObj.transform.rotation = bulletSpawnPosition[i].rotation;
                bulletObj.GetComponent<BulletModel>().owner = weaponOwnerPos;
                bulletObj.SetActive(true);
            }
            else
            {
                GameObject newBulletObj = (GameObject)Instantiate(spreadBullet, bulletSpawnPosition[i].position, bulletSpawnPosition[i].rotation);
                newBulletObj.GetComponent<BulletModel>().owner = weaponOwnerPos;
                bulletPool.Add(newBulletObj);
            }
        }
    }

    void Spread()
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
