using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToGame : MonoBehaviour
{
    public GameObject missile;
    public GameObject cam;
    public GameObject Flight;
    public GameObject flightcam;
    public GameObject miss;
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    void Update()
    {
        Invoke("Game",2.98f);
        //Invoke("game2", 6.2f);
        Invoke("particles", 1.2f);
        Destroy(this,6.2f);
    }
    void Game()
    {
        missile.SetActive(true);
        cam.SetActive(true);
        flightcam.SetActive(false);
        miss.SetActive(false);
        Flight.SetActive(false);
    }
    void game2()
    {
          
    }
    void particles()
    {
        particle1.SetActive(true);
        particle2.SetActive(true);
    }
}
