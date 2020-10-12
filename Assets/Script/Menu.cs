using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject panel;
    public Text textWin;
    public Button btnRetry;

    private void Start()
    {
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
        }

    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
