using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    float dashLenght;
    [SerializeField]
    float forcePower;
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
        //rigidBody.AddForce(transform.up * forcePower*Time.deltaTime, ForceMode2D.Impulse);
        rigidBody.AddForce(new Vector2(0, forcePower));
        rigidBody.velocity = new Vector2(0, 5);
        Debug.Log("velocity : "+rigidBody.velocity);
    }

    public void Dash()
    {
        if(!isInFront)
        {
            transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y);
            isInFront = true;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 1.5f, transform.position.y);
            isInFront = false;
        }
    }
}
