using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    //public GameObject settingsPanel;
    private void Start()
    {
        pausePanel.SetActive(false);
        //settingsPanel.SetActive(false);

    }


    public void continueButton()
    {
        // ���������� ����
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void settingsButton()
    {
        // �������� ��������
    }

    public void exitButton()
    {
        // ����� � ������� ����
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        //  ���� ����� ESC �� ������������� ����
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
