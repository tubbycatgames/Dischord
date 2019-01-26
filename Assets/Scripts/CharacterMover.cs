using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float speed = 0.0f;
    public float rotateSpeed = 0.0f;

    private float yaw = 0.0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
        );
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;
        controller.Move(moveDirection * Time.deltaTime);

        yaw += rotateSpeed * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
