using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoreMovement : MonoBehaviour {

    PowerUpCoreModel model;
    Rigidbody2D rb;

    float speed = 15f;
    float turningSpeed = 7.5f;

    // Use this for initialization
    void Start () {
        model = GetComponent<PowerUpCoreModel>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement();
	}

    void Movement()
    {
        Vector2 pointToTarget = (Vector2)transform.position - (Vector2)model.target.transform.position;

        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.right).z;

        rb.angularVelocity = 750 * value;

        rb.velocity = transform.right * 10;
    }

    //void Movement2()
    //{
    //    Vector3 target = model.target.position;
    //    Vector3 distance = target - transform.position;

    //    var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
    //    transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), turningSpeed * Time.deltaTime);

    //    transform.Translate(Vector3.up * speed * Time.deltaTime);
    //}
}
