using UnityEngine;

public class AudiosZone : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    public Vector3 ColPoint;

    void OnTriggerEnter(Collider col)
    {
        ColPoint = col.transform.position;
        if (MainCharacter.Instance.AudioSource3D1.clip == null)
        {
            AudioSource = MainCharacter.Instance.AudioSource3D1;
            MainCharacter.Instance.AudioSource3D1.clip = AudioClip;
            AudioSource.Play();
        }
        else if (MainCharacter.Instance.AudioSource3D2.clip == null)
        {
            AudioSource = MainCharacter.Instance.AudioSource3D2;
            MainCharacter.Instance.AudioSource3D2.clip = AudioClip;
            AudioSource.Play();
        }
        else if (MainCharacter.Instance.AudioSource3D3.clip == null)
        {
            AudioSource = MainCharacter.Instance.AudioSource3D3;
            MainCharacter.Instance.AudioSource3D3.clip = AudioClip;
            AudioSource.Play();
        }
        else if (MainCharacter.Instance.AudioSource3D4.clip == null)
        {
            AudioSource = MainCharacter.Instance.AudioSource3D4;
            MainCharacter.Instance.AudioSource3D4.clip = AudioClip;
            AudioSource.Play();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (AudioSource == null)
        {
            return;
        }
        if (Vector3.Distance(col.transform.position, ColPoint) < 10f)
        {
            AudioSource.volume = (Vector3.Distance(col.transform.position, ColPoint) / 20f);
        }
        else
        {
            AudioSource.volume = 0.5f;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (AudioSource == null)
        {
            return;
        }
        AudioSource.clip = null;
        AudioSource = null;
    }
}
