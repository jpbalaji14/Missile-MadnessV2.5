using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakycam : MonoBehaviour
{
    public float power=0.2f;
    public float duration=0.8f;
    public Camera cam;
    public float slowamt=1f;
    public bool shouldshake = false;

    Vector3 startpos;
    float initialDuration;
    // Start is called before the first frame update
    void Start()
    {
        initialDuration = duration;
        startpos = cam.transform.localPosition;
        // StartCoroutine(startFunction());
    }
    //IEnumerator startFunction()
    //{
    //    yield return new WaitForSeconds(3.5f);
    //    cam = Camera.main;
       
    //}
    // Update is called once per frame
    void Update()
    {
        
       
        if (shouldshake)
        {
            if(duration>0)
            {
                cam.transform.localPosition = startpos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowamt;
            }
            else
            {
                shouldshake = false;
                duration = initialDuration;
                cam.transform.localPosition = startpos;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="rock" )
        {
            shouldshake = true;
            Destroy(gameObject.GetComponent<Shakycam>(), 0.2f);
        }   
        if(collision.gameObject.tag == "Enemy")
        {
            shouldshake = true;
            Destroy(gameObject.GetComponent<Shakycam>(), 0.2f);
        }
    }
}
