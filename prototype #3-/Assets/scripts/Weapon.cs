using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletProjectile;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;


    void Awake (
        {
            // Are we attached to the player
            if(GetComponent<PlayerController>())
            {
                isPlayer = true;
            }
        }
    // Can we shoot a bullet
    public bool Canshoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }

        return false
    }

    public void shoot()
    {
        lastShootTime = Time.time;
        curAmmo --;

        GameObject bullet = Instantiate(bulletProjectile, muzzle.position, muzzle.rotation);

        // Set velocity of bulletProjectile 
        bullet.GetComponent<Rigidbody>(.velocity)
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
