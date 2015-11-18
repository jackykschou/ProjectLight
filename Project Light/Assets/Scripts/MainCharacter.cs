using System.Collections;
using UnityEngine;
using WiimoteApi;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter _instance;
    public static MainCharacter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MainCharacter>();
            }
            return _instance;
        }
    }

    public int RemainingCoinCount;
    public AudioClip StartGameSound;
    public AudioClip CollisionSound;
    public AudioClip OuchSound;
    public AudioClip WinSound;
    public AudioSource AudioSource3D1;
    public AudioSource AudioSource3D2;
    public AudioSource AudioSource3D3;
    public AudioSource AudioSource3D4;

    public Rigidbody Rigidbody;
    public static float Speed;
    public Vector3 ForwardDirection = Vector3.up;

    public void CollectCoin()
    {
        RemainingCoinCount--;
        if (RemainingCoinCount == 0)
        {
            AudioSource.PlayClipAtPoint(WinSound, Camera.main.transform.position);
        }
    }

    public void Move(DancingPadControl.Orientation orientation, float directionAngle)
    {
        //var dir = Quaternion.AngleAxis(45f * (int)orientation, Vector3.up) * 
        //                    new Vector3(0f, 0f, 1f);
        var dir = Quaternion.AngleAxis(directionAngle, Vector3.up) *
                           new Vector3(0f, 0f, 1f);
        Rigidbody.AddForce(dir * Speed);
    }

	void Start ()
	{
	    Rigidbody = GetComponent<Rigidbody>();
        AudioSource.PlayClipAtPoint(StartGameSound, Camera.main.transform.position);
	}

    public void CastForObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, ForwardDirection, out hit, 5f) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(-10f, Vector3.up) * ForwardDirection, out hit, 5f) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(10f, Vector3.up) * ForwardDirection, out hit, 5f))
        {
            if (hit.collider != null && hit.collider.gameObject.GetComponent<SoundInteractable>() != null)
            {
                AudioSource.PlayClipAtPoint(hit.collider.gameObject.GetComponent<SoundInteractable>().SoundEffect
                , Camera.main.transform.position);
                StartCoroutine(Rumble());
                return;
            }
        }

        var obstacleLayerMask = 1 << 10;
        if (Physics.Raycast(transform.position, ForwardDirection, 5f, obstacleLayerMask) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(-10f, Vector3.up) * ForwardDirection, 5f, obstacleLayerMask) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(10f, Vector3.up) * ForwardDirection, 5f, obstacleLayerMask))
        {
            AudioSource.PlayClipAtPoint(CollisionSound, Camera.main.transform.position);
            StartCoroutine(Rumble());
        }
    }
	
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(OuchSound, Camera.main.transform.position);
            StartCoroutine(Rumble());
        }
    }

    IEnumerator Rumble()
    {
        var remote = WiimoteManager.Wiimotes[0];
        remote.RumbleOn = true;
        remote.SendStatusInfoRequest();
        yield return new WaitForSeconds(0.5f);
        remote.RumbleOn = false;
        remote.SendStatusInfoRequest();
    }
}
