using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawnPoint : MonoBehaviour
{
    // where to shoot
    public GameObject thePlayer;

    // drone prefab to spawn
    public GameObject theDrone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.gameObject.transform.LookAt(thePlayer.transform);
    }

    public void SpawnAttackDrone()
    {
        GameObject.Instantiate(theDrone, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
