using System;
using UnityEngine;

[Serializable]
public class Event_08_SetObjectTransform : MonoBehaviour
{
	public CtrlTransform[] state;

	private Player_Status status;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void SetObjectTransform(int num)
	{
		if (state[num].targets.Length != 0)
		{
			for (i = 0; i < state[num].targets.Length; i++)
			{
				if (state[num].targets[i].targetType == AnimationTargetType.Tag)
				{
					state[num].targets[i].target = GameObject.FindWithTag(state[num].targets[i].tagName);
				}
				state[num].targets[i].target.transform.position = state[num].targets[i].targetTransform.position;
				state[num].targets[i].target.transform.rotation = state[num].targets[i].targetTransform.rotation;
				state[num].targets[i].target.transform.localScale = state[num].targets[i].targetTransform.localScale;
				if (state[num].targets[i].target.renderer != null)
				{
					state[num].targets[i].target.renderer.enabled = state[num].targets[i].render;
				}
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
