using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam3;
    public GameObject multiplier;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            multiplier.SetActive(true);
            Invoke("cam", 0.01f);
        }
    }
    void cam()
    {
        //cam1.SetActive(false);
        cam3.SetActive(true);
    }
}
