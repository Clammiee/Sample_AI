
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox Instance { get; private set; }
    private LevelManager levelManager;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else Destroy(gameObject);

        var go1 = new GameObject("LevelManager");
        go1.transform.parent = this.gameObject.transform;
        this.levelManager = go1.AddComponent<LevelManager>();
    }

    public LevelManager GetLevelManager()
    {
        return this.levelManager;
    }
}