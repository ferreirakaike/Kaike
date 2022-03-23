using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputProcessor : MonoBehaviour
{
    public GameObject leftController;
    public GameObject healthManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerMadeGesture(GestureCompletionData data)
    {
        
        Debug.Log("gesture name = " + data.gestureName);
        Debug.Log("id = " + data.gestureID);
        
        if (data.gestureName == "v")
        {
            // shoot lightning
            ShootProjectile shootProjectile = leftController.GetComponent<ShootProjectile>();
            shootProjectile.ShootLightning();
            Debug.Log("Lightning!");
        }

        else if (data.gestureName == "swipe")
        {
            // shoot lightning
            ShootProjectile shootProjectile = leftController.GetComponent<ShootProjectile>();
            shootProjectile.ShootForceWave();
            Debug.Log("Use the force!");
        }

        else if (data.gestureName == "circle")
        {
            // heal
            HealthManager hm = healthManager.GetComponent<HealthManager>();
            hm.Heal(0.20f);

            // let user know you healed
            ShootProjectile shootProjectile = leftController.gameObject.GetComponent<ShootProjectile>();
            shootProjectile.ShootHeal();
            Debug.Log("Heal!");
        }

        else if (data.gestureName == "five")
        {
            ShootProjectile shootProjectile = leftController.gameObject.GetComponent<ShootProjectile>();
            shootProjectile.ShootGrave();
            Debug.Log("Future sight");
        }
    }
}
