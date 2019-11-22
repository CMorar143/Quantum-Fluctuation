using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public GameObject Matter, AntiMatter;
    private Transform startMarker;
    private Transform endMarker;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        startMarker = endMarker = this.transform;
        //endMarker.position += new Vector3(0, 4);
        Invoke("MoveParticles", 1);
    }

    public void MoveParticles()
    {
        this.GetComponent<Rigidbody>().AddForce(0, 0.5f, 0, ForceMode.Impulse);
        Matter.GetComponent<Rigidbody>().AddForce(1, 0, 0, ForceMode.Impulse);
        AntiMatter.GetComponent<Rigidbody>().AddForce(-1, 0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
