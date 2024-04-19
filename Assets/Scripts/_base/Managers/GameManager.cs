using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;

    public static GameManager Instance { get; private set; }

    private bool canFlipCard = true; // ‘лаг,можно ли переворачивать карты
    private List<cardLogic> flippedCards = new List<cardLogic>(); // —писок перевернутых карт

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ”ничтожаем дублирующиес€ экземпл€ры
        }
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

    }

    public bool CanFlipCard()
    {
        return canFlipCard;
    }

    public void SetCanFlipCard(bool value)
    {
        canFlipCard = value;
    }


    // ћетод дл€ добавлени€ перевернутой карты в список
    public void AddFlippedCard(cardLogic card)
    {
        flippedCards.Add(card);
    }


    //-----------
    public void continueButton()
    {
        // продолжаем игру
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void settingsButton()
    {
        // открытие настроек
    }

    public void exitButton()
    {
        // выход в главное меню
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        //  если нажат ESC мы останавливаем игру
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
