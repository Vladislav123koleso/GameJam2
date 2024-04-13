using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

    }


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
