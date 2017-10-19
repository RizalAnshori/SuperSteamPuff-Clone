using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour {

    public float powerUpSpeed;

	// Use this for initialization
	void Start () {
        if(transform.position.y < 0)
        {
            powerUpSpeed *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.Translate(Vector3.down * powerUpSpeed * Time.deltaTime);
    }
}
