using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private bool isWalking = false;
    public Animator head; // 걷는 효과 애니메이션 사용
    public float moveSpeed = 4f;
    private CharacterController characterController;


    private float angleY;
    private bool isKeyPressed;

    Vector3 dir;
    private Vector3 originPos;

    private float rotateY;
    public float mouseSpeed = 5f;
    public Transform front;

    float mouseX = 0;

    public Transform respawnPos;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Events();
    }

    public void MouseSpeed(float c)
    {
        mouseSpeed = c;
    }

    private void Events()
    {
        EventManager.instance.AddEvent("Reset", p =>
        {
            transform.position = respawnPos.position;
        });
    }

    private void Update()
    {
        Movement();
        CameraRotate();

        originPos = transform.position;
    }

    private void CameraRotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        rotateY += mouseX * mouseSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotateY, 0);
    }

    private void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        dir = new Vector3(inputX, 0, inputZ);

        characterController.Move(transform.TransformDirection(dir.normalized) * moveSpeed * Time.deltaTime);
        if (dir != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        EventManager.instance.SendEvent("Sound :: isWalking", isWalking);

        head.SetBool("isWalking", isWalking);
    }
}
