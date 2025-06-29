using System;
using UnityEngine;

[Serializable]
public class ScreenOverlayController : MonoBehaviour
{
	public Transform owner;

	public float fadeSpeed;

	public FakeHDRTarget[] targets;

	private ScreenOverlay screenOverlay;

	private float distance;

	private int i;

	private int id;

	private float distanceTemp;

	public virtual void Start()
	{
		screenOverlay = (ScreenOverlay)GameObject.FindWithTag("MainCamera").GetComponent(typeof(ScreenOverlay));
	}

	public virtual void Update()
	{
		id = 0;
		distance = 999999f;
		distanceTemp = 0f;
		for (i = 0; i < targets.Length; i++)
		{
			distanceTemp = Vector3.Distance(targets[i].targetTransform.position, owner.position);
			if (!(distanceTemp >= distance))
			{
				id = i;
				distance = distanceTemp;
			}
		}
		if (!(distance > targets[id].minDistance))
		{
			screenOverlay.intensity = Mathf.Lerp(screenOverlay.intensity, targets[id].minAmount, 4f * Time.deltaTime);
		}
		else if (!(distance < targets[id].maxDistance))
		{
			screenOverlay.intensity = Mathf.Lerp(screenOverlay.intensity, targets[id].maxAmount, 4f * Time.deltaTime);
		}
		else
		{
			screenOverlay.intensity = Mathf.Lerp(screenOverlay.intensity, (targets[id].maxAmount - targets[id].minAmount) * ((distance - targets[id].minDistance) / (targets[id].maxDistance - targets[id].minDistance)) + targets[id].minAmount, fadeSpeed * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
