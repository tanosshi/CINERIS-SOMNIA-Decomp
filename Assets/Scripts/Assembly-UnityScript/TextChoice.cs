using System;
using UnityEngine;

[Serializable]
public class TextChoice
{
	public ChoiceFactor[] choices;

	public string firstText_Jap;

	public string firstText_Eng;

	public Font font;

	public TextPosition position;

	public TextAnchor anchor;

	public TextChoice()
	{
		position = TextPosition.Lower;
		anchor = TextAnchor.LowerCenter;
	}
}
