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




    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        CameraRotate();

        Cursor.visible = false;                     
        Cursor.lockState = CursorLockMode.Locked;

        //if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        //{
        //    isWalking = true; 
        //}
        //if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        //{
        //    isWalking = false;
        //}
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
        //if (originPos != transform.position)
        //{
        //    isWalking = true;
        //}
        //if (originPos == transform.position)
        //{
        //    isWalking = false;
        //}
        head.SetBool("isWalking", isWalking);
        #region

        //float xInput = Input.GetAxisRaw("Horizontal");

        //if (isKeyPressed && Mathf.Abs(xInput) != 1)
        //{
        //    isKeyPressed = false;
        //}
        //if (!isKeyPressed && xInput != 0)
        //{
        //    isKeyPressed = true;
        //    if (xInput > 0)
        //    {
        //        StartCoroutine(PlayerRotation(1));
        //    }
        //    if (xInput < 0)
        //    {
        //        StartCoroutine(PlayerRotation(-1));
        //    }

        //Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //characterController.Move(movement * Time.deltaTime * moveSpeed);
        //head.SetBool("isWalking", movement.x != 0 || movement.z != 0);
        //Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
        //transform.Rotate(rotation);
        #endregion
    }

    IEnumerator PlayerRotation(float h)
    {
        angleY += 90 * h;
        angleY %= 360;
        transform.rotation = Quaternion.Euler(0, angleY, 0);
        yield return null;
    }
}
