using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour
{
   
    public GameObject bulletPool;
    public Transform muzzle;

    public float bulletSpeed;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;


    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
            // Are we attached to the player?
            if(GetComponent<PlayerController>())
            {
                isPlayer = true;
            }
     }
    
     public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    public void Shoot()
    { 
        lastShootTime = Time.time;
        curAmmo --;
        
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // Set the velocity 
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

}


