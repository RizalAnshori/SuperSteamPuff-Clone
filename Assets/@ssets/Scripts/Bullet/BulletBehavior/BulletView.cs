using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour {

    [SerializeField]
    TrailRenderer trailRenderer;

    void OnEnable()
    {
        trailRenderer.enabled = true;
    }

    void OnDisable()
    {
        trailRenderer.enabled = false;
        trailRenderer.Clear();
        Debug.Log("False");
    }
    
	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
