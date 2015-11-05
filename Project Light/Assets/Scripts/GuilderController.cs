using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class GuilderController : NetworkBehaviour
    {
        public AudioClip PianoC;

        public static GuilderController Instance;
        void Start()
        {
            Instance = FindObjectOfType<GuilderController>();
        }

        void Update () 
        {
            if (!isLocalPlayer)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                PlayNote();
            }

        }

        void PlayNote()
        {
            AudioSource.PlayClipAtPoint(PianoC, Vector3.zero);
        }
    }
}
