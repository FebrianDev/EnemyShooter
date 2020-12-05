using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject findOpponentPanel;

    private const string PlayerPrefNameKey = "PlayerName";
    void Start()
    {
        findOpponentPanel.SetActive(false);
        SetupInputField();
    }

    private void SetupInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefNameKey))
        {
            return;
        }
        string defaultName = PlayerPrefs.GetString(PlayerPrefNameKey);
        nameInputField.text = defaultName;
        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
       // continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        findOpponentPanel.SetActive(true);
        string playerName = nameInputField.text;
        PhotonNetwork.NickName = playerName;
        PlayerPrefs.SetString(PlayerPrefNameKey, playerName);
    }
}
