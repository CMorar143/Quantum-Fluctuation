﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Transform newParticle;
    public float freq = 0.8f;
    Vector3 rot;

    void Start()
    {
        newParticle = this.transform;
        StartCoroutine("CreateParticles");
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            newParticle.Rotate(rot, Space.Self);

            // Pop into existence
            GameObject p = (GameObject)Instantiate(
                              particles,
                              new Vector3(
                                  transform.position.x,
                                  this.gameObject.transform.position.y,
                                  transform.position.z
                                  ),
                              newParticle.rotation
                              );

            float matterColour = Random.value;
            float antiMatterColour = (matterColour + 0.5f) % 1;
            p.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.HSVToRGB(matterColour, 1, 1);
            p.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.HSVToRGB(antiMatterColour, 1, 1);
            p.transform.position = this.transform.position;

            yield return new WaitForSeconds(freq);
        }
    }
}
