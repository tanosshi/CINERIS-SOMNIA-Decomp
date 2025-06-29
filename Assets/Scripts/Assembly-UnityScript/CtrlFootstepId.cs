using System;
using UnityEngine;

[Serializable]
public class CtrlFootstepId
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public bool changeFootstep;

	public int footstepId;

	public bool changeFootEffect;

	public int footEffectId;

	public CtrlFootstepId()
	{
		changeFootstep = true;
	}
}
