using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public int score = 0; // кол-во бананов
    public TextMeshProUGUI textScore;

    float speed = 15.0f; // скорость
    float rotationSpeed = 120.0f; // скорость поворота

    public float jumpHeight = 10.0f; // высота прыжка

    Rigidbody rb;

    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;

        updateBananaScore();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector3(0, CalculateJumpSpeed(), 0);
            isJumping = true;
        }
        if (isJumping)
        {
            // Увеличиваем скорость падения
            rb.velocity += Vector3.down * 40 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Плавный поворот влево
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Плавный поворот вправо
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }

    }

    float CalculateJumpSpeed()
    {
        // Рассчитываем скорость прыжка на основе заданной высоты
        float gravity = Physics.gravity.magnitude;
        float jumpSpeed = Mathf.Sqrt(2 * gravity * jumpHeight);
        return jumpSpeed;
    }


    public void BananaCollect()
    {
        score++;
        updateBananaScore();
    }

    void updateBananaScore()
    {
        textScore.text = "" + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
