using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    public int score = 0; // ���������� �������
    public TextMeshProUGUI textScore;

    public float speed = 15.0f; // �������� ��������
    public float jumpHeight = 10.0f; // ������ ������

    private Rigidbody rb;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;

        UpdateBananaScore();
    }

    void Update()
    {
        // �������� ���� �� ������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ���������� ����������� ��������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ���������, ���� ���� ��������
        if (movement != Vector3.zero)
        {
            // ������������ �������� � ������� ��������
            transform.rotation = Quaternion.LookRotation(movement);

            // ����������� ������ ��������, ����� �������� � ������������ ������������ �� ���� �������
            movement = movement.normalized;

            // ���������� ��������
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // ��������� ������
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector3(0, CalculateJumpSpeed(), 0);
            isJumping = true;
        }
        if (isJumping)
        {
            // ����������� �������� �������
            rb.velocity += Vector3.down * 40 * Time.deltaTime;
        }
    }

    float CalculateJumpSpeed()
    {
        // ������������ �������� ������ �� ������ �������� ������
        float gravity = Physics.gravity.magnitude;
        float jumpSpeed = Mathf.Sqrt(2 * gravity * jumpHeight);
        return jumpSpeed;
    }

    public void BananaCollect()
    {
        score++;
        UpdateBananaScore();
    }

    void UpdateBananaScore()
    {
        textScore.text = score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
