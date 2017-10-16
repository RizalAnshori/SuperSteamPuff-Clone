using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoreInteraction : MonoBehaviour {

    PowerUpCoreModel model;

    void Start()
    {
        model = GetComponent<PowerUpCoreModel>();
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            var weapon = other.gameObject.GetComponentInChildren<PlayerWeapon>();
            weapon.SetActiveWeapon(model.type);
            this.gameObject.SetActive(false);
        }
    }
}
