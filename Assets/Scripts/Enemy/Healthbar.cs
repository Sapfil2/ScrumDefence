using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image[] healthBarParts;

    public void UpdateHealth(float maxHealth, float currentHealth)
    {
        float percentage = currentHealth / maxHealth;
        if (percentage < 0)
        {
            percentage = 0;
        }
        foreach (Image i in healthBarParts)
        {
            i.fillAmount = percentage;
        }
    }
}
