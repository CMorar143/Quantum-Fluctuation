using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotSpeed = 65.0f;

    public float xAngle, yAngle, zAngle;

    private GameObject cube1, cube2;

    void Awake()
    {
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        cube1.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube1.name = "Self";

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(-0.75f, 0.0f, 0.0f);
        cube2.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        cube2.GetComponent<Renderer>().material.color = Color.green;
        cube2.name = "World";
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        //float speed = this.speed;
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
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
