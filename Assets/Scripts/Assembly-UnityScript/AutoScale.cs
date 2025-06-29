using System;
using UnityEngine;

[Serializable]
public class AutoScale : MonoBehaviour
{
	public float scaleSpeedX;

	public float scaleSpeedY;

	public float scaleSpeedZ;

	public float scaleX;

	public float scaleY;

	public float scaleZ;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = gameObject.transform;
	}

	public virtual void Update()
	{
		float x = Mathf.Lerp(myTransform.localScale.x, scaleX, scaleSpeedX * Time.deltaTime);
		Vector3 localScale = myTransform.localScale;
		float num = (localScale.x = x);
		Vector3 vector = (myTransform.localScale = localScale);
		float y = Mathf.Lerp(myTransform.localScale.y, scaleY, scaleSpeedY * Time.deltaTime);
		Vector3 localScale2 = myTransform.localScale;
		float num2 = (localScale2.y = y);
		Vector3 vector3 = (myTransform.localScale = localScale2);
		float z = Mathf.Lerp(myTransform.localScale.z, scaleZ, scaleSpeedZ * Time.deltaTime);
		Vector3 localScale3 = myTransform.localScale;
		float num3 = (localScale3.z = z);
		Vector3 vector5 = (myTransform.localScale = localScale3);
	}

	public virtual void Main()
	{
	}
}
