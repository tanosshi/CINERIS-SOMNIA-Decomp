using System;
using UnityEngine;

[Serializable]
public class CtrlChangeLevel
{
	public string nextLevelName;

	public int nextLevelId;

	public float nextPlayerX;

	public float nextPlayerY;

	public float nextPlayerZ;

	public float nextPlayerRotate;

	public float nextCameraX;

	public float nextCameraY;

	public float nextCameraZ;

	public float nextCameraRotX;

	public float nextCameraRotY;

	public int startSEId;

	public int endSEId;

	public bool fade;

	public float fadeSpeed;

	public bool audioFade;

	public float audioFadeSpeed;

	public Color fadeColor;

	public CtrlChangeLevel()
	{
		fadeColor = Color.black;
	}
}
