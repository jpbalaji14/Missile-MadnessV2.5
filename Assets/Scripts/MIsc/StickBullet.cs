using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBullet : MonoBehaviour
{
    // Vector3 minscale;
    //public Vector3 maxscale;
    //[SerializeField] float speed=2f;
    //[SerializeField] float duration = 2f;

    //Rigidbody rb;
    //public Collider collider;
    //public Transform bullet;
    //float x, y, z;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    minscale = transform.localScale;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Destroy(gameObject, 5f);
    //}
    //IEnumerator OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag =="Enemy")
    //    {
    //        rb.constraints = RigidbodyConstraints.FreezeAll;
    //        collider.enabled = false;
    //        //x = Random.Range(0.5f, 2f);
    //        //y = Random.Range(0.5f, 2f);
    //        //z = Random.Range(0.5f, 2f);
    //        //bullet.localScale = new Vector3(x, y, z);

    //        //StartCoroutine(scaling());
            
    //        yield return ScaleLerp(minscale, maxscale, duration);

    //    }
    //}
    ////IEnumerator scaling()
    ////{
        
    ////}

    //IEnumerator ScaleLerp(Vector3 a, Vector3 b,  float time)
    //{
    //    float i = 0f;
    //    float rate = (0.1f / time) * speed;
    //    while(i<1f)
    //    {
    //        i += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(a, b , i);
    //        yield return null;
    //    }
    //}
}
