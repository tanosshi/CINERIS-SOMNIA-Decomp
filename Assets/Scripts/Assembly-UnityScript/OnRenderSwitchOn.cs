using System;
using UnityEngine;

[Serializable]
public class OnRenderSwitchOn : MonoBehaviour
{
	public int activateSwitchNo;

	public int onSwitchNo;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void OnWillRenderObject()
	{
		if (Camera.current.tag == "MainCamera" && status.switches[activateSwitchNo] == 1 && status.switches[onSwitchNo] != 1 && !status.nowPausing && !(Time.timeSinceLevelLoad <= 2f))
		{
			status.switches[onSwitchNo] = 1;
		}
	}

	public virtual void Main()
	{
	}
}
