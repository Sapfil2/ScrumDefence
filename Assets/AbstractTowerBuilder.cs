using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTowerBuilder : MonoBehaviour
{
    public abstract void EnableBuilder(PlaceTower placeTower);
    public abstract void TowerChosen(GameObject towerPrefab);
}
