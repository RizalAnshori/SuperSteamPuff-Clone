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
        if (other.gameObject.layer == 8)
        {
            //Physics2D.IgnoreLayerCollision(8, 8, true);
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        
        if(other.gameObject.GetComponent<BulletModel>().owner == "Player")
        {

        }
    }
}
