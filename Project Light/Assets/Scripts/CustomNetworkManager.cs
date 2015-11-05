using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class CustomNetworkManager : NetworkManager
    {
        public static CustomNetworkManager Instance;
        public static bool GameStarted = false;
        public GameObject NetworkSettingUi;

        public bool IsServer;

        //Both
        public GameObject GameManager;
        public GameObject Guider;
        public GameObject GuiderController;
        public GameObject GuiderView;
        public GameObject Traveller;
        public GameObject World;

        public int NumberOfPlayer = 0;

        void Awake()
        {
            Instance = FindObjectOfType<CustomNetworkManager>();
            ClientScene.RegisterPrefab(GameManager);
            ClientScene.RegisterPrefab(Guider);
            ClientScene.RegisterPrefab(GuiderController);
            ClientScene.RegisterPrefab(GuiderView);
            ClientScene.RegisterPrefab(Traveller);
        }

        public override void OnStartServer()
        {
            Instantiate(Traveller);
            IsServer = true;
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            NetworkSettingUi.SetActive(false);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            if (conn.address != "localServer")
            {
                var guilder = Instantiate(Guider);
            }

            NumberOfPlayer++;
            Debug.Log("NumberOfPlayer");
            World.SetActive(true);
            if (NumberOfPlayer == 2)
            {
                GameStarted = true;
                var guiderConroller = Instantiate(GuiderController);
                NetworkServer.Spawn(guiderConroller);
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
        }
    }
}
