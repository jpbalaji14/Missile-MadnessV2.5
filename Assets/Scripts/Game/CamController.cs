using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    public float Ydist =1;
    public float Zdist = 5;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 PlayerPOS = player.transform.position;
        transform.position = new Vector3(transform.position.x, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
    }
  
}

