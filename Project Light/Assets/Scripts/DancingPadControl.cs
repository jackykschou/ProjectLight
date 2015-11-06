using UnityEngine;
using UnityEngine.UI;

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

    public enum Orientation
    {
        Up = 0,
        Down = 4,
        Left = 6,
        Right = 2,
        UpLeft = 7,
        UpRight = 1,
        DownLeft = 5,
        DownRight = 3
    }

    public Text OrientationText;
    public Orientation CurrentOrientation;
    public float ButtonCooldown = 0.2f;
    public float CurrentCooldown = 0f;

	void Update () 
    {
        CurrentCooldown += Time.deltaTime;

	    if (Input.GetKeyDown(KeyCode.Keypad8))
	    {
	        CurrentOrientation = Orientation.Up;
            UpdateOrientation();
	    }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            CurrentOrientation = Orientation.Down;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            CurrentOrientation = Orientation.Left;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            CurrentOrientation = Orientation.Right;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            CurrentOrientation = Orientation.UpLeft;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            CurrentOrientation = Orientation.UpRight;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            CurrentOrientation = Orientation.DownLeft;
            UpdateOrientation();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            CurrentOrientation = Orientation.DownRight;
            UpdateOrientation();
        }

	    if (CoolDownFinished())
	    {
	        if (Input.GetButtonDown("Up"))
	        {
                MainCharacter.Instance.Move(CurrentOrientation, 0f);
                ResetCooldown();
	        }
            if (Input.GetButtonDown("Down"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 180f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("Left"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 270f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("Right"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 90f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("UpLeft"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 315f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("UpRight"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 45f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("DownLeft"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 135f);
                ResetCooldown();
            }
            if (Input.GetButtonDown("DownRight"))
            {
                MainCharacter.Instance.Move(CurrentOrientation, 215f);
                ResetCooldown();
            }
	    }
    }

    public void UpdateOrientation()
    {
        OrientationText.text = "Orientation:\n" + CurrentOrientation;
        MainCharacter.Instance.ForwardDirection = Quaternion.AngleAxis(45f * (int)CurrentOrientation, Vector3.up) 
            * new Vector3(0f, 0f, 1f);
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
