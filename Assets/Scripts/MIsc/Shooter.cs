using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject BulletSpawnPosition;
    [SerializeField] GameObject target;
    [SerializeField] GameObject parent;
    
    [SerializeField] float timeBetweenEachBullet = 1f;

    [SerializeField] float speed = 100f;
    [SerializeField] float turnSpeed = 300f;
    bool canShoot = true;

    void CanShootAgain()
    {
        canShoot = true;
    }

    void Fire()
    {
        GameObject EnemyBullet = Instantiate(BulletPrefab, BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.rotation);
        EnemyBullet.GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }

    void Turn()
    {
        Vector3 direction = (target.transform.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        this.transform.localEulerAngles = new Vector3(360f,0 , 0); // ... rotate the turret using EulerAngles because they allow you to set angles around x, y & z.
        //this.transform = RotateTurret();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canShoot == true)
        {
            Turn();
            Fire();
            
            canShoot = false;
            Invoke("CanShootAgain", timeBetweenEachBullet); // Increase value to slow down rate of fire, decrease value to speed up rate of fire.
        }
    }
        
    //void RotateTurret()
    //{
    //    //float? angle = CalculateAngle(towerAngle); // Set to false for upper range of angles, true for lower range.

    //    //if (angle != null) // If we did actually get an angle...
    //    //{
    //       
    //    //}
    //    //return angle;
    //} 
}
