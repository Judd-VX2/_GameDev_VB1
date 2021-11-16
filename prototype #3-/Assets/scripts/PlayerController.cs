using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; 
    public float jumpForce;
    //Camera 
    public float lookSensitivity; // Mouse movement sesitivity
    public float maxLookX; // Lowest down we can look
    public float minLookX; // Highest you can look
    private float rotX; // Current x rotation of the camera 
    //Components
    private Camera cam;
    private Rigidbody rb;

private Weapon weapon;

    void Awake()
   {
       //Get the components
       cam = Camera.main;
       rb = GetComponent<Rigidbody>();

       weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
   { 
       Move();
       CamLook();
       // Jump Button
       if(Input.GetButtonDown("Jump"));
         Jump();
         //Fire Button
         if(Input.GetButton("fire"))
         {
             if(weapon.CanShoot())
             weapon.Shoot();
         }

   }

    void Move()
    {   // Get Keyboard input with move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction 
        dir.y = rb.velocity.y;
        // Apply direction to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {
      // Cast ray to ground 
      Ray ray = new Ray(transform.position, Vector3.down);
      // Check Ray lenghth to jump
      if(Physics.Raycast(ray, 1.1f))
          rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void CamLook()
    {
      // Get mouse input so we can look around with mouse 
       float y = Input.GetAxis("Mouse X") * lookSensitivity;
       rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

       // Clamp the vertical rotation of the camera
       rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

       // Applying the rotation to Camera
       cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
       transform.eulerAngles += Vector3.up * y; 
    }
}






public void TakeDamage(int damage)
{
    curHP -= damage;

    if( curHP <= 0)
    die()

}
void die()
{
    print("You have DEATHED");
}

public void GiveHealth(int amountToGive)
{
    curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
}

public void Giveammo
