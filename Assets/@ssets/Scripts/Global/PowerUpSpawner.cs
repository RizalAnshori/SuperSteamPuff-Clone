using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]float delaySpawn;
    [SerializeField]float offsetSpawn;
    [SerializeField]GameObject powerUpPrefab;
    [SerializeField]Transform yOffsetSpawn;

    private float timer;
    private List<GameObject> powerUpPool = new List<GameObject>();

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		if(isSpawnTime())
        {
            SpawnPowerUp();
            timer = delaySpawn;
        }
	}

    void Init()
    {
        timer = delaySpawn;
        SpawnPowerUp();
    }

    void SpawnPowerUp()
    {
        GameObject powerUpObj = GetPooledPowerUp();
        if(powerUpObj != null)
        {
            powerUpObj.transform.position = SpawnPosisiton();
            powerUpObj.transform.rotation = this.transform.rotation;
            powerUpObj.SetActive(true);
        }
        else
        {
            GameObject newPowerUpObj = (GameObject)Instantiate(powerUpPrefab, SpawnPosisiton(), Quaternion.identity);
            newPowerUpObj.transform.SetParent(this.transform, true);
            powerUpPool.Add(newPowerUpObj);
        }
    }

    bool isSpawnTime()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            return true;
        }
        return false;
    }

    Vector3 SpawnPosisiton()
    {
        Vector3 temp = new Vector3(0,0,0);

        temp.x = Random.Range(0 - offsetSpawn, 0 + offsetSpawn);
        var seed = Random.Range(1, 30);
        if(seed % 2 == 0)
        {
            temp.y = yOffsetSpawn.position.y;
        }
        else
        {
            temp.y = yOffsetSpawn.position.y * -1;
        }

        return temp;
    }

    GameObject GetPooledPowerUp()
    {
        for(int i = 0; i<powerUpPool.Count; i++)
        {
            if(!powerUpPool[i].gameObject.activeSelf)
            {
                return powerUpPool[i].gameObject;
            }
        }
        return null;
    }
}
