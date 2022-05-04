using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is Null");
            }

            return _instance;
        }
    }

    public bool hasCastleKey { get; set; }
    public bool hasFlameSword { get; set; }
    public bool hasBootsOfFlight { get; set; }

    private void Awake()
    {
        _instance = this;
    }
}
