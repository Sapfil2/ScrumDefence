using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderCall : MonoBehaviour
{
    public static TowerBuilder towerBuilder;

    public GameObject towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        towerBuilder = TowerBuilder.Instance;
    }

    private void OnMouseUp()
    {
        towerBuilder.TowerChosen(towerPrefab);
    }
}
