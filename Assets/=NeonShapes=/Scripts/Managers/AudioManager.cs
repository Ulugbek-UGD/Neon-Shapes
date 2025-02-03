using UnityEngine;

namespace NeonShapes
{
    [DefaultExecutionOrder(-1)]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip backgroundMusic;
        
        private AudioSource musicSource;
        private AudioSource soundSource;
        
        public static AudioManager Instance { get; private set; }
        
        //==================================================
        private void Awake()
        {
            if (Instance == null || Instance == this)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            musicSource = transform.GetChild(0).GetComponent<AudioSource>();
            soundSource = transform.GetChild(1).GetComponent<AudioSource>();
        }
        //==================================================
        private void Start()
        {
            if (backgroundMusic == null) return;
            musicSource.clip = backgroundMusic;
            musicSource.volume = 0.5f;
            musicSource.loop = true;
            musicSource.Play();
        }
        //==================================================
        public void PlaySound(AudioClip clip)
        {
            if (soundSource.clip == clip && soundSource.isPlaying) return;
            soundSource.volume = Random.Range(0.9f, 1f);
            soundSource.pitch = Random.Range(0.9f, 1f);
            soundSource.PlayOneShot(clip);
        }
        //==================================================
    }
}