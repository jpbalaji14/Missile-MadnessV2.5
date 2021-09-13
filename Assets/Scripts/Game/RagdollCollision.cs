using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollCollision : MonoBehaviour
{
    bool hasExploaded = false;
    public float radius=5f;
    public float Force = 7000f;
    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Force = Mathf.Clamp(Force, 1000, 10700);
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (/*collision.gameObject.tag=="Enemy" &&*/ hasExploaded == false)
        {
            Debug.Log("attacking");
            Explode();
            hasExploaded = true;
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
    private void Explode()
    {
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider nearbyobject in colliders)
        {
            Rigidbody rb = nearbyobject.GetComponent<Rigidbody>();
            if (rb != null)
            { 
                rb.AddExplosionForce(Force, this.transform.position, radius);
            }
        }
    }
}
