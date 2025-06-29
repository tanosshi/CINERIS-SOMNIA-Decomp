using System;
using UnityEngine;

[Serializable]
public class TitleCharacter : MonoBehaviour
{
	private GUITexture gui;

	private float random;

	private bool nowFlashing;

	public virtual void Awake()
	{
		gui = (GUITexture)GetComponent(typeof(GUITexture));
	}

	public virtual void Update()
	{
		random = UnityEngine.Random.Range(0f, 1f);
		if (!(random < 0.9994f))
		{
			Flash();
		}
		if (nowFlashing)
		{
			float a = gui.color.a - 0.2f * Time.deltaTime;
			Color color = gui.color;
			float num = (color.a = a);
			Color color2 = (gui.color = color);
		}
		else
		{
			float a2 = gui.color.a + 0.2f * Time.deltaTime;
			Color color4 = gui.color;
			float num2 = (color4.a = a2);
			Color color5 = (gui.color = color4);
		}
		if (!(gui.color.a < 128f))
		{
			int num3 = 128;
			Color color7 = gui.color;
			float num4 = (color7.a = num3);
			Color color8 = (gui.color = color7);
		}
		else if (!(gui.color.a > 0f))
		{
			nowFlashing = false;
		}
	}

	public virtual void Flash()
	{
		if (!nowFlashing)
		{
			nowFlashing = true;
		}
	}

	public virtual void Main()
	{
	}
}
