﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float speed = 0.0f;
    public float rotateSpeed = 0.0f;
    public float hoverHeight = 0.0f;
    public float heightAdjustFactor = 1.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private CharacterController controller;
    private GameObject mainCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = GameObject.FindWithTag("MainCamera");
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

        var hit = new RaycastHit();
        var terrain = Physics.Raycast(transform.position, -Vector3.up, out hit);
        var position = transform.position;

        var heightAdjustment = new Vector3(
            position.x,
            Mathf.Lerp(position.y, hit.point.y + hoverHeight, Time.deltaTime * heightAdjustFactor),
            position.z
        );
        transform.position = heightAdjustment;

        yaw += rotateSpeed * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        pitch += rotateSpeed * Input.GetAxis("Mouse Y");
        mainCamera.transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
    }
}
