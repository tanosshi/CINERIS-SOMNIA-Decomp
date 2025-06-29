using System;
using UnityEngine;

[Serializable]
public class CtrlMovePicture
{
	public int pictureNumber;

	public float time;

	public AspectFixType UseOriginalAspectFix;

	public PictureSizeType sizeTypeX;

	public PictureSizeType sizeTypeY;

	public float sizeNumberX;

	public float sizeNumberY;

	public PictureOriginType origin;

	public PictureSizeType displayPositionType;

	public float positionNumberX;

	public float positionNumberY;

	public Color pictureColor;

	private bool moveFlag;

	public virtual bool ShowMoveFlag()
	{
		return moveFlag;
	}

	public virtual void CtrlMoveFlag(bool flag)
	{
		if (flag)
		{
			moveFlag = true;
		}
		else
		{
			moveFlag = false;
		}
	}
}
