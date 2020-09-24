using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    private void Awake()
    {
        offset = transform.position - target.position;
        
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
