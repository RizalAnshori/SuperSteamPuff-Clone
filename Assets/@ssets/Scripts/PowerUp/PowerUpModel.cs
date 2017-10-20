using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModel : MonoBehaviour {

    [Tooltip("Common Variable that will used and modified by others")]
    [Header("Public Field")]
    public string powerUpType;
    public bool isHit;

    [Tooltip("Variable that used by PowerUpChanger Script")]
    [Header("Changer Field")]
    public SpriteRenderer spriteRenderer;
    public float delayChangeType;

    [Tooltip("Variable that used by PowerUpMovement Script")]
    [Header("Movement Field")]
    public Transform target;
    public float floatingSpeed;
    public float chaseSpeed;
    public float turningSpeed;
}
