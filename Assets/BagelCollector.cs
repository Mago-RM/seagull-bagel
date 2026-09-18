using UnityEngine;

public class BagelCollector : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip eatSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bagel"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(eatSound);
            gameManager.AddScore();
        }
    }
}