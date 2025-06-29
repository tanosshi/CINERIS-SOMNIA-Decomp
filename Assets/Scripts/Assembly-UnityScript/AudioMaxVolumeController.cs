using System;
using UnityEngine;

[Serializable]
public class AudioMaxVolumeController : MonoBehaviour
{
	public AudioSource audioSource;

	public float maxVolume;

	public float volumeFadeSpeed;

	private bool inFlag;

	private float originalVolume;

	public AudioMaxVolumeController()
	{
		maxVolume = 1f;
		volumeFadeSpeed = 1f;
	}

	public virtual void Start()
	{
		originalVolume = audioSource.volume;
	}

	public virtual void Update()
	{
		if (inFlag)
		{
			if (!(audioSource.volume <= maxVolume))
			{
				audioSource.volume = Mathf.Lerp(audioSource.volume, maxVolume, volumeFadeSpeed * Time.deltaTime);
			}
			else if (!(audioSource.volume >= originalVolume))
			{
				audioSource.volume = Mathf.Lerp(audioSource.volume, originalVolume, volumeFadeSpeed * Time.deltaTime);
			}
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player" && !inFlag)
		{
			inFlag = true;
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player")
		{
			inFlag = false;
		}
	}

	public virtual void Main()
	{
	}
}
