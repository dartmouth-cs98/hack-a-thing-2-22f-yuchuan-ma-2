using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
        // can also time a speed multiplier
        // similiar move fashion with
        // transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
