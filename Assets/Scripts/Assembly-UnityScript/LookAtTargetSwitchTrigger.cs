using System;
using UnityEngine;

[Serializable]
public class LookAtTargetSwitchTrigger : MonoBehaviour
{
	public GameObject targetA;

	public GameObject targetB;

	public bool freeLookEnter;

	public bool freeLookExit;

	public bool useStartSwitch;

	public int startSwitchNumber;

	public bool useStopSwitch;

	public int stopSwitchNumber;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void OnTriggerEnter(Collider collisionInfo)
	{
		if (((!useStartSwitch || status.switches[startSwitchNumber] != 1) && useStartSwitch) || ((!useStopSwitch || status.switches[stopSwitchNumber] == 1) && useStopSwitch) || !(collisionInfo.gameObject.tag == "Player"))
		{
			return;
		}
		if (status.saveLoadFlag != 2 && status.saveLoadFlag != 3)
		{
			if (targetB != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetB);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookEnter);
		}
		else if (!(Time.timeSinceLevelLoad < 0.2f))
		{
			if (targetB != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetB);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookEnter);
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (((!useStartSwitch || status.switches[startSwitchNumber] != 1) && useStartSwitch) || ((!useStopSwitch || status.switches[stopSwitchNumber] == 1) && useStopSwitch) || !status.nowPausing || status.nowEventing || !(collisionInfo.gameObject.tag == "Player"))
		{
			return;
		}
		if (status.saveLoadFlag != 2 && status.saveLoadFlag != 3)
		{
			if (targetB != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetB);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookEnter);
		}
		else if (!(Time.timeSinceLevelLoad < 0.2f))
		{
			if (targetB != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetB);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookEnter);
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (((!useStartSwitch || status.switches[startSwitchNumber] != 1) && useStartSwitch) || ((!useStopSwitch || status.switches[stopSwitchNumber] == 1) && useStopSwitch) || !(collisionInfo.gameObject.tag == "Player"))
		{
			return;
		}
		if (status.saveLoadFlag != 2 && status.saveLoadFlag != 3)
		{
			if (targetA != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetA);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookExit);
		}
		else if (!(Time.timeSinceLevelLoad < 0.2f))
		{
			if (targetA != null)
			{
				collisionInfo.gameObject.SendMessage("SetLookAtTarget", targetA);
			}
			else
			{
				collisionInfo.gameObject.SendMessage("DeleteLookAtTarget");
			}
			collisionInfo.gameObject.SendMessage("ChangeFreeLook", freeLookExit);
		}
	}

	public virtual void Main()
	{
	}
}
