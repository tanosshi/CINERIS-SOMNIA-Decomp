using System;
using UnityEngine;

[Serializable]
public class LightFlicker : MonoBehaviour
{
	public bool flickIntensity;

	public float flickSpeedIntensity;

	public float powerIntensity;

	public bool flickRange;

	public float flickSpeedRange;

	public float powerRange;

	private Light myStatus;

	private float firstIntensity;

	private float firstRange;

	public LightFlicker()
	{
		flickSpeedIntensity = 1f;
		flickSpeedRange = 1f;
	}

	public virtual void Awake()
	{
		myStatus = (Light)GetComponent(typeof(Light));
		firstIntensity = myStatus.intensity;
		firstRange = myStatus.range;
	}

	public virtual void Update()
	{
		if (flickIntensity || flickRange)
		{
			if (flickIntensity)
			{
				float num = Mathf.Sin(Time.time * flickSpeedIntensity);
				myStatus.intensity = firstIntensity + num * powerIntensity;
			}
			if (flickRange)
			{
				float num2 = Mathf.Sin(Time.time * flickSpeedRange);
				myStatus.range = firstRange + num2 * powerRange;
			}
		}
	}

	public virtual void Main()
	{
	}
}
