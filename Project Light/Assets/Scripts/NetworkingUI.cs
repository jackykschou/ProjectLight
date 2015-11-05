using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NetworkingUI : MonoBehaviour
    {
        public InputField IpAddressInput;

        public void SetIpAddress(string address)
        {
            CustomNetworkManager.Instance.networkAddress = address;
        }

        void SetPort()
        {
            CustomNetworkManager.Instance.networkPort = 7777;
        }

        public void StartAsClient()
        {
            SetIpAddress(IpAddressInput.text);
            SetPort();
            CustomNetworkManager.Instance.StartClient();
        }

        public void StartAsHost()
        {
            SetIpAddress(IpAddressInput.text);
            SetPort();
            CustomNetworkManager.Instance.StartHost();
        }
    }
}
