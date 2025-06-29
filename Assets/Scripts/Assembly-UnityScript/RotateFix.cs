using System;
using UnityEngine;

[Serializable]
public class RotateFix : MonoBehaviour
{
	public bool activeX;

	public float valueX;

	public bool activeY;

	public float valueY;

	public bool activeZ;

	public float valueZ;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = gameObject.transform;
	}

	public virtual void Update()
	{
		if (activeX)
		{
			float x = valueX;
			Quaternion rotation = myTransform.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			float num = (eulerAngles.x = x);
			Vector3 vector = (rotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (myTransform.rotation = rotation);
		}
		if (activeY)
		{
			float y = valueY;
			Quaternion rotation2 = myTransform.rotation;
			Vector3 eulerAngles2 = rotation2.eulerAngles;
			float num2 = (eulerAngles2.y = y);
			Vector3 vector3 = (rotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (myTransform.rotation = rotation2);
		}
		if (activeZ)
		{
			float z = valueZ;
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
