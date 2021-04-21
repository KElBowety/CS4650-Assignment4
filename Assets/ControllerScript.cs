using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform FPCamera;
    [SerializeField] float mouseSensitivity;
    CharacterController controller;
    [SerializeField] float defaultSpeed;
    [SerializeField] float gravity = -9.8f;
    private float cameraPitch;
    private float speed;
    private float velocityY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateKeyboard();
    }

    void UpdateMouseLook()
    {
        Vector2 mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;
        cameraPitch -= mouse.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        transform.Rotate(Vector3.up * mouse.x);
        FPCamera.localEulerAngles = Vector3.right * cameraPitch;
    }

    void UpdateKeyboard()
    {
        speed = Input.GetKey(KeyCode.LeftShift) ? 1.5f * defaultSpeed : defaultSpeed;
        Vector2 keyboard = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
        if (controller.isGrounded)
        {
            velocityY = 0f;
        }
        velocityY += gravity * Time.deltaTime;
        Vector3 move = (transform.right * keyboard.x * speed + transform.forward * keyboard.y * speed) + Vector3.up * velocityY;
        controller.Move(move * Time.deltaTime);
    }
}