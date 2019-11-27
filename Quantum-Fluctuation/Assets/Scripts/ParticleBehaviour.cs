using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public GameObject Matter, AntiMatter;
    private float velocity = 0.2f;
    private float impulseForce = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        MoveParticles();
    }

    public void MoveParticles()
    {
        Matter.GetComponent<Rigidbody>().AddRelativeForce(impulseForce, 0, 0, ForceMode.Impulse);
        AntiMatter.GetComponent<Rigidbody>().AddRelativeForce(-impulseForce, 0, 0, ForceMode.Impulse);
        StartCoroutine(AddTag(0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }

    IEnumerator AddTag(float time)
    {
        yield return new WaitForSeconds(time);

        Matter.gameObject.tag = "matter";
        Debug.Log("added tag");
    }
}
