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
            rb.velocity = new Vector3(0, 10, 0);
            isJumping = true;
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
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        
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
