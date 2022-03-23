using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHealSign : MonoBehaviour
{
    public Transform trackingSpace; // reference to the tracking space
    public OVRInput.Controller controller; // the controller to instantiate the object at
    public GameObject projectile; // the game object to instantiate

    private AudioSource source;
    public AudioClip healSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootHeal()
    {

    }
}
