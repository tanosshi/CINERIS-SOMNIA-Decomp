using System;
using UnityEngine;

[Serializable]
public class CameraInfoTrigger : MonoBehaviour
{
	public bool changeDistanceEnter;

	public float distanceEnter;

	public bool changeDistanceExit;

	public float distanceExit;

	public bool changeWidthEnter;

	public float widthEnter;

	public bool changeWidthExit;

	public float widthExit;

	public bool changeHeightEnter;

	public float heightEnter;

	public bool changeHeightExit;

	public float heightExit;

	public bool changeRotXEnter;

	public float rotXEnter;

	public bool changeRotXExit;

	public float rotXExit;

	public bool changeRotYEnter;

	public float rotYEnter;

	public bool changeRotYExit;

	public float rotYExit;

	public bool changeMaxRotEnter;

	public float maxRotEnter;

	public bool changeMaxRotExit;

	public float maxRotExit;

	public bool changeEscapeDistanceEnter;

	public float escapeDistanceEnter;

	public bool changeEscapeDistanceExit;

	public float escapeDistanceExit;

	public bool changeEscapeHeightEnter;

	public float escapeHeightEnter;

	public bool changeEscapeHeightExit;

	public float escapeHeightExit;

	public bool changeNearClipEnter;

	public float nearClipEnter;

	public bool changeNearClipExit;

	public float nearClipExit;

	public bool useStartSwitch;

	public int startSwitchNumber;

	public bool useStopSwitch;

	public int stopSwitchNumber;

	public bool stayFlag;

	private Player_Status status;

	private Camera_Controller cameraStatus;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		cameraStatus = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent("Camera_Controller");
	}

	public virtual void OnTriggerEnter(Collider collisionInfo)
	{
		if (((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player")
		{
			if (changeDistanceEnter)
			{
				cameraStatus.Distance = distanceEnter;
			}
			if (changeWidthEnter)
			{
				cameraStatus.Width = widthEnter;
			}
			if (changeHeightEnter)
			{
				cameraStatus.Height = heightEnter;
			}
			if (changeRotXEnter)
			{
				cameraStatus.RotX = rotXEnter;
			}
			if (changeRotYEnter)
			{
				cameraStatus.RotY = rotYEnter;
			}
			if (changeMaxRotEnter)
			{
				cameraStatus.maxRot = maxRotEnter;
			}
			if (changeEscapeDistanceEnter)
			{
				cameraStatus.cameraEscapeDistance = escapeDistanceEnter;
			}
			if (changeEscapeHeightEnter)
			{
				cameraStatus.cameraEscapeHeight = escapeHeightEnter;
			}
			if (changeNearClipEnter)
			{
				cameraStatus.gameObject.camera.nearClipPlane = nearClipEnter;
			}
		}
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (stayFlag && ((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player")
		{
			if (changeDistanceEnter)
			{
				cameraStatus.Distance = distanceEnter;
			}
			if (changeWidthEnter)
			{
				cameraStatus.Width = widthEnter;
			}
			if (changeHeightEnter)
			{
				cameraStatus.Height = heightEnter;
			}
			if (changeRotXEnter)
			{
				cameraStatus.RotX = rotXEnter;
			}
			if (changeRotYEnter)
			{
				cameraStatus.RotY = rotYEnter;
			}
			if (changeMaxRotEnter)
			{
				cameraStatus.maxRot = maxRotEnter;
			}
			if (changeEscapeDistanceEnter)
			{
				cameraStatus.cameraEscapeDistance = escapeDistanceEnter;
			}
			if (changeEscapeHeightEnter)
			{
				cameraStatus.cameraEscapeHeight = escapeHeightEnter;
			}
			if (changeNearClipEnter)
			{
				cameraStatus.gameObject.camera.nearClipPlane = nearClipEnter;
			}
		}
	}

	public virtual void OnTriggerExit(Collider collisionInfo)
	{
		if (((useStartSwitch && status.switches[startSwitchNumber] == 1) || !useStartSwitch) && ((useStopSwitch && status.switches[stopSwitchNumber] != 1) || !useStopSwitch) && collisionInfo.gameObject.tag == "Player")
		{
			if (changeDistanceExit)
			{
				cameraStatus.Distance = distanceExit;
			}
			if (changeWidthExit)
			{
				cameraStatus.Width = widthExit;
			}
			if (changeHeightExit)
			{
				cameraStatus.Height = heightExit;
			}
			if (changeRotXExit)
			{
				cameraStatus.RotX = rotXExit;
			}
			if (changeRotYExit)
			{
				cameraStatus.RotY = rotYExit;
			}
			if (changeMaxRotExit)
			{
				cameraStatus.maxRot = maxRotExit;
			}
			if (changeEscapeDistanceExit)
			{
				cameraStatus.cameraEscapeDistance = escapeDistanceExit;
			}
			if (changeEscapeHeightExit)
			{
				cameraStatus.cameraEscapeHeight = escapeHeightExit;
			}
			if (changeNearClipExit)
			{
				cameraStatus.gameObject.camera.nearClipPlane = nearClipExit;
			}
		}
	}

	public virtual void Main()
	{
	}
}
