using System;
using UnityEngine;

[Serializable]
public class LensFlareController : MonoBehaviour
{
	public Transform targetCamera;

	public Vector3 sunPosition;

	public float distance;

	private Transform myTransform;

	private Vector3 sunVec;

	public virtual void Start()
	{
		myTransform = transform;
	}

	public virtual void Update()
	{
		sunVec = sunPosition - targetCamera.position;
		myTransform.position = targetCamera.position + sunVec.normalized * distance;
	}

	public virtual void Main()
	{
	}
}
