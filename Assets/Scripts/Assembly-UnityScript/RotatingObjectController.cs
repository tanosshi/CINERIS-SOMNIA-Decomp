using System;
using UnityEngine;

[Serializable]
public class RotatingObjectController : MonoBehaviour
{
	public float rotateSpeedX;

	public float rotateSpeedY;

	public float rotateSpeedZ;

	private Transform myTransform;

	public virtual void Awake()
	{
		myTransform = transform;
	}

	public virtual void FixedUpdate()
	{
		myTransform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
