using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 flyVector;
    public float power;
    public string activeTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activeTag))
        {
            collision.gameObject.GetComponent<HealthUpdater>().Hit(power);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(flyVector * Time.deltaTime);
    }
}
