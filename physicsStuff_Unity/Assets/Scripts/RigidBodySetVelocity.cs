using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySetVelocity : MonoBehaviour
{
    public float forceMult = 200;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * Time.deltaTime * forceMult;
    }
}
