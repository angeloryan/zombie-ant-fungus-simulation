using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (t.position.x > 10 || t.position.x < -10 || t.position.z > 10 || t.position.z < -10)
        {
            t.Rotate(new Vector3(0, t.rotation.y + 1, 0));
        }

        t.Translate(transform.forward * Time.deltaTime);
    }
}
