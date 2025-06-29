using System;
using UnityEngine;

[Serializable]
public class FootstepSwitchTrigger : MonoBehaviour
{
	public bool changeFootstep;

	public int footstepId;

	public bool changeFootEffect;

	public int footEffectId;

	public bool exitChangeFootstep;

	public int exitFootstepId;

	public bool exitChangeFootEffect;

	public int exitFootEffectId;

	private Player_Status status;

	public FootstepSwitchTrigger()
	{
		changeFootstep = true;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void OnTriggerEnter(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "NPC")
		{
			if (changeFootstep)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootstepId", footstepId);
			}
			if (changeFootEffect)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootEffectId", footEffectId);
				status.footEffectId = footEffectId;
			}
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "NPC")
		{
			if (changeFootstep)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootstepId", footstepId);
			}
			if (changeFootEffect)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootEffectId", footEffectId);
				status.footEffectId = footEffectId;
			}
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "NPC")
		{
			if (exitChangeFootstep)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootstepId", exitFootstepId);
			}
			if (exitChangeFootEffect)
			{
				collisionInfo.gameObject.SendMessage("ChangeFootEffectId", exitFootEffectId);
				status.footEffectId = exitFootEffectId;
			}
		}
	}

	public virtual void Main()
	{
	}
}
