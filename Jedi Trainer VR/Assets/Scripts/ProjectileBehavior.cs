using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private GameObject sound;

	public enum Projectile
	{
        None,
		Bullet,
		Lightning,
        EnergyWave,
	}
    public Projectile projectileType = Projectile.None;
	public float ProjectileSpeed = 0.0f;

    private float _waitaAFewFrames= 0.0f;
    private bool _hasCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("Audioplayer");
        switch (projectileType)
        {
            case Projectile.Bullet:
                SetUpBullet();
                break;

            case Projectile.Lightning:
                SetUpLightning();
                break;

            case Projectile.EnergyWave:
                SetUpEnergyWave();
                break;

            case Projectile.None:
            default:
                break;
        }

    }


    private void SetUpBullet()
    {
        ProjectileSpeed = 3.0f;
    }

    private void SetUpLightning()
    {
        ProjectileSpeed = 10.0f;
    }
    private void SetUpEnergyWave()
    {
        ProjectileSpeed = 50.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position += transform.forward * ProjectileSpeed * Time.deltaTime;
        _waitaAFewFrames++;
        if (!_hasCollider)
        {
            if (_waitaAFewFrames > 5.0f)
            {
                Collider collider = GetComponent<Collider>();
                collider.enabled = !collider.enabled;
                _hasCollider = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);

        if (projectileType == Projectile.Bullet || projectileType == Projectile.None)
        {

            if (other.gameObject.name.Equals("SingleLine-LightSaber"))
            {
                //deflect
                this.gameObject.transform.Rotate(0, 180, 0);
                ProjectileSpeed = ProjectileSpeed * 3;
                AudioSource audioSource = sound.GetComponent<AudioSource>();
                audioSource.Play();
            }
            else if (other.gameObject.tag.Equals("Boss"))
            {
                DroneBehavior db = other.gameObject.GetComponent<DroneBehavior>();
                db.TakeDamage(0.05f);
            }
        }
        else if (projectileType == Projectile.EnergyWave)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                EnemyDrone ed = other.gameObject.GetComponent<EnemyDrone>();
                ed.Knockdown();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (projectileType == Projectile.Bullet || projectileType == Projectile.None)
        {

            if (collision.gameObject.tag.Equals("Boss"))
            {
                DroneBehavior db = collision.gameObject.GetComponent<DroneBehavior>();
                db.TakeDamage(0.05f);
            }
        }
    }

}

