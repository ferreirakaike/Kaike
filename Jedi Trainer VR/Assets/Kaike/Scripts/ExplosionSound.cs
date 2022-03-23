using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    //private AudioSource source;
    //public AudioClip explosionSound;

    private float _timer = 0.0f;
    private bool _hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //source = gameObject.AddComponent<AudioSource>();
        //source.spatialBlend = 1;
        //source.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer++;
        if (_timer > 1000.0f)
        {
            //Destroy(this.gameObject);

        }
        else if (_timer > 100.0f)
        {
            if (!_hasPlayed)
            {
                Debug.Log("hello = " + _timer);
                //source.PlayOneShot(explosionSound);
                _hasPlayed = true;
            }
        }
    }
}
