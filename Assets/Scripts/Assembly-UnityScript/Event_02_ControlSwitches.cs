using System;
using UnityEngine;

[Serializable]
public class Event_02_ControlSwitches : MonoBehaviour
{
	public CtrlSwitch[] state;

	private Player_Status status;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void ControlSwitches(int num)
	{
		if (state[num].switches.Length != 0)
		{
			for (i = 0; i < state[num].switches.Length; i++)
			{
				if (state[num].switches[i].operation == SwitchOperation.Off)
				{
					if (state[num].switches[i].switchType == SwitchType.Switch)
					{
						status.switches[state[num].switches[i].switchNumber] = 0;
					}
					else
					{
						status.tempSwitches[state[num].switches[i].switchNumber] = 0;
					}
				}
				else if (state[num].switches[i].switchType == SwitchType.Switch)
				{
					status.switches[state[num].switches[i].switchNumber] = 1;
				}
				else
				{
					status.tempSwitches[state[num].switches[i].switchNumber] = 1;
				}
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
