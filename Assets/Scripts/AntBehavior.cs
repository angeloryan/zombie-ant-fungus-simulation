using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 forwardDirection;
    public Vector3 targetDirection;
    public Vector3 idealAreaDirection;
    public float speed;
    public bool sprouted;
    public bool idealConditions;
    public bool atTree;
    public float treeRadius;

    [SerializeField]
    public bool infected;
    [SerializeField]
    public GameObject sporeEffect;
    [SerializeField]
    public GameObject fungus;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardDirection = transform.forward.normalized;
        targetDirection = forwardDirection;
        idealAreaDirection = new Vector3(-26, 2, 7);
        treeRadius = .5f;
        speed = 5;
        sprouted = false;
        atTree = false;
        
        if (!infected)
            infected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!sprouted)
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

                if (idealConditions && !sprouted)
                {
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;
                    rb.isKinematic = true;

                    Instantiate(fungus, transform.position - new Vector3(0.25f, -0.5f, -0.2f), Quaternion.LookRotation(new Vector3(1, -3, 0)));
                    Instantiate(sporeEffect, new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z), Quaternion.LookRotation(Vector3.right));
                    sprouted = true;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!idealConditions)
        {
            Debug.Log(other.gameObject.tag);
            if (infected && other.transform.gameObject.CompareTag("Tree"))
            {
                rb.useGravity = false;
                atTree = true;
                rb.constraints = ~RigidbodyConstraints.FreezeRotationY;
                transform.rotation = Quaternion.LookRotation(new Vector3(-1, 1000, 0));
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
        infected = true;
    }

}
