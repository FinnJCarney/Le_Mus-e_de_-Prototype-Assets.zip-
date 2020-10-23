using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    CharacterController cc;
    Camera cam;

    bool active;

    Vector2 mouseAxis;
    public float mouseSensitivity;
    float vertCam;

    public float movementSpeed;
    Vector3 velocity;
    bool forward;
    bool back;
    bool left;
    bool right;

    public bool onGround;
    public float gravity;



    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        active = false;
    }

    void Update()
    {
        mouseAxis = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * mouseSensitivity);

        if(Input.GetKeyDown(KeyCode.W))
        {
            forward = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            back = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            back = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraControls();
        if (active)
        {
            PlayerMovement();
        }
    }

    void CameraControls()
    {
        transform.Rotate(0, mouseAxis.x, 0);

        vertCam -= mouseAxis.y;
        vertCam = Mathf.Clamp(vertCam, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(vertCam, 0, 0);
    }

    void PlayerMovement()
    {
        Vector3 movement = Vector3.zero;

        if(forward)
        {
            movement += (transform.forward * movementSpeed);
        }
        if (back)
        {
            movement -= (transform.forward * movementSpeed);
        }
        if (left)
        {
            movement -= (transform.right * movementSpeed);
        }
        if (right)
        {
            movement += (transform.right * movementSpeed);
        }

        velocity = Vector3.Lerp(velocity, Vector3.ClampMagnitude(movement, movementSpeed), 0.5f);

        if(!onGround)
        {
            velocity = Vector3.Lerp(velocity, Vector3.down * gravity, 0.05f);
        }
        else
        {
            velocity = new Vector3(velocity.x, 0, velocity.z);
        }

        cc.Move(velocity);
    }

    public void Activate()
    {
        active = true;
    }

    public void OnGround()
    {
        onGround = true;
    }

    public void OffGround()
    {
        onGround = false;
    }
}
