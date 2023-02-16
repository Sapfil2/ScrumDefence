using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderLvl2 : AbstractTowerBuilder
{
    public static TowerBuilderLvl2 Instance { get; private set; }
    public static CollidersEnabler collidersEnabler;
    public GameObject builderMask;

    private PlaceTower currentPlaceTower;

    private void Start()
    {
        collidersEnabler = CollidersEnabler.Instance;
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
    }

    public override void EnableBuilder(PlaceTower placeTower) 
    {
        Time.timeScale = 0.1f;
        currentPlaceTower = placeTower;
        collidersEnabler.DisableAll();
        builderMask.SetActive(true);
    }

    public override void TowerChosen(GameObject towerPrefab)
    {
        Time.timeScale = 1.0f;
        currentPlaceTower.Build(towerPrefab);
        collidersEnabler.EnableAll();
        builderMask.SetActive(false);
    }
}
