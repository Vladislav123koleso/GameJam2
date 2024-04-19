using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public int score = 0; // кол-во бананов
    public TextMeshProUGUI textScore;

    [SerializeField] private float speed = 150.0f; // скорость
    [SerializeField] private float rotationSpeed = 120.0f; // скорость поворота

    [SerializeField] private float jumpForce = 10.0f; // высота прыжка

    Rigidbody rb;

    public Camera playerCamera; // Ссылка на камеру
    public float cameraRotationSpeed = 2.0f; // Скорость вращения камеры

    private bool isJumping;
    private bool isMooving;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        isJumping = false;
        jumpForce *= rb.mass;
        updateBananaScore();
    }

    void FixedUpdate()
    {
        isMooving = false;

        // Вращение камеры
        float mouseX = Input.GetAxis("Mouse X") * cameraRotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * cameraRotationSpeed;

        float movementDir = Input.GetAxisRaw("Vertical");
        float rotatiomDir = Input.GetAxisRaw("Horizontal");

        Vector3 movement = transform.forward * movementDir * speed;
        Vector3 gravity = new Vector3(0, rb.velocity.y, 0);

        if (Input.GetAxisRaw("Jump") > 0 && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            animator.SetTrigger("jump");
        }

        if (movementDir != 0)
        {
            animator.SetBool("run", true);
        }
        else animator.SetBool("run", false);

        rb.velocity = movement + gravity;
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * rotatiomDir * rotationSpeed);

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
