using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{  
	public float speed=35f;
    public float sidespeed=1f;
    [SerializeField] float rotspeed = -60f;
    public GameObject object1;
	public GameObject object2;
    Vector3 rotVel;
    Rigidbody rb;
    levelling level;
    public GameObject tank1;
    public GameObject tank2;
    public GameObject MissCam;
    //public GameObject Boomeffect;
    //public GameObject DestPart;
    //public GameObject Missile;



    Touch thetouh;
    Vector3 touchstartpos, touchendpos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        level = GameObject.FindGameObjectWithTag("Player").GetComponent<levelling>();
        //rot
        rotVel = new Vector3(0, rotspeed, 0);
    }
     void Update()
    {
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1f, 1f), transform.position.y, transform.position.z);
        //Time.timeScale = 0.1f;

         moving();


    }
    void FixedUpdate()
    {
        Vector3 direction = object1.transform.position - object2.transform.position;

        // Normalize resultant vector to unit Vector.
        direction = -direction.normalized;

        // Move in the direction of the direction vector every frame.
        object1.transform.position += direction * Time.deltaTime * speed;

    }
    void moving()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);       //If Touched, The player is moved Left and Right.
            if (touch.phase == TouchPhase.Moved)
            {
                rb.AddForce(Vector3.right * touch.deltaPosition.x * sidespeed * Time.deltaTime);
                if (touch.deltaPosition.x > 0.005)
                {
                    StartCoroutine("Rot");
                    StopCoroutine("RotLeft");
                }
                else if (touch.deltaPosition.x < -0.005)
                {
                    StartCoroutine("RotLeft");
                    StopCoroutine("Rot");
                }  
            }
            else if (thetouh.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended)
            {
                Debug.Log("station");
                rb.AddForce(Vector3.zero * touch.deltaPosition.x * sidespeed * Time.deltaTime);
            }

        }
    }

    IEnumerator Rot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.004f);
            Quaternion deltaRotation = Quaternion.Euler(rotVel * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            yield return new WaitForSeconds(0.004f);
        }
    }
    IEnumerator RotLeft()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.004f);
            Quaternion deltaRotation = Quaternion.Euler(-rotVel * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            yield return new WaitForSeconds(0.004f);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "ChunkObstacle")
        {
            speed = 2f;
        }

        if (collision.gameObject.tag == "Enemy")
        {

            if (level.levelnum > 1 && level.levelnum <= 9)
            {
                tank1.SetActive(false);
                tank2.SetActive(true);
                this.gameObject.SetActive(false);
                // Invoke(nameof(destroyMissile), 1f);
                //Destroy(this.gameObject, 0.25f);
                Destroy(MissCam.GetComponent<CamController>());
            }
            if (level.levelnum == 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
