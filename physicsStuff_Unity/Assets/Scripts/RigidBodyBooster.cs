using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyBooster : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 300f;

    // cache the property if it is used ofter
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody.AddForce(Vector3.up * _forceAmount);
        }
    }

}
