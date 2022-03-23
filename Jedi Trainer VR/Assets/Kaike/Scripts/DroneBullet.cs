using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    public float projectileSpeed = 0.0f;
    public GameObject hi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
    }
}
