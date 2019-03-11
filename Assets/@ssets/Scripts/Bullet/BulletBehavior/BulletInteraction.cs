using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : MonoBehaviour, IDamageable {

    public BulletModel model;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            if(other.gameObject.GetComponent<PowerUpModel>() != null)
            {
                var powerUpModel = other.gameObject.GetComponent<PowerUpModel>();
                powerUpModel.target = GetComponent<BulletModel>().owner;
            }
            else
            {
                Debug.Log("Null");
            }
        }
        else
        {
            other.gameObject.GetComponent<IDamageable>().Damage(model.Damage,this.gameObject);
            //Debug.Log(other.gameObject.name);
        }
    }

    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    public void Damage(int _DamageAmount, GameObject _DamageSender)
    {
        this.gameObject.SetActive(false);
    }
}
