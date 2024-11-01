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
        // Move�޼ҵ带 FixedUpdate���� ȣ���ϴ� ������
        // FixedUpdate�� �� �����Ӹ��� ȣ���� �ƴ�, ������ �������� ������ ����ŭ�� ȣ��Ǳ� ������
        // FixedUpdate���� �̷������ ��������� �������Դϴ�.
        // ������ ��������� ���� �۾��� �� ���� FixedUpdate�� �����մϴ�.
        Move();
    }

    private void LateUpdate()
    {
        // CameraLook�޼ҵ带 LateUpdate���� ȣ���ϴ� ������
        // LateUpdate�� Update�� ������ ���� �ڿ� ȣ��Ǳ� �����Դϴ�.
        // ���������� ���� �� �ش� ��ǥ�� �̿��ϴ� �۾��� �ʿ��� ��� LateUpdate�� ����մϴ�.
        CameraLook();
    }
}
