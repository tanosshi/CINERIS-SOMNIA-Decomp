using System;
using UnityEngine;

[Serializable]
public class Event_10_FadeScreen : MonoBehaviour
{
	public CtrlFadeScreen[] state;

	private BlackOutController black;

	public virtual void Start()
	{
		black = (BlackOutController)GameObject.Find("SystemObject").GetComponent(typeof(BlackOutController));
	}

	public virtual void FadeScreen(int num)
	{
		black.SetFadeSpeed(state[num].fadeTime);
		black.SetFadeColor(state[num].fadeColor);
		if (state[num].fadeType == FadeType.FadeIn)
		{
			black.FadeIn();
		}
		else
		{
			black.FadeOut();
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
