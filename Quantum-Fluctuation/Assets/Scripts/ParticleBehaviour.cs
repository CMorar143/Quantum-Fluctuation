using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public GameObject Matter, AntiMatter;
    private Transform startMattter, startAntiMatter;
    // Start is called before the first frame update
    void Start()
    {
        startMattter = Matter.transform;
        startAntiMatter = AntiMatter.transform;
        Invoke("MoveParticles", 3);
    }

    public void MoveParticles()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
