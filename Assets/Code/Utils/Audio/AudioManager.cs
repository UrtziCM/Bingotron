using UnityEngine;

public class AudioManager : CustomService
{
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
    private void Awake()
    {
        ServiceLocator.AddService(this);
    }
    public void PlaySFX(AudioClip clip)
    {
        GameObject go = new GameObject("SpatialAudio");

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.pitch = Random.Range(0.8f, 1.2f);
        source.volume *= 10;
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
