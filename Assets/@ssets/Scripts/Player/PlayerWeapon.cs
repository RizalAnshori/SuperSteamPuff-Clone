using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public Transform weaponOwnerPos;
    public IWeapon activeWeapon;
    //public List<IWeapon> weapons = new List<IWeapon>();
    //GameObject weapon = weapons[i] as GameObject;
    public string defaultWeaponId = "normal";

    //List<GameObject> weapons = new List<GameObject>();
    Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();

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
        for(int i = 0; i< GameData.Instance.weaponPrefabs.Count; i++)
        {
            var weapon = Instantiate(GameData.Instance.weaponPrefabs[i], this.transform);
            var Iweapon = weapon.GetComponent<IWeapon>();
            //weapon.GetComponent<IWeapon>().OwnerPos = weaponOwnerPos;
            weapon.SetActive(false);
            weapons.Add(Iweapon.WeaponId, weapon);
        }
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
        //SetActiveWeapon("normal");
    }
}
