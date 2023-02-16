using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceFiller : MonoBehaviour
{
    public GameObject towerPlacePrefab;
    public GameObject[] fieldElementContainers;
    public int fieldSX = 17;
    public int fieldSY = 9;
    public int fieldXOffset = 8;
    public int fieldYOffset = 4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[,] fieldParts = new GameObject[fieldSX , fieldSY];

        foreach (GameObject container in fieldElementContainers)
        {
            for (int i = 0; i < container.transform.childCount; i++)
            {
                GameObject fieldPart = container.transform.GetChild(i).gameObject;
                int indexX = Mathf.RoundToInt(fieldPart.transform.position.x) + fieldXOffset;
                int indexY = Mathf.RoundToInt(fieldPart.transform.position.y) + fieldYOffset;
                fieldParts[indexX, indexY] = fieldPart;
            }
        }

        for (int i = 1; i < fieldParts.GetLength(0); i++)
        {
            for (int j = 0; j < fieldParts.GetLength(1)-1; j++)
            {
                if (   fieldParts[i    , j    ] != null
                    && fieldParts[i - 1, j    ] != null
                    && fieldParts[i    , j + 1] != null
                    && fieldParts[i - 1, j + 1] != null)
                {
                    // replacing passive plate by active tower-place-plate
                    GameObject tpp = Instantiate(towerPlacePrefab);
                    tpp.transform.position = fieldParts[i, j].transform.position;
                    Destroy(fieldParts[i, j]);
                    fieldParts[i, j] = tpp;
                    PlaceTower placeTower = tpp.GetComponent<PlaceTower>();

                    // linking neighbour plates
                    if (fieldParts[i - 1, j] != null
                        && fieldParts[i - 1, j].TryGetComponent(out PlaceTower neighbour1))
                    {
                        neighbour1.addNeighbour(placeTower);
                        placeTower.addNeighbour(neighbour1);
                    }

                    if (j > 0
                        && fieldParts[i, j - 1] != null
                        && fieldParts[i, j - 1].TryGetComponent(out PlaceTower neighbour2))
                    {
                        neighbour2.addNeighbour(placeTower);
                        placeTower.addNeighbour(neighbour2);
                    }
                }              
            }
        }
    }
}
