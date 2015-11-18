using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text SpeedText;

    void Start()
    {
        MainCharacter.Speed = 350f;
        UpdateSpeedText();
    }

    public void UpdateSpeedText()
    {
        SpeedText.text = "Movement Speed: " 
            + MainCharacter.Speed;
    }

    public void PlusSpeed()
    {
        MainCharacter.Speed += 10f;
        UpdateSpeedText();
    }

    public void MinusSpeed()
    {
        MainCharacter.Speed -= 10f;
        UpdateSpeedText();
    }

    public AudioClip StartGameSound;

    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(StartGameSound, 
            Camera.main.transform.position);
        Application.LoadLevel(1);
    }
}
