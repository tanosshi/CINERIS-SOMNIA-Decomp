using System;
using UnityEngine;

[Serializable]
public class CtrlHeadLookTarget
{
	public AnimationTargetType ownerType;

	public GameObject owner;

	public string tagName;

	public AnimationTargetType targetType;

	public GameObject lookAtTarget;

	public string targetTagName;

	public float bodyWeight;

	public float headWeight;

	public float eyeWeight;

	public float clampWeight;

	public bool changeIgnoreAngle;

	public float ignoreAngle;

	public bool freeLook;

	public bool changeLookAtFadeSpeed;

	public float lookAtFadeSpeed;
}
