using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public string weaponOwner;
    public IWeapon activeWeapon;
    //public List<IWeapon> weapons = new List<IWeapon>();
    //GameObject weapon = weapons[i] as GameObject;
    public List<GameObject> weaponPrefabs = new List<GameObject>();

    List<GameObject> weapons = new List<GameObject>();
    string defaultWeaponId = "normal";

	// Use this for initialization
	void Start () {
        InstantiateWeapon();
        SetActiveWeapon(defaultWeaponId);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            defaultWeaponId = "normal";
            SetActiveWeapon(defaultWeaponId);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            defaultWeaponId = "spread";
            SetActiveWeapon(defaultWeaponId);
        }
	}

    void InstantiateWeapon()
    {
        for(int i = 0; i< weaponPrefabs.Count; i++)
        {
            var weapon = Instantiate(weaponPrefabs[i], this.transform);
            weapons.Add(weapon);
            weapon.SetActive(false);
        }
    }

    void SetActiveWeapon(string weaponId)
    {
        for(int i = 0; i< weapons.Count;i++)
        {
            var weapon = weapons[i].GetComponent<IWeapon>();
            if (weapon.WeaponId == weaponId)
            {
                weapon.WeaponOwner = weaponOwner;
                weapons[i].SetActive(true);
                activeWeapon = weapon;
            }
        }
    }
    
    public void Shoot()
    {
        activeWeapon.Shoot();
    }
}
