using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissielForward : MonoBehaviour
{
    Rigidbody rb;
    public GameObject tank1;
    public GameObject tank2;
    [SerializeField] GameObject Boomeffect;
    [SerializeField] GameObject DestPart;
    [SerializeField] GameObject Missile;
    [SerializeField] float missileSpeed = 500f;
    [SerializeField] float decSpeed = 2f;
    [SerializeField] float sidespeed =200f;
    [SerializeField] float rotspeed = -60f;
    levelling level;

    //rot
    Vector3 rotVel;


    // Start is called before the first frame update
    void Start()
    {
        level = GetComponent<levelling>();
        rb = GetComponent<Rigidbody>();

        //rot
        rotVel = new Vector3(0, rotspeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 5)
        {
            decSpeed = 0;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.65f, 2.1f), transform.position.y, transform.position.z);    
    }

    private void FixedUpdate()
    {
        moveForw();
        moving();
    }
    void moving()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rb.AddForce(Vector3.right * touch.deltaPosition.x * sidespeed /** Time.deltaTime*/);
                if(touch.deltaPosition.x >0.5)
                {
                    StartCoroutine("Rot");
                    StopCoroutine("RotLeft");
                }
               else if(touch.deltaPosition.x < -0.5)
                {
                    StartCoroutine("RotLeft");
                    StopCoroutine("Rot");
                }
            }
        }
    }

    IEnumerator Rot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Quaternion deltaRotation = Quaternion.Euler(rotVel  * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator RotLeft()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Quaternion deltaRotation = Quaternion.Euler(-rotVel * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
             yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //if(collision.gameObject.tag =="rock")
        //{
        //   // Missile.SetActive(false);
        //    Invoke(nameof(destroyMissile), 0.8f);
          
        //}
       
        if (collision.gameObject.tag == "Enemy")
        {

            if (level.levelnum > 1 && level.levelnum <= 9)
            {
                //Missile.SetActive(false);
                // Invoke(nameof(destroyMissile), 1f);
                Invoke(nameof(TankChange), 0.18f);
                Destroy(this.gameObject,0.22f);
               // tank1.SetActive(false);
               // tank2.SetActive(true);   
            }  
            if(level.levelnum ==1)
            {
                Missile.SetActive(false);
            }
        }
    }
    public void moveForw()
    {
        var mSpeed = missileSpeed * Time.deltaTime;
        var FallSpeed = decSpeed * Time.deltaTime;
        rb.velocity = Vector3.forward * mSpeed + (-Vector3.up * FallSpeed);
    }

    void TankChange()
    {
        tank1.SetActive(false);
        tank2.SetActive(true);
    }
    //void destroyMissile()
    //{
    //  var expparticle= Instantiate(Boomeffect, DestPart.transform.position, Quaternion.identity);
    //    Destroy(expparticle, 1f);
    //    Destroy(this.gameObject,0.1f);
    //}
}
