using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IDamageable {
    PlayerModel model;

    // Use this for initialization
    void Start()
    {
        model = GetComponentInParent<PlayerModel>();
    }

    public void Damage(int _DamageAmount, GameObject _DamageSender)
    {
        if (_DamageSender.tag != this.gameObject.tag)
        {
            model.health = model.health - _DamageAmount;
            _DamageSender.SetActive(false);
        }
        //Debug.Log(_DamageSender.tag + _DamageSender.name);
    }
}
