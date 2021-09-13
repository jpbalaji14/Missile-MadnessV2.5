using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{
   // [SerializeField] GameObject[] multiplierasset;
    public levelling lev;
    bool hit =true;
    public int finalscore = 0;
    [SerializeField] Text scoretext;
    public GameObject GO1;
    public GameObject GO2;

    // Start is called before the first frame update
    void Start()
    {
        hit = true;
        lev = FindInactiveObject("Missile").GetComponent<levelling>(); //Method Definition at line 38 //Look at it when free
    }
    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score :" + finalscore;
        if (hit==false)
        {
            Invoke(nameof(FinalDisp),2f);
        }
    }
    void FinalDisp()
    {
        GO1.SetActive(true);
        GO2.SetActive(true);
    }

    //Used for finding InActive GameObjects in Scene & Stores.
    GameObject FindInactiveObject(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (hit == true)
        {
            switch (collision.gameObject.tag)
            {
                case "x1":
                    // Debug.Log("Score:1");
                    finalscore = lev.score *= 1;
                    hit = false;
                    break;
                case "x2":
                    finalscore = lev.score *= 2;
                    hit = false;
                    break;
                case "x4":
                    finalscore = lev.score *= 4;
                    // Debug.Log("Score:4");
                    hit = false;
                    break;
                case "x6":
                    finalscore = lev.score *= 6;
                    //Debug.Log("Score:6");
                    hit = false;
                    break;
                case "x8":
                    finalscore = lev.score *= 8;
                    // Debug.Log("Score:8");
                    hit = false;
                    break;
            }
        }

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    hit = true;

    //}

}
