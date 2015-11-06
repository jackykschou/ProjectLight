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
	            ResetCooldown();
	        }
	        if (remote.Button.b)
	        {
	            MainCharacter.Instance.CastForObstacles();
	            ResetCooldown();
	        }
	        if (remote.Button.d_up)
	        {
	            ResetCooldown();
	        }
	        if (remote.Button.d_down)
	        {
	            ResetCooldown();
	        }
	        if (remote.Button.d_left)
	        {
	            ResetCooldown();
	        }
	        if (remote.Button.d_right)
	        {
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
