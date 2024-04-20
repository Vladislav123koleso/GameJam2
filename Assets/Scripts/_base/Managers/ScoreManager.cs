using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : SingletonBase<ScoreManager>
{
    private int currentCountBananas = 0; // кол-во бананов
    private int allBananas;
    private static List<Banana> bananas = new List<Banana>();

    [SerializeField] private TextMeshProUGUI currentCountBananasText;
    [SerializeField] private TextMeshProUGUI allBananasText;

    [SerializeField] private GameObject BananasPanel;
    private bool CountBanananShow = false;

    [SerializeField] private GameObject notificationPanel;
    private bool notificationShow = false;

    private float timer = 0;
    [SerializeField] private float notificationPanelShowTime;
    [SerializeField] private float bananasPanelShowTime;

    private void Start()
    {
        notificationPanel.SetActive(false);
        BananasPanel.SetActive(false);
        allBananas = bananas.Count;
        currentCountBananasText.text = currentCountBananas.ToString();
        allBananasText.text = allBananas.ToString();
    }

    private void Update()
    {
        if (currentCountBananas >= allBananas)
        {
            if (!notificationShow)
            {
                notificationPanel.SetActive(true);
                timer += Time.deltaTime;
                if (timer >= notificationPanelShowTime)
                {
                    notificationShow = true;
                    notificationPanel.SetActive(false);
                    timer = 0;
                }
            }

        }

        if (CountBanananShow)
        {
            timer += Time.deltaTime;
            BananasPanel.SetActive(true);
            if (timer >= bananasPanelShowTime)
            {
                CountBanananShow = false;
                BananasPanel.SetActive(false);
                timer = 0;
            }
        }



    }

    public void AddCurrentCountBananas()
    {
        currentCountBananas++;
        CountBanananShow = true;
        timer = 0;
        updateBananaScore();
    }

    private void updateBananaScore()
    {
        currentCountBananasText.text = currentCountBananas.ToString();
    }

    public void AddBananaInListAllBanans(Banana banana)
    {
        bananas.Add(banana);
    }

}
