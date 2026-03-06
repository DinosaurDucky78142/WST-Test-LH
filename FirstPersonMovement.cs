//make a capsule with rigidbody. turn on all "freeze rotation" constraints.
//add main camera as a child of capsule exactly halfway up
//add this to capsule
//add "CameraUpDown.cs" to the camera, NOT the capsule
//add a tag "floor" to all walkable surfaces
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 250.0f;
    public float moveSpeed = 5.0f;
    public float normalSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float turnSpeed = 300.0f;
    public float mouseSensitivity = 5.0f;
    private bool isOnGround = true;

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //gets rigidbody
      rb = GetComponent<Rigidbody>();

      //hides & centers cursor
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       Movement();

       //makes the cursor visible + movable when "g" pressed
       if (Input.GetKeyDown("g"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void Movement()
    {
        //jumpin
        if (Input.GetKeyDown("space") && (isOnGround))
       {
            rb.AddForce(Vector3.up * jumpForce);
            isOnGround = false;
       }

        //mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        transform.Rotate(0.0f, mouseX * turnSpeed * Time.deltaTime, 0.0f);

        //runnin
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = normalSpeed;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //checks if player on floor
        if (collision.gameObject.CompareTag("floor"))
        {
            isOnGround = true;
            moveSpeed = normalSpeed;
        }
    }
}
