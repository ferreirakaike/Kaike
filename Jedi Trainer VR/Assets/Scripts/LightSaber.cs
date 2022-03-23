using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public OVRInput.Controller controller;
    private bool activate = false;
    private GameObject laser;
    private Vector3 fullSize;


    private AudioSource source;  
    public AudioClip saberSwingSound;
    public AudioClip saberHummingSound;
    public AudioClip saberStartSound;
    public AudioClip saberEndSound;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 0.3f;
        laser = transform.Find("SingleLine-LightSaber").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        LaserControl();

        var velocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        if (activate == true && velocity.magnitude > 6)
        {
            source.PlayOneShot(saberSwingSound);
        } else if(activate == true && source.isPlaying == false) 
        {
            source.PlayOneShot(saberHummingSound);
        }
    }

    private void GetInput()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            activate = !activate;
            if (activate == true) 
            { 
                source.PlayOneShot(saberStartSound);
            } else if (activate == false){
                source.PlayOneShot(saberEndSound);
            }
        }
    }

    private void LaserControl()
    {
        if (activate && laser.transform.localScale.y < fullSize.y)
        {
            laser.SetActive(true);
            laser.transform.localScale += new Vector3(0, 0.001f, 0);
        } 
        else if (activate == false && laser.transform.localScale.y > 0)
        {
            laser.transform.localScale += new Vector3(0, -0.001f, 0);
        }
        else if (activate == false)
        {
            laser.SetActive(false);
        } 
    }
}
