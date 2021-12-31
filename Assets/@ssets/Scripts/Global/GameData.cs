using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    #region Singleton
    public static GameData Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<GameObject> weaponPrefabs = new List<GameObject>();
    public List<PowerUpData> powerUpData = new List<PowerUpData>();
}
