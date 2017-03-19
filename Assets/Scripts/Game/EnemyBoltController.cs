using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltController : MonoBehaviour {

    public float speed;
    public int damage;
    public float timeToLive;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
