using UnityEngine;

public class ReplicatePrefabAlongParticle : MonoBehaviour
{
	public GameObject prefab;

	private ParticleSystem.Particle[] particles;

	private GameObject[] pool;

	private void Start()
	{
		particles = new ParticleSystem.Particle[base.particleSystem.maxParticles];
		pool = new GameObject[base.particleSystem.maxParticles];
		for (int i = 0; i < base.particleSystem.maxParticles; i++)
		{
			pool[i] = Object.Instantiate(prefab) as GameObject;
		}
	}

	private void Update()
	{
		int num = base.particleSystem.GetParticles(particles);
		for (int i = 0; i < num; i++)
		{
			pool[i].transform.position = particles[i].position;
			pool[i].transform.localRotation = Quaternion.AngleAxis(particles[i].rotation, particles[i].axisOfRotation);
			pool[i].transform.localScale = Vector3.one * particles[i].size;
			pool[i].renderer.enabled = true;
		}
		for (int j = num; j < pool.Length; j++)
		{
			pool[j].renderer.enabled = false;
		}
	}
}
