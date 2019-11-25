using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotSpeed = 65.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = this.speed;

        if (Input.GetKey(KeyCode.E))
        {
            Fly(Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.F))
        {
            Fly(-Time.deltaTime * speed);
        }

        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0f);
    }

    void Fly(float units)
    {
        transform.position += Vector3.up * units;
    }
}
