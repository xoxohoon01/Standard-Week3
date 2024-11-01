using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraContainer;

    public Action inventory;

    private float moveSpeed = 10f;
    private float jumpForce = 5f;

    private Vector2 directionVector;
    private Rigidbody rigidbody;

    private Vector2 mouseDelta;
    private float lookSensitivity = 0.025f;
    private float currentRotationX;
    private float currentRotationY;

    private float minRotationY = -45f;
    private float maxnRotationY = 60f;

    private void OnMove(InputValue value)
    {
        directionVector = value.Get<Vector2>();
    }
    private void Move()
    {
        Vector3 moveVector = ((transform.forward * directionVector.y) + (transform.right * directionVector.x)).normalized * moveSpeed;
        moveVector.y = rigidbody.velocity.y;

        rigidbody.velocity = moveVector;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void OnLook(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
    }
    private void CameraLook()
    {
        currentRotationX += mouseDelta.x * lookSensitivity;
        transform.eulerAngles = new Vector3(0, currentRotationX, 0);

        currentRotationY += -mouseDelta.y * lookSensitivity;
        currentRotationY = Mathf.Clamp(currentRotationY, minRotationY, maxnRotationY);
        cameraContainer.transform.localEulerAngles = new Vector3(currentRotationY, 0, 0);
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Move메소드를 FixedUpdate에서 호출하는 이유는
        // FixedUpdate는 매 프레임마다 호출이 아닌, 일정한 간격으로 정해진 수만큼만 호출되기 때문에
        // FixedUpdate에서 이루어지는 변경사항은 고정적입니다.
        // 때문에 물리연산과 같은 작업을 할 때는 FixedUpdate가 적절합니다.
        Move();
    }

    private void LateUpdate()
    {
        // CameraLook메소드를 LateUpdate에서 호출하는 이유는
        // LateUpdate는 Update의 연산이 끝난 뒤에 호출되기 때문입니다.
        // 물리연산이 끝난 뒤 해당 좌표를 이용하는 작업이 필요한 경우 LateUpdate를 사용합니다.
        CameraLook();
    }
}
