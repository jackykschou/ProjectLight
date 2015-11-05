using UnityEngine;

public class DancingPadControl : MonoBehaviour 
{
    public static DancingPadControl _instance;
    public static DancingPadControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DancingPadControl>();
            }
            return _instance;
        }
    }

    public float ButtonCooldown = 0.2f;
    public float CurrentCooldown = 0f;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public bool UpLeft;
    public bool UpRight;
    public bool DownLeft;
    public bool DownRight;

	void Update () 
    {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
        UpLeft = false;
        UpRight = false;
        DownLeft = false;
        DownRight = false;

        CurrentCooldown += Time.deltaTime;

	    if (CoolDownFinished())
	    {
	        if (Input.GetButtonDown("Up"))
	        {
	            Up = true;
                ResetCooldown();
	        }
            if (Input.GetButtonDown("Down"))
            {
                Down = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("Left"))
            {
                Left = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("Right"))
            {
                Right = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("UpLeft"))
            {
                UpLeft = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("UpRight"))
            {
                UpRight = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("DownLeft"))
            {
                DownLeft = true;
                ResetCooldown();
            }
            if (Input.GetButtonDown("DownRight"))
            {
                DownRight = true;
                ResetCooldown();
            }
	    }
    }

    bool CoolDownFinished()
    {
        return CurrentCooldown >= ButtonCooldown;
    }

    void ResetCooldown()
    {
        CurrentCooldown = 0f;
    }
}
