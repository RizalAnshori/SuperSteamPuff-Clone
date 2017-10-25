using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour {

    [SerializeField]
    Movement movementScript;
    IWeaponHolder enemyWeapon;

    [SerializeField]
    Transform playerPos; //nanti taruh di GameData dan jadi static
    [SerializeField]
    float delayShot;
    [SerializeField]
    float offSet;

    private float shootTimer;

	// Use this for initialization
	void Start () {
        enemyWeapon = GetComponentInChildren<IWeaponHolder>();	
	}
	
	// Update is called once per frame
	void Update () {
        PoolInput();
	}

    void PoolInput()
    {
        UseJetpack();
        UseWeapon();
        UseDash();
    }

    void UseJetpack()
    {
        if(playerPos.position.y > transform.position.y)
        {
            movementScript.MoveUp();
        }
    }

    void UseWeapon()
    {
        if(isTimeToShoot() && isTargetInRange())
        {
            enemyWeapon.Shoot();
        }
    }

    bool isTargetInRange()
    {
        if(playerPos.position.y < transform.position.y + offSet && playerPos.position.y > transform.position.y - offSet)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool isTimeToShoot()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UseDash()
    {

    }
}
