using System;
using UnityEngine;

[Serializable]
public class CtrlPicture
{
	public int pictureNumber;

	public Texture2D pictureGraphic;

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
}
