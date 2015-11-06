using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip CoinCollectEffect;

    void OnTriggerEnter(Collider col)
    {
        MainCharacter.Instance.CollectCoin();
        AudioSource.PlayClipAtPoint(CoinCollectEffect, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
