using System;
using UnityEngine;

[Serializable]
public class Event_29_ChangeActive : MonoBehaviour
{
	public CtrlChangeActive[] state;

	public virtual void ChangeActive(int num)
	{
		state[num].target.SetActive(state[num].active);
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
