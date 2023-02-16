using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    public float creationTimeMax;
    public float creationTimeMin;
    public GameObject bugPrefab;
    public GameObject taskPrefab;
    public Transform[] pathPoints;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = creationTimeMin;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = Random.Range(creationTimeMin, creationTimeMax) + timer;
            if (Random.Range(0.0f, 1.0f) > 0.7f)
            {
                Instantiate(bugPrefab).GetComponent<PathFollow>().SetPathPoints(pathPoints);
            }
            else 
            {
                Instantiate(taskPrefab).GetComponent<PathFollow>().SetPathPoints(pathPoints);
            }
        }     
    }
}
