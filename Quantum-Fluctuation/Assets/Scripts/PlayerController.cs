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
        //float speed = this.speed;
        //transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0f);

        // Go higher
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        // Go lower
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += Vector3.up * -Time.deltaTime * speed;
        }
    }
}
