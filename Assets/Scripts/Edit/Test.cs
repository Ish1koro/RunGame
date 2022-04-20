using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{[SerializeField] private float _distance;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * _distance, Color.blue);
    }
}
