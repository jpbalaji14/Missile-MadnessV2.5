using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x1 : MonoBehaviour
{
    // [SerializeField] GameObject[] multiplierasset;
    public levelling lev;
    bool isHit = false;
    public int finalscore = 0;
    public Text scoretext;
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

        if (startScoring == true)
        {
            isHit = true;
            Debug.Log("Finallyx6");
            finalscore = lev.score * 1;
        }
    }
    void FinalDisp()
    {
       
        GO1.SetActive(true);
        GO2.SetActive(true);
        scoretext.text = "Final Score :" + finalscore;
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
            if (collision.gameObject.tag == "Enemy")
            {
                isPlayerColliding = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isPlayerColliding = false;
        }
    }

}
