using System;
using UnityEngine;

[Serializable]
public class SinMove : MonoBehaviour
{
	public float moveSpeed1;

	public float moveSpeed2;

	public float xRange;

	public float yRange;

	public float zRange;

	private Transform myTransform;

	private Vector3 firstPosition;

	private float nowTime;

	public SinMove()
	{
		moveSpeed1 = 1f;
		moveSpeed2 = 1f;
	}

	public virtual void Awake()
	{
		myTransform = transform;
		firstPosition = transform.localPosition;
	}

	public virtual void OnEnable()
	{
		nowTime = 0f;
	}

	public virtual void Update()
	{
		nowTime += 1f * Time.deltaTime;
		float num = Mathf.Sin(nowTime * moveSpeed1);
		float num2 = Mathf.Sin(nowTime * moveSpeed2);
		float x = firstPosition.x + num * xRange;
		Vector3 localPosition = myTransform.localPosition;
		float num3 = (localPosition.x = x);
		Vector3 vector = (myTransform.localPosition = localPosition);
		float y = firstPosition.y + num2 * yRange;
		Vector3 localPosition2 = myTransform.localPosition;
		float num4 = (localPosition2.y = y);
		Vector3 vector3 = (myTransform.localPosition = localPosition2);
		float z = firstPosition.z + num * num2 * zRange;
		Vector3 localPosition3 = myTransform.localPosition;
		float num5 = (localPosition3.z = z);
		Vector3 vector5 = (myTransform.localPosition = localPosition3);
	}

	public virtual void Main()
	{
	}
}
