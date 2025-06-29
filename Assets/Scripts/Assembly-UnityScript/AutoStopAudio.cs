using System;
using UnityEngine;

[Serializable]
public class AutoStopAudio : MonoBehaviour
{
	private bool isPausing;

	public virtual void Update()
	{
		if (Time.timeScale == 0f && audio.isPlaying)
		{
			audio.Pause();
			isPausing = true;
		}
		else if (Time.timeScale != 0f && isPausing)
		{
			audio.Play();
			isPausing = false;
		}
	}

	public virtual void Main()
	{
	}
}
