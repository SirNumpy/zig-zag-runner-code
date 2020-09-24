using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    RaycastHit hit;
    
    void Update()
    {
        Vector3 position = transform.TransformDirection(Vector3.forward);
        bool rayCast = Physics.Raycast(transform.position, -Vector3.up, out hit, 100f);
        if (rayCast)
        {
            print("rays are hit to an object " + hit.collider.gameObject.name);
            print("rays are hit at a distance of "+ hit.distance);
            Debug.DrawLine(position, hit.point, Color.blue);
        }
    }
}
