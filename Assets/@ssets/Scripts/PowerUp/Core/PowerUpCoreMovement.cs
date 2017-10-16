using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoreMovement : MonoBehaviour {

    PowerUpCoreModel model;
    Rigidbody2D rb;

    float speed = 15f;
    float turningSpeed = 7.5f;
    public bool isClockWise;

    // Use this for initialization
    void Start () {
        model = GetComponent<PowerUpCoreModel>();
        rb = GetComponent<Rigidbody2D>();
        if (transform.localPosition.y < 0)
        {
            //isClockWise = false;
            transform.Rotate(0, 0, 0);
        }
        else
        {
            //isClockWise = true;
            transform.Rotate(0, 0, 180);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement2();
	}

    void Movement()
    {
        Vector2 pointToTarget = (Vector2)transform.position - (Vector2)model.target.transform.position;

        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.right).z;

        rb.angularVelocity = 700 * value;

        rb.velocity = transform.right * 7;
    }

    void Movement2()
    {
        Vector3 target = model.target.position;
        Vector3 distance = target - transform.position;

        var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
        //if(isClockWise)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.back)), turningSpeed * Time.deltaTime);
        //}
        //else
        //{
        //}
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), turningSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
