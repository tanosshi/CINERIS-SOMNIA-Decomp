using System;
using UnityEngine;

[Serializable]
public class PathCameraController : MonoBehaviour
{
	public float minPosition;

	public float minDistance;

	public float minAngle;

	public float maxPosition;

	public float maxDistance;

	public float maxAngle;

	private Transform playerTransform;

	private Camera_Controller controller;

	public virtual void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").transform;
		controller = (Camera_Controller)GetComponent(typeof(Camera_Controller));
	}

	public virtual void Update()
	{
		controller.DontControllCamera(true);
		if (!(playerTransform.position.x >= minPosition))
		{
			controller.FixedRot(maxAngle, 90f);
			controller.ChangeDistance(maxDistance);
		}
		else if (!(playerTransform.position.x <= maxPosition))
		{
			controller.FixedRot(minAngle, 90f);
			controller.ChangeDistance(minDistance);
		}
		else
		{
			controller.FixedRot((maxAngle - minAngle) * ((maxPosition - playerTransform.position.x) / (maxPosition - minPosition)) + minAngle, 90f);
			controller.ChangeDistance((maxDistance - minDistance) * ((maxPosition - playerTransform.position.x) / (maxPosition - minPosition)) + minDistance);
		}
	}

	public virtual void Main()
	{
	}
}
