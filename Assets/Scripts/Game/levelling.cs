using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class levelling : MonoBehaviour
{  
    public int levelnum = 5;
    public int score = 0;
    //[SerializeField] Text leveltext;
    [SerializeField] TextMeshProUGUI scoretext;[SerializeField] TextMeshProUGUI lvtext;
    UImove uim;
    [SerializeField] GameObject ParticleHolder;
  
    //coin particle
    [SerializeField] GameObject coinCollectParticle;
    //PowerUp and down particle
    [SerializeField] GameObject powerupParticle;
    [SerializeField] GameObject powerdownParticle;
    //missile particles
    [SerializeField] int currentParticleIndex;
    [SerializeField] GameObject[] particleIndex;

    private void Start()
    {
        uim = FindObjectOfType<UImove>();
    }
    void Update()
    {
        lvtext.text = "Lv: " + levelnum;
       levelnum= Mathf.Clamp(levelnum, 1,9);
       scoretext.text = "" + score;

        //missile particles
        Mathf.Clamp(currentParticleIndex, 1, 8);

    }
    public void LevelUp()
    {
        levelnum++;
        GetComponent<RagdollCollision>().Force += 2000;

        //ui
        

        //missile particles
        if (currentParticleIndex < particleIndex.Length - 1)
        {
            uim.rightmoving = true;
            Invoke(nameof(stoprmove), 0.2f);


            foreach (GameObject rocket in particleIndex)
            {
                rocket.SetActive(false);
            }
            currentParticleIndex++;
            particleIndex[currentParticleIndex].SetActive(true);
        }
        else
        {
            uim.rightmoving = false;
            particleIndex[9].SetActive(true);
        }
    }
    public void levelDown()
    {
        levelnum--;
        GetComponent<RagdollCollision>().Force -= 2000;

        //ui
       

        //missile particles
        if (currentParticleIndex > 0)
        {
            uim.leftmoving = true;
            Invoke(nameof(stoplmove), 0.2f);

            foreach (GameObject rocket in particleIndex)
            {
                rocket.SetActive(false);
            }
            currentParticleIndex--;
            particleIndex[currentParticleIndex].SetActive(true); 
        }
        else
        {
            uim.leftmoving = false;
            particleIndex[0].SetActive(true);
        }
    }
    void stoprmove()
    {
        uim.rightmoving = false;
    }
    void stoplmove()
    {
        uim.leftmoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        { 
            LevelUp();
            var greenparticle = Instantiate(powerupParticle, ParticleHolder.transform.position, Quaternion.identity);
            Destroy(greenparticle, 0.1f);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Obstacle")
        {
            levelDown();
            var redparticle = Instantiate(powerdownParticle, ParticleHolder.transform.position, Quaternion.identity);
            Destroy(redparticle, 0.1f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            score+=10;
           var storeparticle= Instantiate(coinCollectParticle, other.transform.position, Quaternion.identity);
            Destroy(storeparticle, 0.1f);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="TankBullet")
        {
            Debug.Log("ss");
            Destroy(this.gameObject);
        }
    }
}
