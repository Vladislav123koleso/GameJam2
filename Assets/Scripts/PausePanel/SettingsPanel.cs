using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject checkCustom;
    private bool checkDraw = false;

    [SerializeField] private GameObject checkFullScreen;
    


    private void Start()
    {
        gameObject.SetActive(false);

        if (!Screen.fullScreen)
        {
            checkFullScreen.SetActive(false);
        }
        else
        {
            checkFullScreen.SetActive(true);
        }

        if (ScoreManager.Instance.SecretCustomOpen != true)
        {
            checkCustom.SetActive(false);
        }
    }
    private void Update()
    {
        if (!checkDraw)
        {
            if (ScoreManager.Instance.SecretCustomOpen == true)
            {
                checkCustom.SetActive(true);
                checkDraw = true;
            }
        }
    }

    public void FullScreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
            checkFullScreen.SetActive(true);
        }
        else
        {
            Screen.fullScreen = false;
            checkFullScreen.SetActive(false);
        }
    }

    public void closePanel()
    {
        gameObject.SetActive(false);
    }
}
