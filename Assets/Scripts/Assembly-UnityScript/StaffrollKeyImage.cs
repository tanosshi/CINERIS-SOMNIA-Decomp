using System;
using UnityEngine;

[Serializable]
public class StaffrollKeyImage : MonoBehaviour
{
	public GUIText text;

	public GUITexture image1;

	public GUITexture image2;

	public GUITexture image3;

	public GUITexture image4;

	public bool greyAuto;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		float a = 0f;
		Color color = text.color;
		float num = (color.a = a);
		Color color2 = (text.color = color);
		float a2 = 0f;
		Color color4 = image1.color;
		float num2 = (color4.a = a2);
		Color color5 = (image1.color = color4);
		float a3 = 0f;
		Color color7 = image2.color;
		float num3 = (color7.a = a3);
		Color color8 = (image2.color = color7);
		float a4 = 0f;
		Color color10 = image3.color;
		float num4 = (color10.a = a4);
		Color color11 = (image3.color = color10);
		float a5 = 0f;
		Color color13 = image4.color;
		float num5 = (color13.a = a5);
		Color color14 = (image4.color = color13);
		int num6 = 0;
		if (status.switches[533] == 1)
		{
			num6++;
		}
		else if (greyAuto)
		{
			float r = 0.06274f;
			Color color16 = image1.color;
			float num7 = (color16.r = r);
			Color color17 = (image1.color = color16);
			float g = 0.06274f;
			Color color19 = image1.color;
			float num8 = (color19.g = g);
			Color color20 = (image1.color = color19);
			float b = 0.06274f;
			Color color22 = image1.color;
			float num9 = (color22.b = b);
			Color color23 = (image1.color = color22);
		}
		else
		{
			image1.enabled = false;
		}
		if (status.switches[661] == 1)
		{
			num6++;
		}
		else if (greyAuto)
		{
			float r2 = 0.06274f;
			Color color25 = image2.color;
			float num10 = (color25.r = r2);
			Color color26 = (image2.color = color25);
			float g2 = 0.06274f;
			Color color28 = image2.color;
			float num11 = (color28.g = g2);
			Color color29 = (image2.color = color28);
			float b2 = 0.06274f;
			Color color31 = image2.color;
			float num12 = (color31.b = b2);
			Color color32 = (image2.color = color31);
		}
		else
		{
			image2.enabled = false;
		}
		if (status.switches[419] == 1)
		{
			num6++;
		}
		else if (greyAuto)
		{
			float r3 = 0.06274f;
			Color color34 = image3.color;
			float num13 = (color34.r = r3);
			Color color35 = (image3.color = color34);
			float g3 = 0.06274f;
			Color color37 = image3.color;
			float num14 = (color37.g = g3);
			Color color38 = (image3.color = color37);
			float b3 = 0.06274f;
			Color color40 = image3.color;
			float num15 = (color40.b = b3);
			Color color41 = (image3.color = color40);
		}
		else
		{
			image3.enabled = false;
		}
		if (status.switches[178] == 1)
		{
			num6++;
		}
		else if (greyAuto)
		{
			float r4 = 0.06274f;
			Color color43 = image4.color;
			float num16 = (color43.r = r4);
			Color color44 = (image4.color = color43);
			float g4 = 0.06274f;
			Color color46 = image4.color;
			float num17 = (color46.g = g4);
			Color color47 = (image4.color = color46);
			float b4 = 0.06274f;
			Color color49 = image4.color;
			float num18 = (color49.b = b4);
			Color color50 = (image4.color = color49);
		}
		else
		{
			image4.enabled = false;
		}
		if (!greyAuto)
		{
			int num19 = default(int);
			int num20 = default(int);
			if (num6 == 1)
			{
				num19 = -128;
				if (status.switches[533] == 1)
				{
					int num21 = num19;
					Rect pixelInset = image1.pixelInset;
					float num22 = (pixelInset.x = num21);
					Rect rect = (image1.pixelInset = pixelInset);
				}
				if (status.switches[661] == 1)
				{
					int num24 = num19;
					Rect pixelInset2 = image2.pixelInset;
					float num25 = (pixelInset2.x = num24);
					Rect rect3 = (image2.pixelInset = pixelInset2);
				}
				if (status.switches[419] == 1)
				{
					int num27 = num19;
					Rect pixelInset3 = image3.pixelInset;
					float num28 = (pixelInset3.x = num27);
					Rect rect5 = (image3.pixelInset = pixelInset3);
				}
				if (status.switches[178] == 1)
				{
					int num30 = num19;
					Rect pixelInset4 = image4.pixelInset;
					float num31 = (pixelInset4.x = num30);
					Rect rect7 = (image4.pixelInset = pixelInset4);
				}
			}
			if (num6 == 2)
			{
				num20 = 0;
				num19 = -192;
				if (status.switches[533] == 1)
				{
					int num33 = num19 + 128 * num20;
					Rect pixelInset5 = image1.pixelInset;
					float num34 = (pixelInset5.x = num33);
					Rect rect9 = (image1.pixelInset = pixelInset5);
					num20++;
				}
				if (status.switches[661] == 1)
				{
					int num36 = num19 + 128 * num20;
					Rect pixelInset6 = image2.pixelInset;
					float num37 = (pixelInset6.x = num36);
					Rect rect11 = (image2.pixelInset = pixelInset6);
					num20++;
				}
				if (status.switches[419] == 1)
				{
					int num39 = num19 + 128 * num20;
					Rect pixelInset7 = image3.pixelInset;
					float num40 = (pixelInset7.x = num39);
					Rect rect13 = (image3.pixelInset = pixelInset7);
					num20++;
				}
				if (status.switches[178] == 1)
				{
					int num42 = num19 + 128 * num20;
					Rect pixelInset8 = image4.pixelInset;
					float num43 = (pixelInset8.x = num42);
					Rect rect15 = (image4.pixelInset = pixelInset8);
					num20++;
				}
			}
			if (num6 == 3)
			{
				num20 = 0;
				num19 = -256;
				if (status.switches[533] == 1)
				{
					int num45 = num19 + 128 * num20;
					Rect pixelInset9 = image1.pixelInset;
					float num46 = (pixelInset9.x = num45);
					Rect rect17 = (image1.pixelInset = pixelInset9);
					num20++;
				}
				if (status.switches[661] == 1)
				{
					int num48 = num19 + 128 * num20;
					Rect pixelInset10 = image2.pixelInset;
					float num49 = (pixelInset10.x = num48);
					Rect rect19 = (image2.pixelInset = pixelInset10);
					num20++;
				}
				if (status.switches[419] == 1)
				{
					int num51 = num19 + 128 * num20;
					Rect pixelInset11 = image3.pixelInset;
					float num52 = (pixelInset11.x = num51);
					Rect rect21 = (image3.pixelInset = pixelInset11);
					num20++;
				}
				if (status.switches[178] == 1)
				{
					int num54 = num19 + 128 * num20;
					Rect pixelInset12 = image4.pixelInset;
					float num55 = (pixelInset12.x = num54);
					Rect rect23 = (image4.pixelInset = pixelInset12);
					num20++;
				}
			}
		}
		if (status.language == 0)
		{
			text.text = "灰の欠片 " + num6.ToString() + " / 4";
		}
		else
		{
			text.text = "Chunk of Ash " + num6.ToString() + " / 4";
		}
	}

	public virtual void FadeIn()
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 0.5f, "time", 4f, "onupdate", "ChangeAlpha"));
	}

	public virtual void ChangeAlpha(float alpha)
	{
		float a = alpha * 2f;
		Color color = text.color;
		float num = (color.a = a);
		Color color2 = (text.color = color);
		Color color4 = image1.color;
		float num2 = (color4.a = alpha);
		Color color5 = (image1.color = color4);
		Color color7 = image2.color;
		float num3 = (color7.a = alpha);
		Color color8 = (image2.color = color7);
		Color color10 = image3.color;
		float num4 = (color10.a = alpha);
		Color color11 = (image3.color = color10);
		Color color13 = image4.color;
		float num5 = (color13.a = alpha);
		Color color14 = (image4.color = color13);
	}

	public virtual void Main()
	{
	}
}
