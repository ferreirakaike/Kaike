using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hurtbox : MonoBehaviour
{
    public GameObject healthManager;
    
    //[Header("UI")]
	public Image progressBarImage;

    private AudioSource _source;
    public AudioClip damageTakenSound;

    // Start is called before the first frame update
    void Start()
    {
        _source = gameObject.AddComponent<AudioSource>();
        _source.spatialBlend = 1;
        _source.volume = 0.3f;

        // Health bar is 100% at start
		progressBarImage.fillAmount = Mathf.Clamp(100,0,100);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();   
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Human Behavior Collided with: " + other.gameObject.name);

        if (other.gameObject.tag.Equals("Enemy"))
        {
            HealthManager hm = healthManager.GetComponent<HealthManager>();
            hm.TakeDamage(0.05f);
            _source.PlayOneShot(damageTakenSound);
            Destroy(other.gameObject);

            // Update Jedi's health
           // progressBarImage.fillAmount = hm.GetHealth();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Boss"))
        {
            HealthManager hm = healthManager.GetComponent<HealthManager>();
            hm.TakeDamage(0.05f);
            _source.PlayOneShot(damageTakenSound);
            Destroy(other.gameObject);
            //progressBarImage.fillAmount = hm.GetHealth();

        }
    }

    private void UpdateHealth()
    {
        HealthManager hm = healthManager.GetComponent<HealthManager>();
        progressBarImage.fillAmount = hm.GetHealth();

    }

}
