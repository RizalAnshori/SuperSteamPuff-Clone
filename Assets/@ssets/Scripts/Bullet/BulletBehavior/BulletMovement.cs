using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float bulletSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
	}
}
