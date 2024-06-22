using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;
    [SerializeField] public float ylock = 0.25f;
    [SerializeField] float offsetx = 7.6f;


    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) >= distance)
        {
            transform.position = new Vector3(target.position.x + offsetx, ylock, -10);
        }
        transform.position = new Vector3(transform.position.x, ylock, transform.position.z);
    }
}
