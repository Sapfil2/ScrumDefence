using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderImplementation : MonoBehaviour
{
    public static TowerBuilderImplementation Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public AbstractTowerBuilder builderImpl;
}
