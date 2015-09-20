using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class CustomNetworkManager : NetworkManager
    {
        public static CustomNetworkManager Instance;

        public bool IsServer;
        public GameObject Guider;
        public GameObject GuiderConroller;
        public GameObject GuiderView;
        public GameObject Traveller;

        void Awake()
        {
            Instance = FindObjectOfType<CustomNetworkManager>();
        }

        public override void OnStartServer()
        {
            Instantiate(Traveller);
            IsServer = true;
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            if (!IsServer)
            {
                var guiderConroller = Instantiate(GuiderConroller);
                var guiderView = Instantiate(GuiderView);
            }
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            Debug.Log("conn.address  " + conn.address);
            Debug.Log("networkAddress  " + networkAddress);
            if (conn.address != "localServer")
            {
                var guilder = Instantiate(Guider);
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
        }
    }
}
