using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    public int score = 0; // Количество бананов
    public TextMeshProUGUI textScore;

    public float speed = 15.0f; // Скорость движения
    public float jumpHeight = 10.0f; // Высота прыжка

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
        // Получаем ввод от игрока
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Определяем направление движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Проверяем, если есть движение
        if (movement != Vector3.zero)
        {
            // Поворачиваем персонаж в сторону движения
            transform.rotation = Quaternion.LookRotation(movement);

            // Нормализуем вектор движения, чтобы движение в диагональных направлениях не было быстрее
            movement = movement.normalized;

            // Перемещаем персонаж
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // Обработка прыжка
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector3(0, CalculateJumpSpeed(), 0);
            isJumping = true;
        }
        if (isJumping)
        {
            // Увеличиваем скорость падения
            rb.velocity += Vector3.down * 40 * Time.deltaTime;
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
