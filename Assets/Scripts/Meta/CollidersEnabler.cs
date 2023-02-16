using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersEnabler : MonoBehaviour
{
    public static CollidersEnabler Instance { get; private set; }
    private List<Collider2D> list;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        list = new List<Collider2D>();
    }

    public void AddCollider(Collider2D collider)
    {
        list.Add(collider);
    }

    public void RemoveCollider(Collider2D collider)
    {
        list.Remove(collider);
    }

    public void DisableAll()
    {
        foreach (Collider2D c in list)
        {
            c.enabled = false;
        }
    }

    public void EnableAll()
    {
        foreach (Collider2D c in list)
        {
            c.enabled = true;
        }
    }
}
