using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour {

    [SerializeField]PowerUpModel model;

    float _floatingSpeed;

    void OnEnable()
    {
        DetectInitialPosition();
    }

	// Update is called once per frame
	void Update () {
        Move();
	}

    void DetectInitialPosition()
    {
        if (transform.position.y < 0)
        {
            _floatingSpeed = model.floatingSpeed * -1;
        }
        else
        {
            _floatingSpeed = model.floatingSpeed;
        }
    }

    void Move()
    {
        if(model.isHit)
        {
            ChasingMove();
        }
        else
        {
            FloatingMove();
        }
    }

    void FloatingMove()
    {
        transform.Translate(Vector3.down * _floatingSpeed * Time.deltaTime);
    }

    void ChasingMove()
    {
        Vector3 target = model.target.position;
        Vector3 dist = target - transform.position;

        var angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.AngleAxis(angle, Vector3.forward)), model.turningSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * model.chaseSpeed * Time.deltaTime);
    }
}
