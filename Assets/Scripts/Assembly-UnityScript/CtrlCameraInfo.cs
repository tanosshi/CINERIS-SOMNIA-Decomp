using System;
using UnityEngine;

[Serializable]
public class CtrlCameraInfo
{
	public AnimationTargetType targetType;

	public GameObject targetCamera;

	public string tagName;

	public DisableOrEnable operation;

	public bool changeFieldOfView;

	public float fieldOfView;

	public bool changeClippingPlanes;

	public float nearClippingPlane;

	public float farClippingPlane;

	public bool changeDepth;

	public int depth;

	public bool changeMaxRot;

	public float maxRot;

	public bool changeRot;

	public float rotX;

	public float rotY;

	public bool changeLookAtTarget;

	public GameObject lookAtTarget;

	public bool changeDistance;

	public float distance;

	public bool changeWidth;

	public float width;

	public bool endSwitch;
}
