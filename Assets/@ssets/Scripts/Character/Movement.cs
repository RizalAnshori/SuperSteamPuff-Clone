using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField,Tooltip("Used for Dash, if it's Enemy set the value in negative")]
    float dashLenght = 1.5f;
    [SerializeField]
    float forcePower;
    [SerializeField]
    float velocity;
    Rigidbody2D rigidBody;

    bool isInFront;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveUp()
    {
        //rigidBody.AddForce(transform.up * forcePower*Time.deltaTime, ForceMode2D.Force);
        rigidBody.AddForce(new Vector2(0, forcePower));
        if (rigidBody.velocity.y > velocity)
        {
            rigidBody.velocity = new Vector2(0, velocity);
        }
    }

    public void Dash()
    {
        if(!isInFront)
        {
            transform.position = new Vector2(transform.position.x + dashLenght, transform.position.y);
            isInFront = true;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - dashLenght, transform.position.y);
            isInFront = false;
        }
    }
}
