using System;
using UnityEngine;

[Serializable]
public class CameraAudioListener : MonoBehaviour
{
	private Camera myCamera;

	private AudioListener myAudioListener;

	public virtual void Start()
	{
		myCamera = (Camera)GetComponent(typeof(Camera));
		myAudioListener = (AudioListener)GetComponent(typeof(AudioListener));
	}

	public virtual void Update()
	{
		if (myCamera.enabled)
		{
			myAudioListener.enabled = true;
		}
		else
		{
			myAudioListener.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
