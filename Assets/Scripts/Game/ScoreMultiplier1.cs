using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier1 : MonoBehaviour
{
   // [SerializeField] GameObject[] multiplierasset;
    public levelling lev;
    
    bool isHit = false;
    public int finalscore = 0;
    [SerializeField] Text scoretext;
    public GameObject GO1;
    public GameObject GO2;

    public float timerCountDown = 2f;
    public bool isPlayerColliding = false;
    public bool startScoring;
    // Start is called before the first frame update
    void Start()
    {
        startScoring = false;
        isHit = false; //Tank hitting multiplier is false initially
        lev = FindInactiveObject("Missile").GetComponent<levelling>(); //Method Definition at line 38 //Look at it when free
    }
    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score :" + finalscore;

        if (isHit == true)
        {
            Invoke(nameof(FinalDisp), 1.5f);
        }


        if (isPlayerColliding == true)
        {
            timerCountDown -= 1 * Time.deltaTime;
            if (timerCountDown <= 0)
            {
                timerCountDown = 0;

                startScoring = true;
            }
        }

        if (isPlayerColliding == false)
        {
            timerCountDown = 2f;
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
        if (isHit == false)
        {
            switch (collision.gameObject.tag)
            {
                case "x1":
                    isPlayerColliding = true;
                    if (startScoring == true)
                    {
                        x1score();
                    }
                    break;

                case "x2":
                    isPlayerColliding = true;
                    if (startScoring == true)
                    {
                        isHit = false;
                        Debug.Log("Finally");
                        finalscore = lev.score * 2;

                    }
                    break;

                case "x4":
                    isPlayerColliding = true;
                    if (startScoring == true)
                    {
                        isHit = false;
                        Debug.Log("Finally");
                        finalscore = lev.score * 4;

                    }
                    break;

                case "x6":
                    isPlayerColliding = true;
                    if (startScoring == true)
                    {
                        isHit = false;
                        Debug.Log("Finally");
                        finalscore = lev.score * 6;
                    }
                    break;

                case "x8":
                    isPlayerColliding = true;
                    if (startScoring == true)
                    {
                        isHit = false;
                        Debug.Log("Finally");
                        finalscore = lev.score * 8;
                    }
                    break;
            }
        }
    }

    void x1score()
    {
        isHit = true;
        Debug.Log("Finally");
        finalscore = lev.score * 1;
    }


    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "x1":
                isPlayerColliding = false;
                isHit = true;
                break;

            case "x2":
                isPlayerColliding = false;
                isHit = true;
                break;

            case "x4":
                isPlayerColliding = false;
                isHit = true;
                break;

            case "x6":
                isPlayerColliding = false;
                isHit = true;
                break;

            case "x8":
                isHit = true;
                isPlayerColliding = false;
                break;
        }
    }

}
