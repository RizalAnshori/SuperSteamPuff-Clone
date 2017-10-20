using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour {

    [SerializeField]PowerUpModel model;

    // Use this for initialization
    void Start () {
        //model = GetComponent<PowerUpModel>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            model.isHit = true;
        }
        else if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInChildren<IWeaponHolder>().SetActiveWeapon(model.powerUpType);
            model.isHit = false;
            this.gameObject.SetActive(false);
        }
    }
}
