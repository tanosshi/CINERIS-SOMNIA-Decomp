using System;
using UnityEngine;

[Serializable]
public class ToggleComponent_Girl3 : MonoBehaviour
{
	private NavMeshAgent navagent;

	private Girl3Controller controller;

	public virtual void Start()
	{
		navagent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
		controller = (Girl3Controller)GetComponent(typeof(Girl3Controller));
	}

	public virtual void ToggleComponent(int num)
	{
		if (num == 0)
		{
			SendMessage("AnimationManager", (object)0);
			navagent.enabled = false;
			controller.enabled = false;
		}
		else
		{
			navagent.enabled = true;
			controller.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
