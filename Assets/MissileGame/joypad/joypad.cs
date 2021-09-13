using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joypad : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public Transform player;
    public GameObject joy;
    Vector3 move;
    public RectTransform pad;
    public RectTransform stick;
    public float movespeed;
    public Animator anim;
    public Rigidbody rb;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //if (transform.localPosition.x > 0)
        //{
        //    anim.SetFloat("horizontal", 1f);
        //}
        //if (transform.localPosition.x < 0)
        //{
        //    anim.SetFloat("horizontal", -1f);
        //}
    }
    public void OnDrag(PointerEventData eventData)
    { 
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.1f);  // stick clamping
        move = new Vector3(transform.localPosition.x, 0, 0).normalized;  
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine("playerMove");
        anim.SetFloat("vertical", 0);
        anim.SetFloat("horizontal", 0);
       

        joy.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        anim.SetFloat("vertical", 1);
        StartCoroutine("playerMove");
    }
    IEnumerator playerMove()
    {
        while(true)
        {
            if (transform.localPosition.x > 0)
            {
                rb.AddForce(Vector3.right * movespeed * movespeed * Time.deltaTime);
                anim.SetFloat("horizontal", 1f);
            }
            if (transform.localPosition.x < 0)
            {
                rb.AddForce(-Vector3.right * movespeed * movespeed * Time.deltaTime);
                anim.SetFloat("horizontal", -1f);
            }
            //player.Translate(move * movespeed * Time.deltaTime, Space.World);
            //if (move != Vector3.zero)
            //{
            //    player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5f * Time.deltaTime);
            //}
            yield return null;
        }
    }

    


}
