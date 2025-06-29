using System;
using UnityEngine;

[Serializable]
public class ButterflyStartFly : MonoBehaviour
{
	public SinMove moveScript;

	public SinRotate rotateScript;

	public ButterflyController controllerScript;

	public SinRotate wingRotateScriptL;

	public SinRotate wingRotateScriptR;

	public virtual void StartFly()
	{
		moveScript.enabled = true;
		rotateScript.enabled = true;
		controllerScript.enabled = false;
		wingRotateScriptL.enabled = true;
		wingRotateScriptR.enabled = true;
		SendMessage("Play", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void StopFly()
	{
		moveScript.enabled = false;
		rotateScript.enabled = false;
		controllerScript.enabled = true;
		wingRotateScriptL.enabled = false;
		wingRotateScriptR.enabled = false;
	}

	public virtual void Main()
	{
	}
}
