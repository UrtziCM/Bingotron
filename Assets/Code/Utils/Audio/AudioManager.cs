using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioManager : CustomService
{
    public AudioMixer audioMixer;
    [Header("Particle Sounds")]
    [SerializeField]
    private AudioClip markSound;
    [SerializeField]
    private AudioClip[] waterSound;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip electricSound;
    [SerializeField]
    private AudioClip gamblingSound;
    [SerializeField]
    private AudioClip[] musicSound;
    [SerializeField]
    private AudioClip magicSound;
    [SerializeField]
    private AudioClip moneySound;

    [Header("Bombo Sounds")]
    [SerializeField]
    private AudioClip bomboRollSound;
    [SerializeField]
    public AudioClip ballSound;
    private AudioSource drumRollLoop;

    [Header("Music")]
    [SerializeField]
    private AudioClip music;
    [SerializeField]
    private AudioSource musicSource; 

    [SerializeField]
    private AudioMixerGroup SFX;

    private void Awake()
    {
        if (ServiceLocator.HasService<AudioManager>())
        {
            Destroy(gameObject);
            return;
        }
        ServiceLocator.AddService(this);
        musicSource.clip = music;
        musicSource.Play();
    }

    private void Start()
    {  
        DontDestroyOnLoad(this);           
    }

    public void PlaySFX(AudioClip clip)
    {
        GameObject go = new GameObject("SpatialAudio");

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.pitch = Random.Range(0.8f, 1.2f);
        source.volume *= 10;
        SFX = audioMixer.FindMatchingGroups("SFX")[0];
        go.GetComponent<AudioSource>().outputAudioMixerGroup = SFX;
        source.Play();

        Destroy(go, clip.length);
    }

    public void PlayDrumRoll()
    {
        GameObject go = new GameObject("SpatialAudio");

        drumRollLoop = go.AddComponent<AudioSource>();
        drumRollLoop.clip = bomboRollSound;
        drumRollLoop.pitch = Random.Range(0.8f, 1.2f);
        drumRollLoop.volume *= 10;
        drumRollLoop.loop = true;

        // Temporary debug — paste the output here
        var allGroups = audioMixer.FindMatchingGroups("");
        foreach (var g in allGroups)
            Debug.Log($"Mixer group: '{g.name}'");

        SFX = audioMixer.FindMatchingGroups("Drum")[0];
        go.GetComponent<AudioSource>().outputAudioMixerGroup = SFX;
        drumRollLoop.Play();
    }

    public void StopDrumRoll()
    {
        Destroy(drumRollLoop);
    }

    public AudioClip GetParticleSound(GameObject particle)
    {
        ParticlesContainer particles = Utils.ParticlesContainer;

        if (particle == particles.markParticle)
            return markSound;

        if (particle == particles.waterParticle)
            return waterSound[Random.Range(0,waterSound.Length)];

        if (particle == particles.fireParticle)
            return fireSound;

        if (particle == particles.electricParticle)
            return electricSound;

        if (particle == particles.gamblingParticle)
            return gamblingSound;

        if (particle == particles.musicParticle)
            return musicSound[Random.Range(0, musicSound.Length)];

        if (particle == particles.magicParticle)
            return magicSound;

        if (particle == particles.moneyParticle)
            return moneySound;

        return null;
    }
}
