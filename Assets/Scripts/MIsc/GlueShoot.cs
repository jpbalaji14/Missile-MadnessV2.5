using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueShoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject GluePrefab;
    public float bulletCount = 20f;
    public float speed = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProcess();
        }
    }

    private void ShootProcess()
    {

        if (bulletCount >= 0)
        {
            GameObject bullet = Instantiate(GluePrefab, firePoint.transform.position /*+ new Vector3(0, 0, 1)*/, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
            bulletCount -= 1;
            Mathf.Clamp(bulletCount, 0, 20);
        }
    }
}
