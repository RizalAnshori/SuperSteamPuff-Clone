using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHolder {
    void InstantiateWeapon();
    void SetActiveWeapon(string weaponId);
    void Shoot();
}
