using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float vel;

    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3);
    }

    void Update()
    {
        this.rb2d.velocity = Vector3.up * vel;
    }
}
