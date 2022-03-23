using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += transform.forward * 3.0f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);

        if (other.gameObject.name.Equals("SingleLine-LightSaber"))
        {
            //deflect
            this.gameObject.transform.Rotate(0, 180, 0);
        }
    }
}
