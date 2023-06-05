using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip soundEffect;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundEffect;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}