using System;
using UnityEngine;

[Serializable]
public class SetTransformProperty
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public Transform targetTransform;

	public bool render;
}
