using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;

    private DroneSpawnPoint droneSpawnPoint1;
    private DroneSpawnPoint droneSpawnPoint2;
    private DroneSpawnPoint droneSpawnPoint3;

    private float timer = 0.0f;
    private bool has1 = false;
    private bool has2 = false;
    private bool has3 = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if (timer > 200.0f)
        {
            if (!has1)
            {
                DroneSpawnPoint droneSpawnPoint1 = spawnPoint1.GetComponent<DroneSpawnPoint>();
                droneSpawnPoint1.SpawnAttackDrone();
                timer = 0.0f;
                has1 = true;
            }
            //has1 = true;
        }
        //if (timer > 500.0f && !has2)
        //{
        //    DroneSpawnPoint droneSpawnPoint2 = spawnPoint2.GetComponent<DroneSpawnPoint>();
        //    droneSpawnPoint2.SpawnAttackDrone();
        //    has2 = true;
        //}
        //if (timer > 1000.0f && has3)
        //{
        //    DroneSpawnPoint droneSpawnPoint3 = spawnPoint3.GetComponent<DroneSpawnPoint>();
        //    droneSpawnPoint3.SpawnAttackDrone();
        //    has3 = true;
        //}

    }
}
