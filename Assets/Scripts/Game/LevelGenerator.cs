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

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyTankPosition = enemy.transform.position;
           
        float step = 1f / (numPoints + 1);
        for (lerpValue = step; lerpValue < 1f; lerpValue = lerpValue + step)
        { 
            Vector3 v = Vector3.Lerp(playerPosition, enemyTankPosition, lerpValue);

            Vector3 forwardDirection = enemy.transform.position - player.transform.position;
            Quaternion rotation = Quaternion.LookRotation(forwardDirection);

            Instantiate(platform[Random.Range(0, platform.Length)], v, rotation);
        }
    }
}
