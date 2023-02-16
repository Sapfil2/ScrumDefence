using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderCall : MonoBehaviour
{
    public static AbstractTowerBuilder towerBuilder;

    public GameObject towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        towerBuilder = TowerBuilderImplementation.Instance.builderImpl;
    }

    private void OnMouseUp()
    {
        towerBuilder.TowerChosen(towerPrefab);
    }
}
