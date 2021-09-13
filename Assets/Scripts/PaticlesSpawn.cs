using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticlesSpawn : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public float spawntime=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn", spawntime);
    }

    void Spawn()
    {
        P1.SetActive(true);
        P2.SetActive(true);
    }
}
