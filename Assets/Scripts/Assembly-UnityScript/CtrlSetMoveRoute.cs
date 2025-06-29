using System;
using UnityEngine;

[Serializable]
public class CtrlSetMoveRoute
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public MoveRoute[] route;

	public bool waitForCompletion;
}
