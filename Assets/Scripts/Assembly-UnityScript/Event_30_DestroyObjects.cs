using System;
using UnityEngine;

[Serializable]
public class Event_30_DestroyObjects : MonoBehaviour
{
	public CtrlDestroyObjects[] state;

	private int i;

	public virtual void DestroyObjects(int num)
	{
		if (state[num].targetType == AnimationTargetType.Tag)
		{
			state[num].targets = GameObject.FindGameObjectsWithTag(state[num].tagName);
		}
		for (i = 0; i < state[num].targets.Length; i++)
		{
			UnityEngine.Object.Destroy(state[num].targets[i].gameObject);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
