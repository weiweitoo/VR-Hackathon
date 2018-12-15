using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerFly : MonoBehaviour {

    public float walkSpeed = 2;
    public float runSpeed = 4;
    public float gravity = 9.8f;
    public float lookSpeed = 45;
    public bool invertY = true;
    public Transform cameraPivot;

    float speed;
    Vector3 movement, finalMovement;
    CharacterController controller;
    Quaternion targetPivotRotation;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        targetPivotRotation = Quaternion.identity;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTranslation();
        UpdateLookRotation();
    }

    void UpdateLookRotation()
    {
        var x = Input.GetAxis("Mouse Y");
        var y = Input.GetAxis("Mouse X");

        x *= invertY ? -1 : 1;

        targetPivotRotation = cameraPivot.transform.rotation * Quaternion.AngleAxis(x * lookSpeed * Time.deltaTime, Vector3.right) * Quaternion.AngleAxis(y * lookSpeed * Time.deltaTime, Vector3.up);
        cameraPivot.transform.rotation = Quaternion.Slerp(cameraPivot.transform.rotation, targetPivotRotation, Time.deltaTime * 15);
        float z = cameraPivot.transform.eulerAngles.z;
        cameraPivot.transform.Rotate(0, 0, -z);
    }


    void UpdateTranslation()
    {
        if (true)
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var run = Input.GetKey(KeyCode.LeftShift);

            var translation = new Vector3(x, 0, z);
            speed = run ? runSpeed : walkSpeed;
            movement = cameraPivot.transform.TransformDirection(translation * speed);
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
        finalMovement = Vector3.Lerp(finalMovement, movement, Time.deltaTime * 25);
        controller.Move(finalMovement * Time.deltaTime);
    }
}
