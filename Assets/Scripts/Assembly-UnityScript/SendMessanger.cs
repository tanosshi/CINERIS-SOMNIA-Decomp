using System;
using UnityEngine;

[Serializable]
public class SendMessanger : MonoBehaviour
{
	public GameObject target;

	public string messageName;

	public int number;

	public virtual void SendMessageAction()
	{
		target.SendMessage(messageName, number, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void Main()
	{
	}
}
