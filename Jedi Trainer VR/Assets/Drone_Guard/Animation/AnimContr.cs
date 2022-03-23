using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimContr : MonoBehaviour
{
    public GameObject thePlayer;

    public GameObject theBullet;
    private float shootTime = 0f;

    public GameObject position1;
    public GameObject position2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            this.gameObject.transform.position += transform.forward * .5f * Time.deltaTime; ;
        }
       
        if (Input.GetKeyDown("1"))
        {
            transform.position = position1.transform.position;
        }

        
        if (Input.GetKeyDown("2"))
        {
            transform.position = position2.transform.position;
        }

        /*
        if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        */
    }

    void FixedUpdate()
    {
        this.gameObject.transform.LookAt(thePlayer.transform);
        //this.gameObject.transform.position += transform.forward * .5f * Time.deltaTime;
        shootTime++;

        //every 10 seconds or so, shoot a bullet
        if (shootTime > 200f)
        {
            GameObject.Instantiate(theBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);

            shootTime = 0;
        }
    }
}
