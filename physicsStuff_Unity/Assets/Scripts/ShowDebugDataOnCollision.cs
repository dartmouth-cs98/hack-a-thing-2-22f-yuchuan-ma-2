using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDebugDataOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Impacted at " + other.contacts[0].point);

        float rayDrawDistance = 5f;

        Debug.DrawRay(
            // you usually would just need to access [0] unless when e.g. two things hit all at once??
            other.contacts[0].point,
            other.contacts[0].normal * rayDrawDistance,
            Color.red,
            1f
        );
    }

}
