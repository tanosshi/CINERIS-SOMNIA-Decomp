using System;
using UnityEngine;

[Serializable]
public class ParticleCollisionPlayAudio : MonoBehaviour
{
	public GameObject target;

	public float volumeMin;

	public float volumeMax;

	public float pitchMin;

	public float pitchMax;

	public AudioClip[] audioClips;

	private float volume;

	private int random;

	public virtual void OnParticleCollision(GameObject other)
	{
		target.audio.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
		volume = UnityEngine.Random.Range(volumeMin, volumeMax);
		random = UnityEngine.Random.Range(0, audioClips.Length);
		target.audio.PlayOneShot(audioClips[random]);
	}

	public virtual void Main()
	{
	}
}
