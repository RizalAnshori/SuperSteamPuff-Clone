using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    string WeaponId { get;}
    string WeaponOwner { set; }
    void Shoot();
}
