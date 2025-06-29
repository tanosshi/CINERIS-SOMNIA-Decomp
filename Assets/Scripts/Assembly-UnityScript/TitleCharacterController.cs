using System;
using UnityEngine;

[Serializable]
public class TitleCharacterController : MonoBehaviour
{
	public OptionsMenu optionMenu;

	public TitleCredits creditsMenu;

	public float fadeSpeed;

	private GUITexture myTexture;

	public virtual void Start()
	{
		myTexture = (GUITexture)GetComponent(typeof(GUITexture));
	}

	public virtual void Update()
	{
		if (optionMenu.nowOptioning || creditsMenu.nowCredits)
		{
			float a = Mathf.Lerp(myTexture.color.a, 0f, fadeSpeed * Time.deltaTime);
			Color color = myTexture.color;
			float num = (color.a = a);
			Color color2 = (myTexture.color = color);
			if (!(myTexture.color.a > 0.01f))
			{
				float a2 = 0f;
				Color color4 = myTexture.color;
				float num2 = (color4.a = a2);
				Color color5 = (myTexture.color = color4);
			}
		}
		else
		{
			float a3 = Mathf.Lerp(myTexture.color.a, 0.5f, fadeSpeed * Time.deltaTime);
			Color color7 = myTexture.color;
			float num3 = (color7.a = a3);
			Color color8 = (myTexture.color = color7);
			if (!(myTexture.color.a < 0.49f))
			{
				float a4 = 0.5f;
				Color color10 = myTexture.color;
				float num4 = (color10.a = a4);
				Color color11 = (myTexture.color = color10);
			}
		}
	}

	public virtual void Main()
	{
	}
}
