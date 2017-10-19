using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour {

    public PowerUpCoreModel powerUpCore;

    PowerUpModel model;

    // Use this for initialization
    void Start () {
        model = GetComponent<PowerUpModel>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            powerUpCore.target = model.target;
            GameObject powerUpCoreGameObject = (GameObject)Instantiate(powerUpCore.gameObject,this.transform.position,Quaternion.identity);
            //powerUpCoreGameObject.GetComponent<PowerUpCoreModel>().target = GetComponent<PowerUpModel>().target;
            this.gameObject.SetActive(false);
        }
    }
}
