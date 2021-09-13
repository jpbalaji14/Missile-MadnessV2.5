using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    public GameObject enemy;
    public GameObject/*[]*/ Prefab;
    public int numPoints = 9;


    //
    //int randomPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = enemy.transform.position;

        float step = 1f / (numPoints + 1);
        for (float lerpValue = step; lerpValue < 1f; lerpValue += step)
        {
            Vector3 v = Vector3.Lerp(p1, p2, lerpValue);

           //rotating the instantiated obj
            Vector3 direction = enemy.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            //
            //randomPrefabs = Random.Range(0, 5);
            //
            GameObject ij = Instantiate(Prefab/*[randomPrefabs]*/, v, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
