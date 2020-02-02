using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    public float minTimeEnemy1;
    public float recurringTimeEnemy1;
    public GameObject enemy2;
    public float minTimeEnemy2;
    public float recurringTimeEnemy2;
    public GameObject enemy3;
    public float minTimeEnemy3;
    public float recurringTimeEnemy3;

    public Collider2D myCollider;

    void Start()
    {
        Invoke("Wave1", minTimeEnemy1);
        Invoke("Wave2", minTimeEnemy2 + minTimeEnemy1);
        Invoke("Wave3", minTimeEnemy3 + minTimeEnemy2 + minTimeEnemy1);
    }

    public void Wave1()
    {
        Instantiate(enemy1, new Vector3(Random.Range(myCollider.bounds.min.x, myCollider.bounds.size.x),
            transform.position.y, transform.position.z), Quaternion.identity);
        Invoke("Wave1", Random.Range(0,recurringTimeEnemy1));
    }

    public void Wave2()
    {
        Instantiate(enemy2, new Vector3(Random.Range(myCollider.bounds.min.x, myCollider.bounds.size.x),
    transform.position.y, transform.position.z), Quaternion.identity);
        Invoke("Wave2", Random.Range(0,recurringTimeEnemy2));
    }

    public void Wave3()
    {
        Instantiate(enemy3, new Vector3(Random.Range(myCollider.bounds.min.x, myCollider.bounds.size.x),
    transform.position.y, transform.position.z), Quaternion.identity);
        Invoke("Wave3", Random.Range(0,recurringTimeEnemy3));
    }

}
