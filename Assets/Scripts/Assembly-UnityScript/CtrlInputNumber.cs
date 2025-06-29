using System;
using UnityEngine;

[Serializable]
public class CtrlInputNumber
{
	public string firstText_Jap;

	public string firstText_Eng;

	public int length;

	public int variableNumber;

	public Font font;

	public TextAnchor anchor;

	public CtrlInputNumber()
	{
		anchor = TextAnchor.LowerCenter;
	}
}
