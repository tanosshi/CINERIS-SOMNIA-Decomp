using System;
using UnityEngine;

[Serializable]
public class Event_25_SetHeadLookTarget : MonoBehaviour
{
	public CtrlHeadLookTarget[] state;

	public virtual void SetHeadLookTarget(int num)
	{
		if (state[num].ownerType == AnimationTargetType.Tag)
		{
			state[num].owner = GameObject.FindWithTag(state[num].tagName);
		}
		if (state[num].targetType == AnimationTargetType.Tag)
		{
			state[num].lookAtTarget = GameObject.FindWithTag(state[num].targetTagName);
		}
		if (state[num].owner != null)
		{
			if (state[num].lookAtTarget != null)
			{
				state[num].owner.SendMessage("SetLookAtBodyWeight", state[num].bodyWeight);
				state[num].owner.SendMessage("SetLookAtHeadWeight", state[num].headWeight);
				state[num].owner.SendMessage("SetLookAtEyeWeight", state[num].eyeWeight);
				state[num].owner.SendMessage("SetLookAtClampWeight", state[num].clampWeight);
				if (state[num].changeIgnoreAngle)
				{
					state[num].owner.SendMessage("SetIgnoreAngle", state[num].ignoreAngle);
				}
				if (state[num].changeLookAtFadeSpeed)
				{
					state[num].owner.SendMessage("SetLookAtFadeSpeed", state[num].lookAtFadeSpeed);
				}
				state[num].owner.SendMessage("SetLookAtTarget", state[num].lookAtTarget);
			}
			else
			{
				state[num].owner.SendMessage("SetLookAtBodyWeight", state[num].bodyWeight);
				state[num].owner.SendMessage("SetLookAtHeadWeight", state[num].headWeight);
				state[num].owner.SendMessage("SetLookAtEyeWeight", state[num].eyeWeight);
				state[num].owner.SendMessage("SetLookAtClampWeight", state[num].clampWeight);
				if (state[num].changeIgnoreAngle)
				{
					state[num].owner.SendMessage("SetIgnoreAngle", state[num].ignoreAngle);
				}
				if (state[num].changeLookAtFadeSpeed)
				{
					state[num].owner.SendMessage("SetLookAtFadeSpeed", state[num].lookAtFadeSpeed);
				}
				state[num].owner.SendMessage("DeleteLookAtTarget");
			}
			state[num].owner.SendMessage("ChangeFreeLook", state[num].freeLook, SendMessageOptions.DontRequireReceiver);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
