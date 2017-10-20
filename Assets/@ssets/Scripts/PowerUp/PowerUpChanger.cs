using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChanger : MonoBehaviour {

    [SerializeField]PowerUpModel model;

    private float timer;

    // Use this for initialization
    void OnEnable () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        if(isChangeTime() && !model.isHit)
        {
            ChangeType();
            timer = model.delayChangeType;
        }
    }

    void Init()
    {
        timer = model.delayChangeType;
        ChangeType();
    }

    void ChangeType()
    {
        int index = (Random.Range(0, GameData.Instance.powerUpData.Count*100)) % GameData.Instance.powerUpData.Count ;
        model.spriteRenderer.sprite = GameData.Instance.powerUpData[index].sprite;
        model.powerUpType = GameData.Instance.powerUpData[index].type;
    }

    bool isChangeTime()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            return true;
        }
        return false;
    }
}
