using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteraction : MonoBehaviour {

    public GameObject powerUpCore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            var powerUpCoreGameObject = Instantiate(powerUpCore,this.transform.position,Quaternion.identity);
            powerUpCoreGameObject.GetComponent<PowerUpCoreModel>().target = GetComponent<PowerUpModel>().target;
            this.gameObject.SetActive(false);
        }
    }
}
