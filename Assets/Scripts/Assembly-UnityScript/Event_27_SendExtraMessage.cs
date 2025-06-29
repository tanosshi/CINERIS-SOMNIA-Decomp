using System;
using UnityEngine;

[Serializable]
public class Event_27_SendExtraMessage : MonoBehaviour
{
	public CtrlSendExtraMessage[] state;

	public virtual void Start()
	{
		for (int i = 0; i < state.Length; i++)
		{
			if (state[i].targetType == AnimationTargetType.Tag)
			{
				state[i].target = GameObject.FindWithTag(state[i].tagName);
			}
		}
	}

	public virtual void SendExtraMessage(int num)
	{
		if (state[num].target != null)
		{
			state[num].target.SendMessage(state[num].message, state[num].amount);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
