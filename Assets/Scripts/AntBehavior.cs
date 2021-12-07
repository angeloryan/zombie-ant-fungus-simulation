﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    Rigidbody rb;
    Vector3 forwardDirection;
    Vector3 targetDirection;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardDirection = transform.forward.normalized;
        targetDirection = forwardDirection;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates current direction the ant is facing
        forwardDirection = transform.forward.normalized;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        targetDirection = Vector3.Reflect(forwardDirection, other.transform.position.normalized).normalized;
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }

}
