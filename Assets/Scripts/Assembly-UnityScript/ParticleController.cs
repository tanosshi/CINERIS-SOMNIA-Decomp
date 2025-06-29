using System;
using UnityEngine;

[Serializable]
public class ParticleController : MonoBehaviour
{
	public Transform player;

	public float enableDistance;

	public float minTime;

	public float maxTime;

	private Transform myTransform;

	private ParticleSystem myParticle;

	private float count;

	public virtual void Start()
	{
		myTransform = gameObject.transform;
		myParticle = (ParticleSystem)GetComponent(typeof(ParticleSystem));
		count = UnityEngine.Random.Range(minTime, maxTime);
	}

	public virtual void Update()
	{
		if (!(Vector3.Distance(myTransform.position, player.position) > enableDistance))
		{
			count -= 1f * Time.deltaTime;
			if (!(count > 0f))
			{
				myParticle.Play();
				count = UnityEngine.Random.Range(minTime, maxTime);
			}
		}
	}

	public virtual void Main()
	{
	}
}
