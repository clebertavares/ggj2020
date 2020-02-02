using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float duration;

    void Start()
    {
        Destroy(this.gameObject, duration);
    }
}
