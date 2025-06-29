using System;
using UnityEngine;

[Serializable]
public class AudioPlaySyncAnimation : MonoBehaviour
{
	public AudioClip[] audioClips;

	public float volume;

	public virtual void AudioPlaySyncAnimation(int num)
	{
		if (audioClips[num] != null)
		{
			audio.PlayOneShot(audioClips[num], volume);
		}
	}

	public virtual void Main()
	{
	}
}
