using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueBullet : MonoBehaviour
{
    [SerializeField] Collider collider;
     Rigidbody rb;
    //scaling glue
    [SerializeField] float speed = 2f;
    [SerializeField] float duration = 2f;
    [SerializeField] Vector3 maxscale;
    [SerializeField] Vector3 minscale;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 8f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            collider.enabled = false;
            StartCoroutine(scaling());
        }
    }
    IEnumerator scaling()
    {
        // minscale = transform.localScale;
        yield return ScaleLerp(minscale, maxscale, duration);
    }
    IEnumerator ScaleLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (0.1f / time) * speed;
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
