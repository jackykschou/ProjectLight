using UnityEngine;
using WiimoteApi;

public class WiiMoteController : MonoBehaviour
{
    public static WiiMoteController _instance;
    public static WiiMoteController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WiiMoteController>();
            }
            return _instance;
        }
    }

    public bool ButtonA;
    public bool ButtonB;
    public bool UpArrow;
    public bool DownArrow;
    public bool LeftArrow;
    public bool RightArrow;

    public float ButtonCooldown = 0.2f;
    public float CurrentCooldown = 0f;

    void Start()
    {
        WiimoteManager.FindWiimotes();
        var remote = WiimoteManager.Wiimotes[0];
        remote.SendPlayerLED(true, false, false, true);
    }

	void Update ()
	{
	    if (!WiimoteManager.HasWiimote())
	    {
	        return;
	    }

	    CurrentCooldown += Time.deltaTime;
        ButtonA = false;
        ButtonB = false;
        UpArrow = false;
        DownArrow = false;
        LeftArrow = false;
        RightArrow = false;

	    var remote = WiimoteManager.Wiimotes[0];

        int ret;
        do
        {
            ret = remote.ReadWiimoteData();
        } while (ret > 0);
        if (CoolDownFinished())
        {
            if (remote.Button.a)
            {
                ButtonA = true;
                ResetCooldown();
            }
            if (remote.Button.b)
            {
                ButtonB = true;
                ResetCooldown();
            }
            if (remote.Button.d_up)
            {
                UpArrow = true;
                ResetCooldown();
            }
            if (remote.Button.d_down)
            {
                DownArrow = true;
                ResetCooldown();
            }
            if (remote.Button.d_left)
            {
                LeftArrow = true;
                ResetCooldown();
            }
            if (remote.Button.d_right)
            {
                RightArrow = true;
                ResetCooldown();
            }
        }
	}

    bool CoolDownFinished()
    {
        return true;
    }

    void ResetCooldown()
    {
        CurrentCooldown = 0f;
    }
}
