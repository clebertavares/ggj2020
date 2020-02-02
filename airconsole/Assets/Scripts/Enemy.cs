using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vel;

    public Rigidbody2D rb2d;

    public GameObject shoot;

    public float timeToShoot;

    public float energy;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10);
        Invoke("Shoot", Random.Range(0,timeToShoot));
    }

    void Shoot()
    {
        Instantiate(shoot, this.transform.position, Quaternion.identity);
        Invoke("Shoot", Random.Range(0, timeToShoot));
    }

    void Update()
    {
        this.rb2d.velocity = Vector3.up * vel;
    }
}
