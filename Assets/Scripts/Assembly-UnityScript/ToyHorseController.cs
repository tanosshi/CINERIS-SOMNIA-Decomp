using System;
using UnityEngine;

[Serializable]
public class ToyHorseController : MonoBehaviour
{
	public AudioClip audioClip;

	public float rangeMax;

	public float speedAttenuation;

	private Transform myTransform;

	private SinRotateAttenuation sinRotate;

	private bool audioFlag;

	private float audioVolume;

	public virtual void Start()
	{
		myTransform = gameObject.transform;
		sinRotate = (SinRotateAttenuation)GetComponent(typeof(SinRotateAttenuation));
	}

	public virtual void Update()
	{
		if (!sinRotate.enabled)
		{
			return;
		}
		if (!(sinRotate.yRange < 0f))
		{
			audioVolume = sinRotate.yRange / rangeMax;
		}
		if (!(sinRotate.rotateSpeedY < 0.2f))
		{
			sinRotate.rotateSpeedY -= speedAttenuation * Time.deltaTime;
		}
		if (myTransform.localRotation.eulerAngles.y > 359f || !(myTransform.localRotation.eulerAngles.y >= 1f))
		{
			if (!audioFlag)
			{
				audioFlag = true;
				audio.PlayOneShot(audioClip, audioVolume);
			}
		}
		else
		{
			audioFlag = false;
		}
	}

	public virtual void Main()
	{
	}
}
