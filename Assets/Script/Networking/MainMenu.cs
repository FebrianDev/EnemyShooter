using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    private bool isConnecting = false;
    private const string GameVersion = "0.1";
    private const int MaxPlayersRoom = 2;
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void FindOpponent()
    {
        isConnecting = true;
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatusText.text = "Searching";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to master");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to : {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No Clients are waiting for an opponent, creating a new room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client successfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if(playerCount != MaxPlayersRoom)
        {
            waitingStatusText.text = "Waiting for Opponent";
            Debug.Log("Client is waiting for a opponent");
        }
        else
        {
            waitingStatusText.text = "opponent found";
            Debug.Log("Matching is ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            Debug.Log("Match Ready to Begin");
            waitingStatusText.text = "Opponent found";

            PhotonNetwork.LoadLevel("Multiplayer");
        }
    }
}
