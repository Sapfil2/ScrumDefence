using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prod : MonoBehaviour
{
    public static Prod Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public string victoryTag;
    public int victoryPoints;
    public TMP_Text textContainer;
    private int currentPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
        UpdateText();
    }

    public void TaskReachedProd(GameObject task)
    {
        if (task.CompareTag(victoryTag))
        {
            currentPoints++;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        textContainer.text = "" + currentPoints + " / " + victoryPoints;
    }
}
