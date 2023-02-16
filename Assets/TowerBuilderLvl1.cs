using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderLvl1 : TowerBuilder
{
    public static TowerBuilderLvl1 Instance { get; private set; }
    public GameObject towerPrefab;
    
    private void Start()
    {
        builderMask.SetActive(false);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        TowerBuilder.Instance = this;
    }

    public void EnableBuilder(PlaceTower placeTower) 
    {
        placeTower.Build(towerPrefab);
    }
}
