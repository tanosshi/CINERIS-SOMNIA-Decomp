using System;
using UnityEngine;

[Serializable]
public class Event_14_MovePicture : MonoBehaviour
{
	public CtrlMovePicture[] state;

	private Player_Status status;

	private int i;

	private GUITexture[] guiTex;

	private Color[] guiColor;

	private float[] guiX;

	private float[] guiY;

	private float[] guiWidth;

	private float[] guiHeight;

	private float[] startTime;

	private Color[] guiColorFirst;

	private float[] guiXFirst;

	private float[] guiYFirst;

	private float[] guiWidthFirst;

	private float[] guiHeightFirst;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		guiTex = new GUITexture[state.Length];
		guiColor = new Color[state.Length];
		guiX = new float[state.Length];
		guiY = new float[state.Length];
		guiWidth = new float[state.Length];
		guiHeight = new float[state.Length];
		guiColorFirst = new Color[state.Length];
		guiXFirst = new float[state.Length];
		guiYFirst = new float[state.Length];
		guiWidthFirst = new float[state.Length];
		guiHeightFirst = new float[state.Length];
		for (i = 0; i < state.Length; i++)
		{
			guiTex[i] = (GUITexture)GameObject.Find("Picture" + state[i].pictureNumber.ToString()).GetComponent(typeof(GUITexture));
			guiColor[i] = Color.gray;
			guiX[i] = 0f;
			guiY[i] = 0f;
			guiWidth[i] = 0f;
			guiHeight[i] = 0f;
			guiColorFirst[i] = Color.gray;
			guiXFirst[i] = 0f;
			guiYFirst[i] = 0f;
			guiWidthFirst[i] = 0f;
			guiHeightFirst[i] = 0f;
		}
		startTime = new float[state.Length];
	}

	public virtual void Update()
	{
		if (state.Length == 0)
		{
			return;
		}
		for (i = 0; i < state.Length; i++)
		{
			if (guiTex[i].texture != null)
			{
				if (state[i].ShowMoveFlag())
				{
					startTime[i] += Time.deltaTime * 1f;
					float num = Mathf.Lerp(guiXFirst[i], guiX[i], startTime[i] / state[i].time);
					Rect pixelInset = guiTex[i].pixelInset;
					float num2 = (pixelInset.x = num);
					Rect rect = (guiTex[i].pixelInset = pixelInset);
					float num4 = Mathf.Lerp(guiYFirst[i], guiY[i], startTime[i] / state[i].time);
					Rect pixelInset2 = guiTex[i].pixelInset;
					float num5 = (pixelInset2.y = num4);
					Rect rect3 = (guiTex[i].pixelInset = pixelInset2);
					float num7 = Mathf.Lerp(guiWidthFirst[i], guiWidth[i], startTime[i] / state[i].time);
					Rect pixelInset3 = guiTex[i].pixelInset;
					float num8 = (pixelInset3.width = num7);
					Rect rect5 = (guiTex[i].pixelInset = pixelInset3);
					float num10 = Mathf.Lerp(guiHeightFirst[i], guiHeight[i], startTime[i] / state[i].time);
					Rect pixelInset4 = guiTex[i].pixelInset;
					float num11 = (pixelInset4.height = num10);
					Rect rect7 = (guiTex[i].pixelInset = pixelInset4);
					float r = Mathf.Lerp(guiColorFirst[i].r, guiColor[i].r, startTime[i] / state[i].time);
					Color color = guiTex[i].color;
					float num13 = (color.r = r);
					Color color2 = (guiTex[i].color = color);
					float g = Mathf.Lerp(guiColorFirst[i].g, guiColor[i].g, startTime[i] / state[i].time);
					Color color4 = guiTex[i].color;
					float num14 = (color4.g = g);
					Color color5 = (guiTex[i].color = color4);
					float b = Mathf.Lerp(guiColorFirst[i].b, guiColor[i].b, startTime[i] / state[i].time);
					Color color7 = guiTex[i].color;
					float num15 = (color7.b = b);
					Color color8 = (guiTex[i].color = color7);
					float a = Mathf.Lerp(guiColorFirst[i].a, guiColor[i].a, startTime[i] / state[i].time);
					Color color10 = guiTex[i].color;
					float num16 = (color10.a = a);
					Color color11 = (guiTex[i].color = color10);
					if (!(Mathf.Abs(guiWidth[i] - guiTex[i].pixelInset.width) > 0.0001f) && !(Mathf.Abs(guiHeight[i] - guiTex[i].pixelInset.height) > 0.0001f) && !(Mathf.Abs(guiX[i] - guiTex[i].pixelInset.x) > 0.0001f) && !(Mathf.Abs(guiY[i] - guiTex[i].pixelInset.y) > 0.0001f) && !(Mathf.Abs(guiColor[i].a - guiTex[i].color.a) > 0.0001f) && !(Mathf.Abs(guiColor[i].r - guiTex[i].color.r) > 0.0001f) && !(Mathf.Abs(guiColor[i].g - guiTex[i].color.g) > 0.0001f) && !(Mathf.Abs(guiColor[i].b - guiTex[i].color.b) > 0.0001f))
					{
						float num17 = guiX[i];
						Rect pixelInset5 = guiTex[i].pixelInset;
						float num18 = (pixelInset5.x = num17);
						Rect rect9 = (guiTex[i].pixelInset = pixelInset5);
						float num20 = guiY[i];
						Rect pixelInset6 = guiTex[i].pixelInset;
						float num21 = (pixelInset6.y = num20);
						Rect rect11 = (guiTex[i].pixelInset = pixelInset6);
						float num23 = guiWidth[i];
						Rect pixelInset7 = guiTex[i].pixelInset;
						float num24 = (pixelInset7.width = num23);
						Rect rect13 = (guiTex[i].pixelInset = pixelInset7);
						float num26 = guiHeight[i];
						Rect pixelInset8 = guiTex[i].pixelInset;
						float num27 = (pixelInset8.height = num26);
						Rect rect15 = (guiTex[i].pixelInset = pixelInset8);
						guiTex[i].color = guiColor[i];
						state[i].CtrlMoveFlag(false);
					}
				}
			}
			else
			{
				state[i].CtrlMoveFlag(false);
			}
		}
	}

	public virtual void MovePicture(int num)
	{
		guiColor[num] = state[num].pictureColor;
		if (state[num].sizeTypeX == PictureSizeType.Constant)
		{
			guiWidth[num] = state[num].sizeNumberX;
		}
		else if (state[num].sizeTypeX == PictureSizeType.Variable)
		{
			guiWidth[num] = status.variables[(int)state[num].sizeNumberX];
		}
		else
		{
			guiWidth[num] = (float)Screen.width * state[num].sizeNumberX;
		}
		if (state[num].sizeTypeY == PictureSizeType.Constant)
		{
			guiHeight[num] = state[num].sizeNumberY;
		}
		else if (state[num].sizeTypeY == PictureSizeType.Variable)
		{
			guiHeight[num] = status.variables[(int)state[num].sizeNumberY];
		}
		else
		{
			guiHeight[num] = (float)Screen.height * state[num].sizeNumberY;
		}
		if (state[num].UseOriginalAspectFix == AspectFixType.Horizontal)
		{
			guiHeight[num] = (float)guiTex[num].texture.height * (guiWidth[num] / (float)guiTex[num].texture.width);
		}
		else if (state[num].UseOriginalAspectFix == AspectFixType.Vertical)
		{
			guiWidth[num] = (float)guiTex[num].texture.width * (guiHeight[num] / (float)guiTex[num].texture.height);
		}
		if (state[num].origin == PictureOriginType.UpperLeft)
		{
			guiX[num] = 0f;
			guiY[num] = (float)Screen.height - guiHeight[num];
		}
		else
		{
			guiX[num] = 0f - guiWidth[num] / 2f;
			guiY[num] = (float)Screen.height - guiHeight[num] + guiHeight[num] / 2f;
		}
		if (state[num].displayPositionType == PictureSizeType.Constant)
		{
			guiX[num] += state[num].positionNumberX;
			guiY[num] -= state[num].positionNumberY;
		}
		else if (state[num].displayPositionType == PictureSizeType.Variable)
		{
			guiX[num] += status.variables[(int)state[num].positionNumberX];
			guiY[num] -= status.variables[(int)state[num].positionNumberY];
		}
		else
		{
			guiX[num] += (float)Screen.width * state[num].positionNumberX;
			guiY[num] -= (float)Screen.height * state[num].positionNumberY;
		}
		guiXFirst[num] = guiTex[num].pixelInset.x;
		guiYFirst[num] = guiTex[num].pixelInset.y;
		guiWidthFirst[num] = guiTex[num].pixelInset.width;
		guiHeightFirst[num] = guiTex[num].pixelInset.height;
		guiColorFirst[num] = guiTex[num].color;
		startTime[num] = 0f;
		state[num].CtrlMoveFlag(true);
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
