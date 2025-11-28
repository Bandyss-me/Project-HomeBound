using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody rb;
    public float floatHeight;
    public float jumpforce;
    public float movespeed;
    public float sprintspeed;
    public float mouseSensitivity;
    public Camera playerCamera;
    bool jumopressed;
    float cameraPitch=0f;

    void Start(){
        rb=GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void jump(){
        rb.linearVelocity += Vector3.up * jumpforce;
    }

    void move(){
        Vector3 v = rb.linearVelocity;
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            input.z += 1f;
        if (Input.GetKey(KeyCode.S)) 
            input.z -= 1f;
        if (Input.GetKey(KeyCode.D)) 
            input.x += 1f;
        if (Input.GetKey(KeyCode.A)) 
            input.x -= 1f;
        if (input.sqrMagnitude > 1f) 
            input.Normalize();
        Vector3 worldMove;
        if(Input.GetKey(KeyCode.LeftShift))
            worldMove = transform.TransformDirection(input) * sprintspeed;
        else 
            worldMove = transform.TransformDirection(input) * movespeed;
        v.x = worldMove.x;
        v.z = worldMove.z;
        rb.linearVelocity = v;
    }

    void RotateWithMouse(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        playerCamera.transform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }

    void Update(){
        if(!Button_functions.paused)
            RotateWithMouse();
        if(Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, floatHeight * 1.5f))
            jumopressed=true;
    }

    void FixedUpdate(){
        if(jumopressed==true){
            jump();
            jumopressed=false;
        }
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, floatHeight * 1.5f))
            move();
    }

}
