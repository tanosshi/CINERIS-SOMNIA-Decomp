using System;
using UnityEngine;

[Serializable]
public class LightShaftsController : MonoBehaviour
{
	public Transform myTransform;

	public float minDistance;

	public float minBrightness;

	public float maxDistance;

	public float maxBrightness;

	public bool debugShowDistance;

	private Transform mainCamera;

	private LightShafts lightShafts;

	private float distance;

	public virtual void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera").transform;
		lightShafts = (LightShafts)GetComponent(typeof(LightShafts));
	}

	public virtual void Update()
	{
		distance = Vector3.Distance(myTransform.position, mainCamera.position);
		if (debugShowDistance)
		{
			Debug.Log(distance);
		}
		if (!(distance > minDistance))
		{
			lightShafts.m_Brightness = minBrightness;
		}
		else if (!(distance < maxDistance))
		{
			lightShafts.m_Brightness = maxBrightness;
		}
		else
		{
			lightShafts.m_Brightness = (maxBrightness - minBrightness) * ((distance - minDistance) / (maxDistance - minDistance)) + minBrightness;
		}
	}

	public virtual void Main()
	{
	}
}
