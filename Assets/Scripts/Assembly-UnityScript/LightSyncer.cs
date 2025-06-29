using System;
using UnityEngine;

[Serializable]
public class LightSyncer : MonoBehaviour
{
	public Light target;

	private Light myLight;

	public virtual void Start()
	{
		myLight = (Light)GetComponent(typeof(Light));
	}

	public virtual void Update()
	{
		myLight.range = target.range;
		myLight.intensity = target.intensity;
	}

	public virtual void Main()
	{
	}
}
