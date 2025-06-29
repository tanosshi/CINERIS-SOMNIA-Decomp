using System;
using UnityEngine;

[Serializable]
public class ColorController : MonoBehaviour
{
	private Color fromColor;

	public Color toColor;

	public float fadeTime;

	private bool nowFade;

	private float tempTime;

	public virtual void Update()
	{
		if (nowFade)
		{
			tempTime += 1f * Time.deltaTime / fadeTime;
			gameObject.renderer.material.color = Color.Lerp(fromColor, toColor, tempTime);
			if (!(tempTime < 1f))
			{
				nowFade = false;
			}
		}
	}

	public virtual void FadeColor()
	{
		tempTime = 0f;
		nowFade = false;
		GetColor();
		nowFade = true;
	}

	public virtual void GetColor()
	{
		fromColor = gameObject.renderer.material.color;
	}

	public virtual void Main()
	{
	}
}
