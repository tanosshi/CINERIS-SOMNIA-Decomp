using System;
using UnityEngine;

[Serializable]
public class Event_13_ShowPicture : MonoBehaviour
{
	public CtrlPicture[] state;

	private Player_Status status;

	private GUITexture guiTex;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void ShowPicture(int num)
	{
		guiTex = (GUITexture)GameObject.Find("Picture" + state[num].pictureNumber.ToString()).GetComponent(typeof(GUITexture));
		if (state[num].sizeTypeX == PictureSizeType.Constant)
		{
			float sizeNumberX = state[num].sizeNumberX;
			Rect pixelInset = guiTex.pixelInset;
			float num2 = (pixelInset.width = sizeNumberX);
			Rect rect = (guiTex.pixelInset = pixelInset);
			float x = 0f;
			Vector3 localScale = guiTex.transform.localScale;
			float num4 = (localScale.x = x);
			Vector3 vector = (guiTex.transform.localScale = localScale);
		}
		else if (state[num].sizeTypeX == PictureSizeType.Variable)
		{
			float num5 = status.variables[(int)state[num].sizeNumberX];
			Rect pixelInset2 = guiTex.pixelInset;
			float num6 = (pixelInset2.width = num5);
			Rect rect3 = (guiTex.pixelInset = pixelInset2);
			float x2 = 0f;
			Vector3 localScale2 = guiTex.transform.localScale;
			float num8 = (localScale2.x = x2);
			Vector3 vector3 = (guiTex.transform.localScale = localScale2);
		}
		else
		{
			float num9 = (float)Screen.width * state[num].sizeNumberX;
			Rect pixelInset3 = guiTex.pixelInset;
			float num10 = (pixelInset3.width = num9);
			Rect rect5 = (guiTex.pixelInset = pixelInset3);
			float x3 = 0f;
			Vector3 localScale3 = guiTex.transform.localScale;
			float num12 = (localScale3.x = x3);
			Vector3 vector5 = (guiTex.transform.localScale = localScale3);
		}
		if (state[num].sizeTypeY == PictureSizeType.Constant)
		{
			float sizeNumberY = state[num].sizeNumberY;
			Rect pixelInset4 = guiTex.pixelInset;
			float num13 = (pixelInset4.height = sizeNumberY);
			Rect rect7 = (guiTex.pixelInset = pixelInset4);
			float y = 0f;
			Vector3 localScale4 = guiTex.transform.localScale;
			float num15 = (localScale4.y = y);
			Vector3 vector7 = (guiTex.transform.localScale = localScale4);
		}
		else if (state[num].sizeTypeY == PictureSizeType.Variable)
		{
			float num16 = status.variables[(int)state[num].sizeNumberY];
			Rect pixelInset5 = guiTex.pixelInset;
			float num17 = (pixelInset5.height = num16);
			Rect rect9 = (guiTex.pixelInset = pixelInset5);
			float y2 = 0f;
			Vector3 localScale5 = guiTex.transform.localScale;
			float num19 = (localScale5.y = y2);
			Vector3 vector9 = (guiTex.transform.localScale = localScale5);
		}
		else
		{
			float num20 = (float)Screen.height * state[num].sizeNumberY;
			Rect pixelInset6 = guiTex.pixelInset;
			float num21 = (pixelInset6.height = num20);
			Rect rect11 = (guiTex.pixelInset = pixelInset6);
			float y3 = 0f;
			Vector3 localScale6 = guiTex.transform.localScale;
			float num23 = (localScale6.y = y3);
			Vector3 vector11 = (guiTex.transform.localScale = localScale6);
		}
		if (state[num].UseOriginalAspectFix == AspectFixType.Horizontal)
		{
			float num24 = (float)state[num].pictureGraphic.height * (guiTex.pixelInset.width / (float)state[num].pictureGraphic.width);
			Rect pixelInset7 = guiTex.pixelInset;
			float num25 = (pixelInset7.height = num24);
			Rect rect13 = (guiTex.pixelInset = pixelInset7);
		}
		else if (state[num].UseOriginalAspectFix == AspectFixType.Vertical)
		{
			float num27 = (float)state[num].pictureGraphic.width * (guiTex.pixelInset.height / (float)state[num].pictureGraphic.height);
			Rect pixelInset8 = guiTex.pixelInset;
			float num28 = (pixelInset8.width = num27);
			Rect rect15 = (guiTex.pixelInset = pixelInset8);
		}
		if (state[num].origin == PictureOriginType.UpperLeft)
		{
			float num30 = 0f;
			Rect pixelInset9 = guiTex.pixelInset;
			float num31 = (pixelInset9.x = num30);
			Rect rect17 = (guiTex.pixelInset = pixelInset9);
			float num33 = (float)Screen.height - guiTex.pixelInset.height;
			Rect pixelInset10 = guiTex.pixelInset;
			float num34 = (pixelInset10.y = num33);
			Rect rect19 = (guiTex.pixelInset = pixelInset10);
		}
		else
		{
			float num36 = 0f - guiTex.pixelInset.width / 2f;
			Rect pixelInset11 = guiTex.pixelInset;
			float num37 = (pixelInset11.x = num36);
			Rect rect21 = (guiTex.pixelInset = pixelInset11);
			float num39 = (float)Screen.height - guiTex.pixelInset.height + guiTex.pixelInset.height / 2f;
			Rect pixelInset12 = guiTex.pixelInset;
			float num40 = (pixelInset12.y = num39);
			Rect rect23 = (guiTex.pixelInset = pixelInset12);
		}
		if (state[num].displayPositionType == PictureSizeType.Constant)
		{
			float num42 = guiTex.pixelInset.x + state[num].positionNumberX;
			Rect pixelInset13 = guiTex.pixelInset;
			float num43 = (pixelInset13.x = num42);
			Rect rect25 = (guiTex.pixelInset = pixelInset13);
			float num45 = guiTex.pixelInset.y - state[num].positionNumberY;
			Rect pixelInset14 = guiTex.pixelInset;
			float num46 = (pixelInset14.y = num45);
			Rect rect27 = (guiTex.pixelInset = pixelInset14);
		}
		else if (state[num].displayPositionType == PictureSizeType.Variable)
		{
			float num48 = guiTex.pixelInset.x + status.variables[(int)state[num].positionNumberX];
			Rect pixelInset15 = guiTex.pixelInset;
			float num49 = (pixelInset15.x = num48);
			Rect rect29 = (guiTex.pixelInset = pixelInset15);
			float num51 = guiTex.pixelInset.y - status.variables[(int)state[num].positionNumberY];
			Rect pixelInset16 = guiTex.pixelInset;
			float num52 = (pixelInset16.y = num51);
			Rect rect31 = (guiTex.pixelInset = pixelInset16);
		}
		else
		{
			float num54 = guiTex.pixelInset.x + (float)Screen.width * state[num].positionNumberX;
			Rect pixelInset17 = guiTex.pixelInset;
			float num55 = (pixelInset17.x = num54);
			Rect rect33 = (guiTex.pixelInset = pixelInset17);
			float num57 = guiTex.pixelInset.y - (float)Screen.height * state[num].positionNumberY;
			Rect pixelInset18 = guiTex.pixelInset;
			float num58 = (pixelInset18.y = num57);
			Rect rect35 = (guiTex.pixelInset = pixelInset18);
		}
		guiTex.texture = state[num].pictureGraphic;
		guiTex.color = state[num].pictureColor;
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
