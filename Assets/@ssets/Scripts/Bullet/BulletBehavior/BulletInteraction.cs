using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != GetComponent<BulletModel>().owner)
        gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
