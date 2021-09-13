using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMissile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform enemy;
    public GameObject target;
    bool detected;
    [SerializeField] float bulletDelay=5f;
    [SerializeField] float bulletSpeed = 6000f;
    public int bulletCount = 25;
    // Start is called before the first frame update
    void Start()
    {
        enemy.LookAt(target.transform);
        StartCoroutine(FireCont());
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount = Mathf.Clamp(bulletCount, 0, 15);
       
        //if (detected)
        //{
        //    enemy.LookAt(target.transform);
            
        //}
    }
    //private void FixedUpdate()
    //{
    //    if (detected)
    //    {
            
    //        StartCoroutine(FireCont());
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        detected = true;
    //    }
    //}
    IEnumerator FireCont()
    {

        while (true)
        {

            if (bulletCount > 0)
            {

                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position /*+ new Vector3(0, 0, 1)*/, firePoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = /*new Vector3(0, 0, bulletSpeed * Time.fixedDeltaTime);*/ transform.forward * bulletSpeed * Time.deltaTime;
                //bullet.GetComponent<Rigidbody>().velocity = /*new Vector3(0, 0, bulletSpeed * Time.fixedDeltaTime);*/ -transform.right* bulletSpeed * Time.deltaTime;
                bulletCount--;
                Destroy(bullet, 40f);
            }
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
