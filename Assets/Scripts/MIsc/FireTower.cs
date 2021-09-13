using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    [Header("Tower shooting configs")]
    [Tooltip("The rate we want bullets to fire at")]
    [SerializeField] GameObject MortarBulletPrefab;
    [SerializeField] GameObject MBSpawnPosition;
    [SerializeField] GameObject target;
    [SerializeField] GameObject parent;

    [Header("Tower Shoot & Wait")]
    [Tooltip("Set false for upper angles, True for lower angles")]
    [SerializeField] bool towerAngle = true;
    [SerializeField] float timeBetweenEachBullet = 1f;

    float speed = 15f;
    float turnSpeed = 3f;
    bool canShoot = true;

    void CanShootAgain()
    {
        canShoot = true;
    }

    void Fire()
    {
        GameObject EnemyBullet = Instantiate(MortarBulletPrefab, MBSpawnPosition.transform.position, MBSpawnPosition.transform.rotation);
        EnemyBullet.GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }

    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        float? angle = RotateTurret();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Fire();
        //}
        //if (angle != null && Vector3.Angle(direction, parent.transform.forward) < 10) // When the angle is less than 10 degrees...
        //{
        //     // ...start firing.
        //    Debug.Log("Im Working");
        //}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canShoot == true)
        {
            Fire();
            canShoot = false;
            Invoke("CanShootAgain", timeBetweenEachBullet); // Increase value to slow down rate of fire, decrease value to speed up rate of fire.
        }
    }

    float? RotateTurret()
    {
        float? angle = CalculateAngle(towerAngle); // Set to false for upper range of angles, true for lower range.

        if (angle != null) // If we did actually get an angle...
        {
            this.transform.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f); // ... rotate the turret using EulerAngles because they allow you to set angles around x, y & z.
        }
        return angle;
    }
    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.magnitude;
        float gravity = 9.81f;
        float sSqr = speed * speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low)
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);

        }
        else
            return null;
    }
}