using System;
using UnityEngine;

[Serializable]
public class Event_28_GetItem : MonoBehaviour
{
	public CtrlGetItem[] state;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void GetItem(int num)
	{
		if (state[num].type == ItemType.Item)
		{
			status.item[state[num].itemId] = status.item[state[num].itemId] + state[num].amount;
			if (status.item[state[num].itemId] < 0)
			{
				status.item[state[num].itemId] = 0;
			}
		}
		else
		{
			status.file[state[num].itemId] = status.file[state[num].itemId] + state[num].amount;
			if (status.file[state[num].itemId] < 0)
			{
				status.file[state[num].itemId] = 0;
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
