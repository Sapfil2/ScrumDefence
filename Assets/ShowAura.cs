using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAura : MonoBehaviour
{
    public GameObject aura;

    private void OnMouseOver()
    {
        Debug.Log("On mouse over");
        aura.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("On mouse exit");
        aura.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        aura.SetActive(false);
        CollidersEnabler.Instance.AddCollider(GetComponent<Collider2D>());
    }
}
