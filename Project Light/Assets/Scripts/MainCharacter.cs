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

    public AudioClip CollisionSound;
    public AudioClip OuchSound;
    public AudioSource AudioSource3D1;
    public AudioSource AudioSource3D2;
    public AudioSource AudioSource3D3;
    public AudioSource AudioSource3D4;

    public Rigidbody Rigidbody;
    public float SpeedSetting;
    public float Speed;
    public Vector3 ForwardDirection;

    public void Move(DancingPadControl.Orientation orientation, float directionAngle)
    {
        var dir = Quaternion.AngleAxis(45f * (int)orientation, Vector3.up) * 
                            new Vector3(0f, 0f, 1f);
        dir = Quaternion.AngleAxis(directionAngle, Vector3.up) *
                           dir;
        Rigidbody.AddForce(dir * Speed);

    }

	void Start ()
	{
	    Rigidbody = GetComponent<Rigidbody>();
	}

    public void CastForObstacles()
    {
        var layerMask = 1 << 10;
        if (Physics.Raycast(transform.position, ForwardDirection, 5f, layerMask) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(-10f, Vector3.up) * ForwardDirection, 5f, layerMask) ||
            Physics.Raycast(transform.position, Quaternion.AngleAxis(10f, Vector3.up) * ForwardDirection, 5f, layerMask))
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
