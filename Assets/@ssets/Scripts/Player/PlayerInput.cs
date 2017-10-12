using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Movement movementScript;
    public PlayerWeapon playerWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        poolInput();
	}

    void poolInput()
    {
        var isPlayerShoot = Input.GetKeyDown(KeyCode.Space);
        var isPlayerAddForce = Input.GetMouseButton(0); //harusnya bisa ditahan buttonnya
        var isPlayerDash = Input.GetMouseButtonDown(1);

        if (isPlayerDash) movementScript.Dash();
        if (isPlayerAddForce) movementScript.MoveUp();
        if (isPlayerShoot) playerWeapon.Shoot();
    }
}
