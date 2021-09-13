using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierMeshSwap : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            rend.sharedMaterial = material[1];
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            rend.sharedMaterial = material[0];
        }
    }
}
