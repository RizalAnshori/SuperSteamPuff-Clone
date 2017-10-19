using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChanger : MonoBehaviour {

    [SerializeField]PowerUpModel model;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField]float delayChangeType;

    private float timer;

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        if(isChangeTime())
        {
            ChangeType();
            timer = delayChangeType;
        }
    }

    void Init()
    {
        timer = delayChangeType;
        ChangeType();
    }

    void ChangeType()
    {
        int index = (Random.Range(0, GameData.Instance.powerUpData.Count*10)) % GameData.Instance.powerUpData.Count ;
        spriteRenderer.sprite = GameData.Instance.powerUpData[index].sprite;
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
