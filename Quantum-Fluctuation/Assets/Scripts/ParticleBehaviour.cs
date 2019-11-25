using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public GameObject Matter, AntiMatter;
    private float velocity = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveParticles", 1);
    }

    public void MoveParticles()
    {
        Matter.GetComponent<Rigidbody>().AddForce(1, 0, 0, ForceMode.Impulse);
        AntiMatter.GetComponent<Rigidbody>().AddForce(-1, 0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }
}
