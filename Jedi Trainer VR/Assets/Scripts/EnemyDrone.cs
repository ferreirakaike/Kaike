using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    // where to shoot
    //public GameObject thePlayer;
    private string _status = "";
    private float _knockedTimer = 0.0f;
    public GameObject explosionSound;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _status = "moving";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_status == "moving")
        {
            this.gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (_status == "knocked")
        {
            _knockedTimer++;
            if (_knockedTimer > 50)
            {
                _status = "moving";
            }
        }
        //this.gameObject.transform.LookAt(thePlayer.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);

        if (other.gameObject.tag.Equals("Player"))
        {
            Instantiate(explosionSound, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);

            // Add Score - 10 points droid is hit
            ScoreManager.instance.AddScore(ScorePoints.DROID_SCOREPOINT);
        }

    }

    public void Knockdown()
    {
        if (_status != "knocked")
        {
            //Debug.Log("Knockdown ");
            _status = "knocked";
            _knockedTimer = 0.0f;
            transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3), 1.0f);
        }
    }
}
