using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesContainer : CustomService
{
    [Header("Particulas")]
    [SerializeField]
    public GameObject markParticle;
    [SerializeField]
    public GameObject waterParticle;
    [SerializeField]
    public GameObject fireParticle;
    [SerializeField]
    public GameObject electricParticle;
    [SerializeField]
    public GameObject gamblingParticle;
    [SerializeField]
    public GameObject musicParticle;
    [SerializeField]
    public GameObject magicParticle;
    [SerializeField]
    public GameObject moneyParticle;

    private List<ParticleSystem> particles;
    private void Awake()
    {
        ServiceLocator.AddService(this);
    }
    private void Start()
    {
        particles = new List<ParticleSystem>();
    }
    private void Update()
    {
        DeleteParticles();
    }
    public void PlayParticle(GameObject particle, Vector3 spacePos)
    {
        GameObject part = Instantiate(particle, spacePos + Vector3.up * 0.2f, particle.transform.rotation);
        particles.Add(part.GetComponent<ParticleSystem>());

        Utils.AudioManager.PlaySFX(Utils.AudioManager.GetParticleSound(particle));
    }
    private void DeleteParticles()
    {
        for (int i = 0; i < particles.Count; ++i)
        {
            if (!particles[i].IsAlive())
            {
                Destroy(particles[i].gameObject);
                particles.RemoveAt(i);
            }
        }
    }
}
