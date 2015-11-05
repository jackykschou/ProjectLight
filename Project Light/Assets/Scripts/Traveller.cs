using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class Traveller : NetworkBehaviour 
    {
        void Update()
        {
            if (!CustomNetworkManager.GameStarted)
            {
                return;
            }

            Camera.main.transform.position = 
                new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

            float horizontalSpeed = Input.GetAxis("Horizontal");
            float verticalSpeed = Input.GetAxis("Vertical");

            transform.Translate(horizontalSpeed , verticalSpeed, 0f);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            
        }
    }
}
