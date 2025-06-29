using System;
using UnityEngine;

[Serializable]
public class CageController : MonoBehaviour
{
	public AudioClip audioClip;

	public float volumeSpeed;

	private bool nowPlaying;

	private Transform myTransform;

	private bool firstIgnore;

	public virtual void Start()
	{
		myTransform = transform;
	}

	public virtual void Update()
	{
		if (!(myTransform.rotation.eulerAngles.y < 296.6f) && !(myTransform.rotation.eulerAngles.y > 297.4f))
		{
			if (firstIgnore)
			{
				if (!nowPlaying)
				{
					nowPlaying = true;
					audio.PlayOneShot(audioClip);
				}
			}
			else
			{
				firstIgnore = true;
				nowPlaying = true;
			}
		}
		else
		{
			nowPlaying = false;
		}
		audio.volume -= volumeSpeed * Time.deltaTime;
	}

	public virtual void Main()
	{
	}
}
