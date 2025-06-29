using System;
using UnityEngine;

[Serializable]
public class Event_26_SetFootstepId : MonoBehaviour
{
	public CtrlFootstepId[] state;

	public virtual void SetFootstepId(int num)
	{
		if (state[num].targetType == AnimationTargetType.Tag)
		{
			state[num].target = GameObject.FindWithTag(state[num].tagName);
		}
		if (state[num].changeFootstep)
		{
			state[num].target.SendMessage("ChangeFootstepId", state[num].footstepId);
		}
		if (state[num].changeFootEffect)
		{
			state[num].target.SendMessage("ChangeFootEffectId", state[num].footEffectId);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
