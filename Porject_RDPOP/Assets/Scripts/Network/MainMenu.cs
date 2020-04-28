using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonTutorial.Menus
{
    public class MainMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject findOpponentPanel = null;
        [SerializeField] private GameObject waitingStatusPanel = null;
        [SerializeField] private TextMeshProUGUI waitingStatusText = null;

        private bool isConnecting = false;

        [SerializeField]
        private const string GameVersion = "0.1";
        [SerializeField]
        private const int MaxPlayersPerRoom = 2;

        public enum Device
        {
            Mobile,
            Pc
        }
        public Device device;
        bool mobile;
        bool pc;

        private void Start()
        {
            switch (device)
            {
                case Device.Mobile:
                    PlayerPrefs.SetInt("device",0);
                    break;

                case Device.Pc:
                    PlayerPrefs.SetInt("device", 1);
                    break;

                default:
                    break;
            }
        }

        private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

        public void FindOpponent()
        {
            isConnecting = true;

            waitingStatusPanel.SetActive(true);

            waitingStatusText.text = "Searching...";

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
            Debug.Log("Connected To Master");

            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            waitingStatusPanel.SetActive(false);
            findOpponentPanel.SetActive(true);

            Debug.Log($"Disconnected due to: {cause}");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("No clients are waiting for an opponent, creating a new room");

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Client successfully joined a room");

            CounterPlayerT.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + MaxPlayersPerRoom;
            NameRoomT.text = PhotonNetwork.CurrentRoom.Name;

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
             
            if (playerCount != MaxPlayersPerRoom)
            {
                waitingStatusText.text = "Waiting For Opponent";
                Debug.Log("Client is waiting for an opponent");
            }
            else
            {
                waitingStatusText.text = "Opponent Found";
                Debug.Log("Match is ready to begin");
            }
            /*
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;

                waitingStatusText.text = "Opponent Found";
                Debug.Log("Match is ready to begin");

                PhotonNetwork.LoadLevel("SampleScene");
            }*/
        }

        public Text CounterPlayerT;
        public Text NameRoomT;
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {

            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;

                waitingStatusText.text = "Opponent Found";
                Debug.Log("Match is ready to begin");

                PhotonNetwork.LoadLevel("SampleScene");
            }
        }

        public void OnClicktoDisconnect()
        {
            PhotonNetwork.LeaveRoom();
            waitingStatusText.text = "";

        }
    }
}
