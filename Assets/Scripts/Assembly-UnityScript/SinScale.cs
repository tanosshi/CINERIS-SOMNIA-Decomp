using System;
using UnityEngine;

[Serializable]
public class SinScale : MonoBehaviour
{
	public float scaleSpeedX;

	public float scaleSpeedY;

	public float scaleSpeedZ;

	public float xRange;

	public float yRange;

	public float zRange;

	private Transform myTransform;

	private float firstScaleX;

	private float firstScaleY;

	private float firstScaleZ;

	public SinScale()
	{
		scaleSpeedX = 1f;
		scaleSpeedY = 1f;
		scaleSpeedZ = 1f;
	}

	public virtual void Awake()
	{
		myTransform = transform;
		firstScaleX = transform.localScale.x;
		firstScaleY = transform.localScale.y;
		firstScaleZ = transform.localScale.z;
	}

	public virtual void FixedUpdate()
	{
		float num = Mathf.Sin(Time.time * scaleSpeedX);
		float num2 = Mathf.Sin(Time.time * scaleSpeedY);
		float num3 = Mathf.Sin(Time.time * scaleSpeedZ);
		float x = firstScaleX + num * xRange;
		Vector3 localScale = myTransform.localScale;
		float num4 = (localScale.x = x);
		Vector3 vector = (myTransform.localScale = localScale);
		float y = firstScaleY + num2 * yRange;
		Vector3 localScale2 = myTransform.localScale;
		float num5 = (localScale2.y = y);
		Vector3 vector3 = (myTransform.localScale = localScale2);
		float z = firstScaleZ + num3 * zRange;
		Vector3 localScale3 = myTransform.localScale;
		float num6 = (localScale3.z = z);
		Vector3 vector5 = (myTransform.localScale = localScale3);
	}

	public virtual void Main()
	{
	}
}
