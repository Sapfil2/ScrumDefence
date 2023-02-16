using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpdater : MonoBehaviour
{
    public float health;
    public Healthbar healthbar;
    private float maxHealth;
    public GameObject nextObjectFormPrefab;

    private void Start()
    {
        maxHealth = health;
    }

    public void Hit(float hitPower)
    {
        health -= hitPower;
        if (health > 0)
        {
            healthbar.UpdateHealth(maxHealth, health);
        }
        else 
        {
            if (nextObjectFormPrefab != null)
            {
                PathFollow go = Instantiate(nextObjectFormPrefab).GetComponent<PathFollow>();
                go.transform.position = transform.position;
                go.SetParametersFromPrevForm(GetComponent<PathFollow>());
            }
            Destroy(gameObject);
        }
    }
}
