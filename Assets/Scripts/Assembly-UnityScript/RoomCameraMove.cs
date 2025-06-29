using System;
using UnityEngine;

[Serializable]
public class RoomCameraMove : MonoBehaviour
{
	public Transform player;

	public NavMeshAgent navagent;

	public float stopDistance;

	public float startDistance;

	public float slowDistance;

	public float farSpeed;

	public float nearSpeed;

	public float fadeSpeed;

	public RoomCameraMove()
	{
		stopDistance = 4f;
		startDistance = 8f;
		slowDistance = 6f;
		farSpeed = 4f;
		nearSpeed = 2f;
		fadeSpeed = 4f;
	}

	public virtual void Start()
	{
		navagent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
		navagent.SetDestination(player.position);
	}

	public virtual void Update()
	{
		if (!((transform.position - player.position).magnitude > stopDistance))
		{
			navagent.Stop();
		}
		else if (!((transform.position - player.position).magnitude < startDistance))
		{
			navagent.speed = Mathf.SmoothStep(0f, farSpeed, fadeSpeed);
			navagent.SetDestination(player.position);
		}
		else if (!((transform.position - player.position).magnitude > slowDistance))
		{
			navagent.speed = Mathf.SmoothStep(navagent.speed, nearSpeed, fadeSpeed);
			navagent.SetDestination(player.position);
		}
	}

	public virtual void Main()
	{
	}
}
