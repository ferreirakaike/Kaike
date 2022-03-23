using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehavior : MonoBehaviour
{
    // where to shoot
    public GameObject thePlayer;

    // bullet prefab to spawn
    public GameObject theBullet;

    public float droneHealth = 100.0f;

    private float shootTime = 0f;
    private float _nextBulletTime = 40.0f;
    private float _timeUntilBarrage = 0.0f;

    public GameObject position1;
    public GameObject position2;
    public GameObject position3;

    private Transform startMarker;
    private Transform endMarker;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public float movementSpeed = 1.0f;

    public bool isInJourney = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = position1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        
        if (droneHealth < 0.0f)
        {
            DroneDeath();
        }

        this.gameObject.transform.LookAt(thePlayer.transform);
        
        _timeUntilBarrage++;

        if (_timeUntilBarrage > 400.0)
        {
            _nextBulletTime = 15.0f;
            if (_timeUntilBarrage > 500.0)
            {
                _nextBulletTime = 40.0f;
                _timeUntilBarrage = 0;
            }
        }

        shootTime++;

        //every X seconds or so, shoot a bullet
        if (shootTime > _nextBulletTime)
        {
            GameObject.Instantiate(theBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);

            shootTime = 0;
        }

        if (!isInJourney)
        {
            isInJourney = true;
            startTime = Time.time;
            startMarker = this.gameObject.transform;

            int position = Random.Range(1, 4);
            if (position == 1)
            {
                endMarker = position1.transform;
            }
            else if (position == 2)
            {
                endMarker = position2.transform;
            }
            else if (position == 3)
            {
                endMarker = position3.transform;
            }

            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }

        if (isInJourney)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * movementSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            if (transform.position == endMarker.position)
            {
                isInJourney = false;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        droneHealth = droneHealth - amount;
    }

    private void DroneDeath()
    {
        Destroy(this.gameObject);
    }
}
