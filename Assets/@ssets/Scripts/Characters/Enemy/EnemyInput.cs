using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBT;

public partial class EnemyInput : MonoBehaviour {

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
        behaviorTreeParent.Activity();
    }
}
