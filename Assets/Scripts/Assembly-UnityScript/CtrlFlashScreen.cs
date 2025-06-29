using System;
using UnityEngine;

[Serializable]
public class CtrlFlashScreen
{
	public Color flashColor;

	public float flashTime;

	public CtrlFlashScreen()
	{
		flashTime = 1f;
	}
}
