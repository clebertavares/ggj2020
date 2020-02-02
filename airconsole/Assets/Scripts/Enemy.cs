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

    public GameObject explosion;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "shootPlayer")
        {
            energy -= collision.GetComponent<Shoot>().damage;

            if(energy<=0)
            {
                GameObject go = Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(go, 0.5f);
                Destroy(this.gameObject);
            }
        }

        if (collision.tag == "Player")
        {
            //Destroy(collision.gameObject);//gameover, q fazer? remover energia?
            collision.GetComponent<Player>().energy -= 10;//?como mostrar?
            GameObject go = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
