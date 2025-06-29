using System;
using UnityEngine;

[Serializable]
public class IKController_Girl0 : MonoBehaviour
{
	public ikLimb ikObject;

	public Transform targetFrom;

	public Transform targetTo;

	public float riseSpeed;

	public float downSpeed;

	public float angle;

	public float myAngle;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = transform;
	}

	public virtual void Update()
	{
		Vector3 vector = myTransform.TransformDirection(Vector3.forward);
		Vector3 vector2 = targetFrom.TransformDirection(Vector3.forward);
		if (!Physics.Linecast(targetFrom.position, targetTo.position, -5) && !(Vector3.Angle(vector2, targetTo.position - targetFrom.position) > angle) && !(Vector3.Angle(vector, targetTo.position - myTransform.position) > myAngle))
		{
			if (!ikObject.IsEnabled)
			{
				ikObject.IsEnabled = true;
				ikObject.transition = 0f;
			}
			else if (!(ikObject.transition >= 0.999999f))
			{
				ikObject.transition = Mathf.Lerp(ikObject.transition, 1f, Time.deltaTime * riseSpeed);
			}
			else
			{
				ikObject.transition = 1f;
			}
		}
		else if (ikObject.IsEnabled)
		{
			ikObject.transition = Mathf.Lerp(ikObject.transition, 0f, Time.deltaTime * downSpeed);
			if (!(ikObject.transition > 1E-06f))
			{
				ikObject.transition = 0f;
				ikObject.IsEnabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
