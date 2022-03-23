using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Human Behavior Collided with: " + other.gameObject.name);

        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);
        
    }

}
