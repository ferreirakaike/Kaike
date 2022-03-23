using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Transform trackingSpace; // reference to the tracking space
    public OVRInput.Controller controller; // the controller to instantiate the object at
    public GameObject projectile; // the game object to instantiate
    
    private AudioSource source;

    private bool isShooting = false;
    private float timeShooting = 0.0f;
    private float lightningRate = 0.0f;
    public AudioClip emitLightningSound;
    
    public GameObject forceWave;
    public AudioClip forceWaveSound;

    public GameObject healSign;
    public AudioClip healSound;

    public GameObject grave;
    public AudioClip graveSound;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 0.3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShooting)
        {
            timeShooting++;
            if (timeShooting < 100.0f)
            {
                lightningRate++;
                if (lightningRate > 5.0f)
                {
                    lightningRate = 0.0f;
                    source.PlayOneShot(emitLightningSound);
                    InstantiateObject(projectile);
                }
            }
            else
            {
                isShooting = false;
                //Debug.Log("isshooting is false");
            }
        }

    }

    public void ShootLightning()
    {
        if (!isShooting)
        {           
            timeShooting = 0.0f;
            isShooting = true;
        }
    }

    public void ShootForceWave()
    {
        source.PlayOneShot(forceWaveSound);
        InstantiateObject(forceWave);
    }

    public void ShootHeal()
    {
        source.PlayOneShot(healSound);
        InstantiateObject(healSign);
    }

    public void ShootGrave()
    {
        source.PlayOneShot(graveSound);
        InstantiateObject(grave);
    }

    private void InstantiateObject(GameObject toInstantiate)
    {
        Vector3 position = trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(controller));
        Vector3 rotation = trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(controller).eulerAngles);
        Instantiate(toInstantiate, position, Quaternion.Euler(rotation));
    }

}
