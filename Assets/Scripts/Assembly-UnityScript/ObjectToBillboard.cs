using System;
using UnityEngine;

[Serializable]
public class ObjectToBillboard : MonoBehaviour
{
	public bool x;

	public bool y;

	public bool z;

	private Transform myTransform;

	private Transform targetTransform;

	private Quaternion q;

	private Camera[] cameraArray;

	private int i;

	public virtual void Awake()
	{
		myTransform = transform;
	}

	public virtual void Start()
	{
		cameraArray = ((Camera[])UnityEngine.Object.FindObjectsOfType(typeof(Camera))) as Camera[];
	}

	public virtual void Update()
	{
		for (i = 0; i < cameraArray.Length; i++)
		{
			if (cameraArray[i].enabled)
			{
				targetTransform = cameraArray[i].transform;
				break;
			}
		}
		if (x)
		{
			q = Quaternion.LookRotation(targetTransform.position - myTransform.position, Vector3.right);
			float num = q.eulerAngles.x;
			Vector3 eulerAngles = myTransform.eulerAngles;
			float num2 = (eulerAngles.x = num);
			Vector3 vector = (myTransform.eulerAngles = eulerAngles);
		}
		if (y)
		{
			q = Quaternion.LookRotation(targetTransform.position - myTransform.position, Vector3.up);
			float num3 = q.eulerAngles.y;
			Vector3 eulerAngles2 = myTransform.eulerAngles;
			float num4 = (eulerAngles2.y = num3);
			Vector3 vector3 = (myTransform.eulerAngles = eulerAngles2);
		}
		if (z)
		{
			q = Quaternion.LookRotation(targetTransform.position - myTransform.position, Vector3.forward);
			float num5 = q.eulerAngles.z;
			Vector3 eulerAngles3 = myTransform.eulerAngles;
			float num6 = (eulerAngles3.z = num5);
			Vector3 vector5 = (myTransform.eulerAngles = eulerAngles3);
		}
	}

	public virtual void Main()
	{
	}
}
