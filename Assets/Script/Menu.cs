using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject panel, menuShop;
    public Text textWin;
    public Button btnRetry;

    public static bool isPause;
    private void Start()
    {
        isPause = false;
        panel = GameObject.FindWithTag("Panel");
        panel.SetActive(false);
        Time.timeScale = 1f;
        WinCondition.win = false;
    }

    void Update()
    {
        if (WinCondition.win)
        {
            textWin.text = WinCondition.winGame+" Win";
            panel.SetActive(true);
            Time.timeScale = 0f;
            menuShop.SetActive(false);
        }

    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Shop()
    {
        isPause = true;
        Time.timeScale = 0f;
        menuShop.SetActive(true);
    }

    public void Close()
    {
        isPause = false;
        Time.timeScale = 1f;
        menuShop.SetActive(false);
    }
}
