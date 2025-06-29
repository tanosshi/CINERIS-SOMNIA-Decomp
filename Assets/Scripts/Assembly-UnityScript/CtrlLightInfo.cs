using System;
using UnityEngine;

[Serializable]
public class CtrlLightInfo
{
	public GameObject targetLight;

	public DisableOrEnable operation;

	public float time;

	public bool changeRange;

	public float range;

	public bool changeColor;

	public Color color;

	public bool changeIntensity;

	public float intensity;

	public bool changeSpotAngle;

	public float spotAngle;
}
