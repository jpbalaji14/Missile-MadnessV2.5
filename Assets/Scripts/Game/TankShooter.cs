using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField] Transform Obj1;
    [SerializeField] Transform Obj2;
    //[SerializeField] Transform ShootPoint;

    [SerializeField] Animator anim;
    [SerializeField] GameObject TankBulletPrefab;
    [SerializeField] float ShootTiming = 0.75f;
    [SerializeField] float BulletMoveSpeed = 100f;
    [SerializeField] GameObject ShootParticle;
    bool CanShoot;
    //Range calculation
    [SerializeField] float MaxDistance=215f;
    [SerializeField] float MinDistance = 30f;
    [SerializeField] bool ShowRangeInConsole;
    
    // Start is called before the first frame update
    void Start()
    {
        CanShoot=true;
        ShowRangeInConsole = false;
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Obj1.transform.position, Obj2.transform.position);
        
        //Distance Calculation and find range
        if(ShowRangeInConsole==true)
        {
           Debug.Log(distance);  
        }

        if ((distance <=MaxDistance) && (distance >=MinDistance) )
        {
           
            if(CanShoot)
            {
                transform.LookAt(Obj2);
                ShootThePlayer();
                CanShoot = false;
                anim.SetBool("shoot", true);
                Invoke("CanShootAgain", ShootTiming);
            }
        }
        if(distance <=30)
        {
            Destroy(this);
        }
        else if(distance<=MinDistance)
        {
            anim.SetBool("shoot", false);
        }

    }
    private void ShootThePlayer()
    {
        GameObject TankShooter = Instantiate(TankBulletPrefab, Obj1.transform.position, transform.rotation);
        TankShooter.GetComponent<Rigidbody>().velocity = BulletMoveSpeed * transform.forward;
      GameObject Particle= Instantiate(ShootParticle, Obj1.transform.position, transform.rotation);
        Destroy(Particle.gameObject, 0.5f);
    }

    void CanShootAgain()
    {
        CanShoot = true;
    }
}
