using System;
using UnityEngine;

[Serializable]
public class CtrlSendExtraMessage
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public string message;

	public float amount;
}
