using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1Animator : MonoBehaviour
{
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shrink()
    {
        anim.SetBool("shrink", true);
    }
    public void attach()
    {
        anim.SetBool("attach",true);
    }
}
