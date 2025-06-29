using System;
using UnityEngine;

[Serializable]
public class SpecimenRoomItemReset : MonoBehaviour
{
	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		int num = default(int);
		for (num = 0; num < 300; num++)
		{
			status.file[num] = 0;
		}
		status.loadPermission = false;
		status.savePermission = false;
	}

	public virtual void Main()
	{
	}
}
