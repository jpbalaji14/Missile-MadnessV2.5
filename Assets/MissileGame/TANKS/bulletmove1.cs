using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove1 : MonoBehaviour
{
   public GameObject target;
    public float speed=40f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("p2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
