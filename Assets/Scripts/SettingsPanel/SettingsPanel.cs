using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject check;
    private bool checkDraw = false;

    private void Start()
    {
        gameObject.SetActive(false);

        if (ScoreManager.Instance.SecretCustomOpen != true)
        {
            check.SetActive(false);
        }
    }
    private void Update()
    {
        if (!checkDraw)
        {
            if (ScoreManager.Instance.SecretCustomOpen == true)
            {
                check.SetActive(true);
                checkDraw = true;
            }
        }

    }

    public void closePanel()
    {
        gameObject.SetActive(false);
    }
}
