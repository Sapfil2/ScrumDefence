using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPreparer : MonoBehaviour
{
    private Transform[] pathPoints;
    public GameObject pathPointsObjectsParent;

    // Start is called before the first frame update
    void Start()
    {
        pathPoints = pathPointsObjectsParent.transform.GetComponentsInChildren<Transform>();
        System.Array.Sort(pathPoints, (a, b) => {
            return string.Compare(a.gameObject.name, b.gameObject.name);
        });
        foreach (Transform t in pathPoints)
        {
            t.position = new Vector3(t.position.x, t.position.y);
        }

        GetComponent<TaskCreator>().pathPoints = pathPoints;
    }
}
