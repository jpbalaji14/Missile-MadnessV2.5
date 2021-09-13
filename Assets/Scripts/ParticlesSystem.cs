using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSystem : MonoBehaviour
{
    [SerializeField] GameObject Boomeffect;
    [SerializeField] GameObject DestPart;
    [SerializeField] GameObject DestPart2;
    [SerializeField] GameObject DestPart3;
    [SerializeField] GameObject DestPart4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "rock")
        {
            // Missile.SetActive(false);
            Invoke(nameof(destroyMissile), 0.8f);

        }

    }
    void destroyMissile()
    {
        var expparticle = Instantiate(Boomeffect, DestPart.transform.position, Quaternion.identity);
        var expparticle2 = Instantiate(Boomeffect, DestPart2.transform.position, Quaternion.identity);
        var expparticle3 = Instantiate(Boomeffect, DestPart3.transform.position, Quaternion.identity);
        var expparticle4 = Instantiate(Boomeffect, DestPart4.transform.position, Quaternion.identity);
        Destroy(expparticle, 1f);
        Destroy(expparticle2, 1f);
        Destroy(expparticle3, 1f);
        Destroy(expparticle4, 1f);
        Destroy(this.gameObject, 0.1f);
    }
}
