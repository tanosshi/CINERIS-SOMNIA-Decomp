using System;
using UnityEngine;

[Serializable]
public class LightSwitchTrigger : MonoBehaviour
{
	public Light lightA;

	public Light lightB;

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
		if (((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player")
		{
			lightB.enabled = true;
			lightA.enabled = false;
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player" && lightA.enabled)
		{
			lightA.enabled = false;
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player")
		{
			lightA.enabled = true;
			lightB.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
