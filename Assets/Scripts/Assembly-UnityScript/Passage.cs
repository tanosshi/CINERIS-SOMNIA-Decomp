using System;
using UnityEngine;

[Serializable]
public class Passage
{
	public OneLinePassage[] pageAmount;

	public Font font;

	public TextPosition position;

	public TextAnchor anchor;

	public TextAlignment alignment;

	public AudioClip showSE;

	public float SeVolume;

	public bool changeOffset;

	public float offsetX;

	public float offsetY;

	public Passage()
	{
		position = TextPosition.Lower;
		anchor = TextAnchor.LowerCenter;
		alignment = TextAlignment.Center;
		SeVolume = 1f;
	}
}
