using System;
using UnityEngine;

[Serializable]
public class TitleContentsController : MonoBehaviour
{
	public int cursorId;

	public AudioClip cursorSE;

	public string activeMessageEnter;

	public string activeMessageOver;

	public string activeMessageClick;

	public string activeMessageExit;

	public TitleScreenManager manager;

	public virtual void OnMouseEnter()
	{
		if (!manager.dontControl)
		{
			if (cursorSE != null && manager.cursor != cursorId)
			{
				audio.PlayOneShot(cursorSE, 0.6f);
			}
			manager.cursor = cursorId;
			manager.SendMessage(activeMessageEnter, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnMouseOver()
	{
		if (!manager.dontControl)
		{
			manager.SendMessage(activeMessageOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnMouseDown()
	{
		if (!manager.dontControl)
		{
			SingletonMonoBehaviour<NsInput>.Instance.SetMouseButtonFlag(true);
			manager.SendMessage(activeMessageClick, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnMouseExit()
	{
		if (!manager.dontControl)
		{
			manager.SendMessage(activeMessageExit, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Main()
	{
	}
}
