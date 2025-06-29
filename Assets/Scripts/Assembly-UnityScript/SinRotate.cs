using System;
using UnityEngine;

[Serializable]
public class SinRotate : MonoBehaviour
{
	public float rotateSpeedX;

	public float rotateSpeedY;

	public float rotateSpeedZ;

	public float xRange;

	public float yRange;

	public float zRange;

	private Transform myTransform;

	private float firstRotationX;

	private float firstRotationY;

	private float firstRotationZ;

	private float nowTime;

	public SinRotate()
	{
		rotateSpeedX = 1f;
		rotateSpeedY = 1f;
		rotateSpeedZ = 1f;
	}

	public virtual void Awake()
	{
		myTransform = transform;
		firstRotationX = transform.localRotation.eulerAngles.x;
		firstRotationY = transform.localRotation.eulerAngles.y;
		firstRotationZ = transform.localRotation.eulerAngles.z;
	}

	public virtual void OnEnable()
	{
		nowTime = 0f;
	}

	public virtual void FixedUpdate()
	{
		nowTime += 1f * Time.deltaTime;
		float num = Mathf.Sin(nowTime * rotateSpeedX);
		float num2 = Mathf.Sin(nowTime * rotateSpeedY);
		float num3 = Mathf.Sin(nowTime * rotateSpeedZ);
		float x = firstRotationX + num * xRange;
		Quaternion localRotation = myTransform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num4 = (eulerAngles.x = x);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (myTransform.localRotation = localRotation);
		float y = firstRotationY + num2 * yRange;
		Quaternion localRotation2 = myTransform.localRotation;
		Vector3 eulerAngles2 = localRotation2.eulerAngles;
		float num5 = (eulerAngles2.y = y);
		Vector3 vector3 = (localRotation2.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (myTransform.localRotation = localRotation2);
		float z = firstRotationZ + num3 * zRange;
		Quaternion localRotation3 = myTransform.localRotation;
		Vector3 eulerAngles3 = localRotation3.eulerAngles;
		float num6 = (eulerAngles3.z = z);
		Vector3 vector5 = (localRotation3.eulerAngles = eulerAngles3);
		Quaternion quaternion5 = (myTransform.localRotation = localRotation3);
	}

	public virtual void Main()
	{
	}
}
