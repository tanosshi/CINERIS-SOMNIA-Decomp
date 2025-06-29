using System;
using UnityEngine;

[Serializable]
public class Event_22_ChangeCameraInfo : MonoBehaviour
{
	public CtrlCameraInfo[] state;

	private Camera[] cameras;

	private int i;

	public virtual void Start()
	{
		cameras = new Camera[state.Length];
		for (i = 0; i < state.Length; i++)
		{
			if (state[i].targetCamera != null)
			{
				cameras[i] = (Camera)state[i].targetCamera.GetComponent(typeof(Camera));
			}
		}
	}

	public virtual void ChangeCameraInfo(int num)
	{
		if (state[num].targetType == AnimationTargetType.Tag)
		{
			cameras[num] = (Camera)GameObject.FindWithTag(state[num].tagName).GetComponent(typeof(Camera));
		}
		if (state[num].operation == DisableOrEnable.Disabled)
		{
			cameras[num].enabled = false;
		}
		else
		{
			cameras[num].enabled = true;
		}
		if (state[num].changeFieldOfView)
		{
			cameras[num].fieldOfView = state[num].fieldOfView;
		}
		if (state[num].changeClippingPlanes)
		{
			cameras[num].nearClipPlane = state[num].nearClippingPlane;
			cameras[num].farClipPlane = state[num].farClippingPlane;
		}
		if (state[num].changeDepth)
		{
			cameras[num].depth = state[num].depth;
		}
		if (state[num].changeMaxRot)
		{
			((Camera_Controller)cameras[num].gameObject.GetComponent(typeof(Camera_Controller))).maxRot = state[num].maxRot;
		}
		if (state[num].changeRot)
		{
			StartCoroutine_Auto(((Camera_Controller)cameras[num].gameObject.GetComponent(typeof(Camera_Controller))).FixedRotForce(state[num].rotX, state[num].rotY));
		}
		if (state[num].changeLookAtTarget)
		{
			if (state[num].lookAtTarget != null)
			{
				cameras[num].gameObject.SendMessage("ChangeLookAtTarget", state[num].lookAtTarget, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				cameras[num].gameObject.SendMessage("StopLookAtTarget", SendMessageOptions.DontRequireReceiver);
			}
		}
		if (state[num].changeDistance)
		{
			cameras[num].gameObject.SendMessage("ChangeDistance", state[num].distance, SendMessageOptions.DontRequireReceiver);
		}
		if (state[num].changeWidth)
		{
			cameras[num].gameObject.SendMessage("ChangeWidth", state[num].width, SendMessageOptions.DontRequireReceiver);
		}
		if (state[num].endSwitch)
		{
			cameras[num].gameObject.SendMessage("EndSwitch", SendMessageOptions.DontRequireReceiver);
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
