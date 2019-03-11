using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeaponHolder {

    [SerializeField]Transform weaponOwnerPos;
    [SerializeField]string defaultWeaponId = "normal";

    IWeapon activeWeapon;
    Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start () {
        InstantiateWeapon();
        SetActiveWeapon(defaultWeaponId);
	}
    
    public void SetActiveWeapon(string weaponId)
    {
        if(weapons.ContainsKey(weaponId))
        {
            activeWeapon = weapons[weaponId].GetComponent<IWeapon>();
            activeWeapon.OwnerPos = weaponOwnerPos;
            weapons[weaponId].SetActive(true);
        }
    }
    
    public void Shoot()
    {
        activeWeapon.Shoot();
        SetActiveWeapon("normal");
    }

    public void InstantiateWeapon()
    {
        for (int i = 0; i < GameData.Instance.weaponPrefabs.Count; i++)
        {
            var weapon = Instantiate(GameData.Instance.weaponPrefabs[i], this.transform);
            var Iweapon = weapon.GetComponent<IWeapon>();
            weapon.tag = this.gameObject.tag;
            weapon.SetActive(false);
            weapons.Add(Iweapon.WeaponId, weapon);
        }
    }
}
