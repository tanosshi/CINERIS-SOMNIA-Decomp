using System;
using UnityEngine;

[Serializable]
public class AutoActive : MonoBehaviour
{
	public ActiveObjects[] objects;

	public bool once;

	private Player_Status playerStatus;

	private int i;

	public virtual void Start()
	{
		playerStatus = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		for (i = 0; i < objects.Length; i++)
		{
			if (playerStatus.switches[objects[i].switchIsOn] == 1)
			{
				objects[i].target.SetActive(objects[i].active);
			}
		}
	}

	public virtual void Update()
	{
		if (once)
		{
			return;
		}
		for (i = 0; i < objects.Length; i++)
		{
			if (playerStatus.switches[objects[i].switchIsOn] == 1)
			{
				objects[i].target.SetActive(objects[i].active);
			}
		}
	}

	public virtual void Main()
	{
	}
}
