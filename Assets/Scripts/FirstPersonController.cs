using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam;

    private CharacterController playerConroller;

    private float HorizontalSpeed = 1.5F;
    private float VerticalSpeed = 1.5F;
    private float MovementSpeed = 3.2F;

    private Vector3 MoveTo = Vector3.zero;
    private Quaternion CharRot;
    private Quaternion CamRot;

    private float mouseX;
    private float mouseY;

    private float horizontal;
    private float vertical;

    private float height = 1.8f;


    private void Start()
    {
        playerConroller = GetComponent<CharacterController>();

        CharRot = playerConroller.transform.localRotation;
        CamRot = firstPersonCam.transform.localRotation;

        HightCheck();

    }

    void Update()
    {
        // Mouse imput
        mouseX = Input.GetAxis("Mouse Y") * HorizontalSpeed;
        mouseY = Input.GetAxis("Mouse X") * VerticalSpeed;

        //Keyboard imput
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
    }

    private void FixedUpdate()
    {
        MouseInputMove(mouseX, mouseY);
        KeyboardInputMove(horizontal, vertical);

        HightCheck();
    }

    void MouseInputMove(float x, float y)
    {
        CharRot *= Quaternion.Euler(0f, y, 0f);
        CamRot *= Quaternion.Euler(-x, 0f, 0f);
        CamRot = ClampRotationAroundXAxis(CamRot);

        // playerConroller.transform.localRotation = Quaternion.Slerp(playerConroller.transform.localRotation, CharRot, horizontalSpeed * Time.deltaTime);
        // firstPersonCam.transform.localRotation = Quaternion.Slerp(firstPersonCam.transform.localRotation, CamRot, horizontalSpeed * Time.deltaTime);

        playerConroller.transform.localRotation = CharRot;
        firstPersonCam.transform.localRotation = CamRot;

    }

    void KeyboardInputMove(float hor, float vert)
    {

        Vector3 desiredMove = transform.forward * vert + transform.right * hor;
        MoveTo.x = desiredMove.x * MovementSpeed;
        MoveTo.z = desiredMove.z * MovementSpeed;
        MoveTo.y = 0f;

        playerConroller.Move(MoveTo * Time.deltaTime);
    }

    void HightCheck()
    {
        if (gameObject.transform.position.y != height)
            gameObject.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -90f, 90f);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

 
}



