using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShape : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;

    public float blendOne = 50f;
    [SerializeField] float blendSpeed = 1f;
    public float blendShapeOld;
    [SerializeField] float maxBlendAmount = 100f;
    [SerializeField] float minBlendAmount = 0f;
    //float newBlendVal;

    bool isTriggering = false;
    bool RocketLevelUp;

    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        
        blendShapeOld = blendOne;
        //Mathf.Clamp(blendShapeOld, 0f, 100f);
    }
    private void Update()
    {

        RocketUpgrade();
    }

    private void RocketUpgrade()
    {
        if (isTriggering == true)
        {
            blendShapeOld += Time.deltaTime * blendSpeed;
            skinnedMeshRenderer.SetBlendShapeWeight(0, blendShapeOld);
            if (skinnedMeshRenderer.GetBlendShapeWeight(0) >= blendOne && RocketLevelUp == true)
            {
                StopBlendValue();
            }
            else if (skinnedMeshRenderer.GetBlendShapeWeight(0) <= blendOne && RocketLevelUp == false)
            {
                StopBlendValue();
            }
        }
    }

    private void StopBlendValue()
    {
        blendSpeed = Mathf.Abs(blendSpeed);
        //Mathf.Abs(blendSpeed);
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
        blendShapeOld = blendOne;
        isTriggering = false;
    }

    public void LevelUp()
    {
        blendShapeOld = blendOne;
        blendOne += 12.5f; //blendOne = 62.5f
        blendSpeed = Mathf.Abs(blendSpeed);
        ClampValues();
        isTriggering = true;
        RocketLevelUp = true;

    }

    public void LevelDown()
    {
        blendShapeOld = blendOne; //105
        blendOne -= 12.5f; //105 = 105 - 15 (90)
        blendSpeed = -blendSpeed; //25 = 25 - 25;/* **/
        //blendOne = Mathf.Clamp(blendOne, 0, 100);
        ClampValues();
        isTriggering = true;
        RocketLevelUp = false;
    }

    private void ClampValues()
    {
        blendShapeOld = Mathf.Clamp(blendShapeOld, 0f, 100f);
        blendOne = Mathf.Clamp(blendOne, 0f, 100f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        {
            //isTriggering = true;
            LevelUp();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            LevelDown();
            Destroy(other.gameObject);
        }
    }
}
