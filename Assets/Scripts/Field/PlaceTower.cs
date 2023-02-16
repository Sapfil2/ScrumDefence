using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject[] towerPrefab;
    private GameObject tower;
    public List<PlaceTower> neighbours = new List<PlaceTower>();
    private Collider2D collider2D;
    private Vector2 colliderOffset;

    private void Start()
    {
        collider2D = gameObject.GetComponent<Collider2D>();
        colliderOffset = collider2D.offset;
        CollidersEnabler.Instance.AddCollider(collider2D);
    }

    public void addNeighbour(PlaceTower neighbour)
    {
        neighbours.Add(neighbour);
    }

    private void OnMouseUp()
    {
        if (tower == null)
        {
            TowerBuilder.Instance.EnableBuilder(this);
        }
    }

    public void Build(GameObject towerPrefab)
    {
        GameObject t = Instantiate(towerPrefab);
        t.transform.position = transform.position;
        t.transform.Translate(new Vector3(colliderOffset.x, colliderOffset.y));
        tower = t;
        CollidersEnabler.Instance.RemoveCollider(collider2D);
        foreach (PlaceTower pt in neighbours)
        {
            pt.tower = t;
            CollidersEnabler.Instance.RemoveCollider(pt.GetComponent<Collider2D>());
        }
    }
}
