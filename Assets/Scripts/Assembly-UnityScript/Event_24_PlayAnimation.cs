using System;
using UnityEngine;

[Serializable]
public class Event_24_PlayAnimation : MonoBehaviour
{
	public CtrlPlayAnimation[] state;

	private int i;

	public virtual void Start()
	{
		for (i = 0; i < state.Length; i++)
		{
			if (state[i].targetType == AnimationTargetType.Tag)
			{
				state[i].target = GameObject.FindWithTag(state[i].tagName);
			}
			state[i].animator = (Animator)state[i].target.GetComponent(typeof(Animator));
		}
	}

	public virtual void PlayAnimation(int num)
	{
		if (state[num].target != null)
		{
			if (state[num].animationType == AnimationType.Mecanim)
			{
				if (state[num].operation == PlayOrStop.Play)
				{
					state[num].target.SendMessage("SetAnimationFadeTime", state[num].fadeTime, SendMessageOptions.DontRequireReceiver);
					state[num].target.SendMessage("AnimationManager", state[num].animationId, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					state[num].target.SendMessage("SetAnimationFadeTime", state[num].fadeTime, SendMessageOptions.DontRequireReceiver);
					state[num].target.SendMessage("StopAnimation", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (state[num].operation == PlayOrStop.Play)
			{
				state[num].animator.CrossFade(state[num].animationName, state[num].fadeTime, state[num].legacyLayer);
			}
			else
			{
				state[num].target.animation.Stop();
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
