using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    public AudioClip selectSound;
    public AudioClip matchSound;
    public AudioClip backgroundMusic;

    private void Awake() //for singleton design pattern
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void StopMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.Stop();
    }

    public void PlayEffect(AudioClip clip)
    {
        if (clip == null) return;
        effectSource.PlayOneShot(clip);
    }
    public void PlaySelectSound() 
    {
        PlayEffect(selectSound);
    }
}
