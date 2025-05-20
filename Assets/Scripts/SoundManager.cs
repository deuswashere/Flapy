using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip tungClip;
    public AudioClip sahurClip;
    public AudioClip ohNoClip;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTung()
    {
        audioSource.PlayOneShot(tungClip);
    }

    public void PlaySahur()
    {
        audioSource.PlayOneShot(sahurClip);
    }

    public void PlayOhNo()
    {
        audioSource.PlayOneShot(ohNoClip);
    }
}
