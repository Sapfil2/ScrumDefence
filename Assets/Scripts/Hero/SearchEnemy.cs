using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    public float searchRadius;
    public float fireTimer;
    public GameObject bullet;
    public float bulletSpeed;
    private float timer;
    public string activeTag;

    private LinkedList<HealthUpdater> enemies = new LinkedList<HealthUpdater>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activeTag))
        {
            enemies.AddLast(collision.gameObject.GetComponent<HealthUpdater>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activeTag))
        {
            enemies.Remove(collision.gameObject.GetComponent<HealthUpdater>());
        }
    }

    private void Start()
    {
        timer = fireTimer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (enemies.Count > 0)
        {
            while (enemies.First == null)
            {
                enemies.RemoveFirst();
            }
            if (enemies.Count > 0)
            {
                if (timer < 0)
                {
                    timer = fireTimer;
                    GameObject b = Instantiate(bullet);
                    b.transform.position = transform.position;
                    Vector3 toTargetVector = enemies.First.Value.gameObject.transform.position - transform.position;
                    b.GetComponent<Bullet>().flyVector = toTargetVector.normalized * bulletSpeed;
                    b.GetComponent<Bullet>().power = 1;
                    b.GetComponent<Bullet>().activeTag = activeTag;
                    b.transform.Translate(new Vector3(0, 0, -3));
                }
            }
        }
    }
}
