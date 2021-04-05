using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam;
    private CharacterController playerConroller;

    public float HorizontalSpeed = 1f;
    public float VerticalSpeed = 1f;
    public float MovementSpeed = 3f;

    private Vector3 MoveTo = Vector3.zero;
    private Quaternion CharRot;
    private Quaternion CamRot;

    private float height = 1.8f;

    private void Awake()
    {
        gameObject.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    private void Start()
    {
        playerConroller = GetComponent<CharacterController>();
        CharRot = playerConroller.transform.localRotation;
        CamRot = firstPersonCam.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse imput
        float mouseX = Input.GetAxis("Mouse Y") * HorizontalSpeed;
        float mouseY = Input.GetAxis("Mouse X") * VerticalSpeed;

        CharRot *= Quaternion.Euler(0f, mouseY, 0f);
        CamRot *= Quaternion.Euler(-mouseX, 0f, 0f);
        CamRot = ClampRotationAroundXAxis(CamRot);

        // playerConroller.transform.localRotation = Quaternion.Slerp(playerConroller.transform.localRotation, CharRot, horizontalSpeed * Time.deltaTime);
        // firstPersonCam.transform.localRotation = Quaternion.Slerp(firstPersonCam.transform.localRotation, CamRot, horizontalSpeed * Time.deltaTime);

        playerConroller.transform.localRotation = CharRot;
        firstPersonCam.transform.localRotation = CamRot;

        //Keyboard imput

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");  

        //Vector2 InputParam = new Vector2(horizontal, vertical);
        //Vector3 desiredMove = transform.forward * InputParam.y + transform.right * InputParam.x;

        Vector3 desiredMove = transform.forward * vertical + transform.right * horizontal;
        MoveTo.x = desiredMove.x * MovementSpeed;
        MoveTo.z = desiredMove.z * MovementSpeed;
        MoveTo.y = 0f;

        playerConroller.Move(MoveTo * Time.deltaTime);

        //playerConroller.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);

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



