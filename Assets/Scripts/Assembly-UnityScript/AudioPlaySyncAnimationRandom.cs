using System;
using UnityEngine;

[Serializable]
public class AudioPlaySyncAnimationRandom : MonoBehaviour
{
	public AudioClip[] audioClips;

	public float volume;

	public bool useTarget;

	public GameObject target;

	private int random;

	public virtual void AudioPlaySyncAnimationRandom()
	{
		random = UnityEngine.Random.Range(0, audioClips.Length);
		if (!useTarget)
		{
			if (audioClips[random] != null)
			{
				audio.PlayOneShot(audioClips[random], volume);
			}
		}
		else if (audioClips[random] != null)
		{
			target.audio.PlayOneShot(audioClips[random], volume);
		}
	}

	public virtual void Main()
	{
	}
}
