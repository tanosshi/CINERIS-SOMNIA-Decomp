using System;
using UnityEngine;

[Serializable]
public class RotateFixWithObject : MonoBehaviour
{
	public GameObject target;

	public bool activeX;

	public bool activeY;

	public bool activeZ;

	private Transform myTransform;

	private Transform targetTransform;

	public virtual void Start()
	{
		myTransform = transform;
		targetTransform = target.transform;
	}

	public virtual void Update()
	{
		if (activeX)
		{
			float x = targetTransform.rotation.eulerAngles.x;
			Quaternion rotation = myTransform.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			float num = (eulerAngles.x = x);
			Vector3 vector = (rotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (myTransform.rotation = rotation);
		}
		if (activeY)
		{
			float y = targetTransform.rotation.eulerAngles.y;
			Quaternion rotation2 = myTransform.rotation;
			Vector3 eulerAngles2 = rotation2.eulerAngles;
			float num2 = (eulerAngles2.y = y);
			Vector3 vector3 = (rotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (myTransform.rotation = rotation2);
		}
		if (activeZ)
		{
			float z = targetTransform.rotation.eulerAngles.z;
			Quaternion rotation3 = myTransform.rotation;
			Vector3 eulerAngles3 = rotation3.eulerAngles;
			float num3 = (eulerAngles3.z = z);
			Vector3 vector5 = (rotation3.eulerAngles = eulerAngles3);
			Quaternion quaternion5 = (myTransform.rotation = rotation3);
		}
	}

	public virtual void Main()
	{
	}
}
