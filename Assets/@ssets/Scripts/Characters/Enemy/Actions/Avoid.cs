using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBT;

public partial class EnemyInput {
    ReturnValue Avoid()
    {
        if(bullet!=null)
        {
            AvoidUp();
            AvoidForward();
            UseWeapon();
            ChangeState();
        }
        return ReturnValue.Running;
    }
    public int bulletSaveOffset;
    GameObject bullet;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != this.gameObject.tag && col.tag != "Untagged")
        {
            bullet = col.gameObject;
            behaviorTreeParent = avoid;
            Debug.Log("Change State to Avoid");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == bullet)
        {
            behaviorTreeParent = movement;
        }
    }
    
    void AvoidUp()
    {
        if (transform.position.y < 0)
        {
            movementScript.MoveUp();
        }
    }

    void AvoidForward()
    {
        if (bullet.transform.position.x > transform.position.x - 0.5f)
        {
            movementScript.Dash();
            Debug.Log("Bullet in Range");
        }
    }

    void ChangeState()
    {
        if(bullet.transform.position.x > transform.position.x + bulletSaveOffset || !bullet.activeSelf)
        {
            behaviorTreeParent = movement;
            Debug.Log("ChangeState");
        }
    }
}
