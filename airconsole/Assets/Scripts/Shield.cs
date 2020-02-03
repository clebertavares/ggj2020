using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float duration;

    public Transform player;

    void Start()
    {
        Destroy(this.gameObject, duration);
    }

    void Update()
    {
        transform.position = player.position;        
    }
}
