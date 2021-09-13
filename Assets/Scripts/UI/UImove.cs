using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImove : MonoBehaviour
{
   public bool rightmoving = false;
    public bool leftmoving = false;
    [SerializeField] float speed = 350f;
    //[SerializeField] float leftspeed = 350f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {


        if (rightmoving == true)
        {
            uirightmove();
        }

        if (leftmoving == true)
        {
            uileftmove();
        }
    }
    private void FixedUpdate()
    {
      
    }

    public void uirightmove()
    {
        transform.position -= Vector3.right *speed*Time.fixedDeltaTime;
    }
    public void uileftmove()
    {
        transform.position += Vector3.right *speed* Time.fixedDeltaTime;
    }
}
