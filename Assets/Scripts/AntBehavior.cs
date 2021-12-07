using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 forwardDirection;
    public Vector3 targetDirection;
    public Vector3 idealAreaDirection;
    public GameObject sporeEffect;
    public float speed;
    public bool sprouted;
    public bool idealConditions;
    public bool atTree;

    [SerializeField]
    public bool infected;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardDirection = transform.forward.normalized;
        targetDirection = forwardDirection;
        idealAreaDirection = new Vector3(-26, 0, 7);
        speed = 5;
        sprouted = false;
        atTree = false;
        
        if (!infected)
            infected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!infected)
        {
            forwardDirection = transform.forward.normalized;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            if (transform.position.y > 12)
            {
                idealConditions = true;
            }

            if (idealConditions) 
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation;

                if (!sprouted)
                {
                    Instantiate(sporeEffect, transform.position, Quaternion.LookRotation(Vector3.right));
                    sprouted = true;
                }
            }
            else
            {
                targetDirection = (idealAreaDirection - transform.position).normalized;

                if (!atTree)
                    transform.rotation = Quaternion.LookRotation(targetDirection);

                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!idealConditions)
        {
            if (infected && other.gameObject.CompareTag("Tree"))
            {
                Debug.Log("climbing");
                //rb.useGravity = false;
                atTree = true;
                rb.constraints = ~RigidbodyConstraints.FreezeRotationY;
                transform.rotation = Quaternion.LookRotation(Vector3.up);
            }
            else if (!sprouted)
            {
                targetDirection = Vector3.Reflect(forwardDirection, other.transform.position.normalized).normalized;
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collision!");
        infected = true;
    }

}
