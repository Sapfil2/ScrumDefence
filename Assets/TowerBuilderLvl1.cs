using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderLvl1 : AbstractTowerBuilder
{
    public static TowerBuilderLvl1 Instance { get; private set; }
    public GameObject towerPrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public override void EnableBuilder(PlaceTower placeTower) 
    {
        placeTower.Build(towerPrefab);
    }

    public override void TowerChosen(GameObject towerPrefab)
    { 
        // do nothing
    }
}
