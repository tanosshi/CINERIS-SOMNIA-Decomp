using System;
using UnityEngine;

[Serializable]
public class ScreenOverlayFader : MonoBehaviour
{
	public bool fadeFlag;

	public float minIntensity;

	public float maxIntensity;

	public float fadeSpeed;

	private Transform mainCamera;

	private ScreenOverlay screenOverlay;

	private bool nowFading;

	public ScreenOverlayFader()
	{
		maxIntensity = 1f;
	}

	public virtual void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera").transform;
		screenOverlay = (ScreenOverlay)mainCamera.GetComponent(typeof(ScreenOverlay));
	}

	public virtual void Update()
	{
		if (!nowFading)
		{
			return;
		}
		if (!fadeFlag && !(screenOverlay.intensity < minIntensity))
		{
			screenOverlay.intensity -= fadeSpeed * Time.deltaTime;
			if (!(screenOverlay.intensity >= minIntensity))
			{
				screenOverlay.intensity = minIntensity;
				nowFading = false;
			}
		}
		else if (fadeFlag && !(screenOverlay.intensity > maxIntensity))
		{
			screenOverlay.intensity += fadeSpeed * Time.deltaTime;
			if (!(screenOverlay.intensity <= maxIntensity))
			{
				screenOverlay.intensity = maxIntensity;
				nowFading = false;
			}
		}
	}

	public virtual void ChangeScreenOverlayFader(int flag)
	{
		if (flag == 0)
		{
			fadeFlag = false;
			nowFading = true;
		}
		else
		{
			fadeFlag = true;
			nowFading = true;
		}
	}

	public virtual void Main()
	{
	}
}
