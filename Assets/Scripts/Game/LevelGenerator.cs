using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject[] platform;
    public int numPoints = 9;
    float lerpValue;

    Vector3 v;
    Quaternion rotation;

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyTankPosition = enemy.transform.position;

        float step = 1f / (numPoints + 1);
        int i = 0;
        for (lerpValue = step; lerpValue < 1f; lerpValue = lerpValue + step , i+=1)
        {
           
            v = Vector3.Lerp(playerPosition, enemyTankPosition, lerpValue);

            Vector3 forwardDirection = enemy.transform.position - player.transform.position;
            Quaternion rotation = Quaternion.LookRotation(forwardDirection);

            //Instantiate(platform[/*Random.Range(0, platform.Length)*/], v, rotation);
            Instantiate(platform[i], v, rotation);
            if(i>platform.Length)
            {
                return;
            }
        }
        //for (int i = 0; i < platform.Length; i++)
        //{ 
        //    Instantiate(platform[i], v, rotation);
        //}
    }
}
