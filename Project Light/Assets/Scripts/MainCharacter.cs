using UnityEngine;
using UnityEngine.UI;

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

    public Rigidbody Rigidbody;
    public float SpeedSetting;
    public float Speed;
    public Vector3 ForwardDirection;

    public void Move(DancingPadControl.Orientation orientation, float directionAngle)
    {
        ForwardDirection = Quaternion.AngleAxis(45f * (int)orientation, Vector3.up) * 
                            new Vector3(0f, 0f, 1f);
        ForwardDirection = Quaternion.AngleAxis(directionAngle, Vector3.up) *
                           ForwardDirection;
        Rigidbody.AddForce(ForwardDirection * Speed);

    }

	void Start ()
	{
	    Rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () 
    {
	
	}
}
