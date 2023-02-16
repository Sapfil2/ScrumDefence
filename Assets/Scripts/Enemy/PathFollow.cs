using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public float speed;

    private Transform[] pathPoints;
    private int nextPoint;
    private Vector3 nextPositionVector;
    private float nextPositionTime;
    private float timer;

    public void SetParametersFromPrevForm(PathFollow prevForm)
    {
        this.pathPoints = prevForm.pathPoints;
        this.nextPoint = prevForm.nextPoint;
        this.nextPositionVector = prevForm.nextPositionVector;
        this.nextPositionTime = prevForm.nextPositionTime;
        this.timer = prevForm.timer;
    }

    public void SetPathPoints(Transform[] pathPoints)
    {
        this.pathPoints = pathPoints;
        transform.position = pathPoints[0].position;
        nextPoint = 0;
        if (!UpdateNextPositionVector())
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (!UpdateNextPositionVector())
            {
                Prod.Instance.TaskReachedProd(gameObject);
                Destroy(gameObject);
            }
        }
        transform.Translate(nextPositionVector * Time.deltaTime);       
    }

    private bool UpdateNextPositionVector()
    {
        nextPoint += 1;
        if (nextPoint < pathPoints.Length - 1)
        {
            nextPositionVector = (pathPoints[nextPoint].position - transform.position);
            nextPositionTime = nextPositionVector.magnitude / speed;
            nextPositionVector = nextPositionVector.normalized * speed;
            timer = nextPositionTime;
            return true;
        }
        return false;
    }
}
