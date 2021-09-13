using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    levelling level;

    private void Start()
    {
        level = FindObjectOfType<levelling>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            level.levelDown();
        }
    }
}
