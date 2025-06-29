using System;
using UnityEngine;

[Serializable]
public class Event_21_ChangeMenuAccess : MonoBehaviour
{
	public CtrlMenuAccess[] state;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void ChangeMenuAccess(int num)
	{
		switch (state[num].type)
		{
		case MenuAccessType.Pause:
			if (state[num].operation == DisableOrEnable.Disabled)
			{
				status.pausePermission = false;
			}
			else
			{
				status.pausePermission = true;
			}
			break;
		case MenuAccessType.Load:
			if (state[num].operation == DisableOrEnable.Disabled)
			{
				status.loadPermission = false;
			}
			else
			{
				status.loadPermission = true;
			}
			break;
		case MenuAccessType.Save:
			if (state[num].operation == DisableOrEnable.Disabled)
			{
				status.savePermission = false;
			}
			else
			{
				status.savePermission = true;
			}
			break;
		case MenuAccessType.Menu:
			if (state[num].operation == DisableOrEnable.Disabled)
			{
				status.menuPermission = false;
			}
			else
			{
				status.menuPermission = true;
			}
			break;
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
