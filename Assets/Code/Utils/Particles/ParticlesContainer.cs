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
    public GameObject mmusicParticle;
    [SerializeField]
    public GameObject magicParticle;

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
        GameObject part = Instantiate(particle, spacePos, particle.transform.rotation);
        particles.Add(part.GetComponent<ParticleSystem>());
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
