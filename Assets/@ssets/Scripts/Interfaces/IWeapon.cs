using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    string WeaponId { get;}
    Transform OwnerPos { get; set; }
    void Shoot();
}
