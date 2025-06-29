using System;
using UnityEngine;

[Serializable]
public class TitleCreditsArrowController : MonoBehaviour
{
	public TitleCredits credits;

	public GUITexture myTexture;

	public Texture2D falseTex;

	public Texture2D trueTex;

	public AudioClip decideSE;

	public AudioClip cursorSE;

	public float scrollSpeed;

	public bool downFlag;

	public bool barFlag;

	private bool clickFlag;

	public virtual void OnEnable()
	{
		if (!barFlag)
		{
			myTexture.texture = falseTex;
			clickFlag = false;
		}
		else
		{
			clickFlag = false;
		}
	}

	public virtual void OnMouseEnter()
	{
		if (!barFlag)
		{
			if (cursorSE != null)
			{
				audio.PlayOneShot(cursorSE, 0.4f);
			}
			myTexture.texture = trueTex;
		}
	}

	public virtual void OnMouseOver()
	{
		if (!barFlag)
		{
			if (clickFlag)
			{
				if (!downFlag)
				{
					float y = credits.creditsTransform.localPosition.y - scrollSpeed * Time.deltaTime;
					Vector3 localPosition = credits.creditsTransform.localPosition;
					float num = (localPosition.y = y);
					Vector3 vector = (credits.creditsTransform.localPosition = localPosition);
				}
				else
				{
					float y2 = credits.creditsTransform.localPosition.y + scrollSpeed * Time.deltaTime;
					Vector3 localPosition2 = credits.creditsTransform.localPosition;
					float num2 = (localPosition2.y = y2);
					Vector3 vector3 = (credits.creditsTransform.localPosition = localPosition2);
				}
			}
		}
		else if (clickFlag && !(Input.mousePosition.y < (float)(Screen.height / 2 - 174)) && !(Input.mousePosition.y > (float)(Screen.height / 2 + 90)))
		{
			int num3 = default(int);
			num3 = (int)Input.mousePosition.y;
			if (num3 >= Screen.height / 2 + 60)
			{
				num3 = Screen.height / 2 + 60;
			}
			if (num3 <= Screen.height / 2 - 144)
			{
				num3 = Screen.height / 2 - 144;
			}
			float y3 = credits.scrollStartPosition + (credits.scrollEndPosition - credits.scrollStartPosition) * (float)(num3 - (Screen.height / 2 + 60)) / -204f;
			Vector3 localPosition3 = credits.creditsTransform.localPosition;
			float num4 = (localPosition3.y = y3);
			Vector3 vector5 = (credits.creditsTransform.localPosition = localPosition3);
		}
	}

	public virtual void OnMouseDown()
	{
		if (!barFlag)
		{
			if (decideSE != null)
			{
				audio.PlayOneShot(decideSE, 0.6f);
			}
			clickFlag = true;
		}
		else
		{
			clickFlag = true;
		}
	}

	public virtual void OnMouseUp()
	{
		if (!barFlag)
		{
			clickFlag = false;
		}
		else
		{
			clickFlag = false;
		}
	}

	public virtual void OnMouseExit()
	{
		if (!barFlag)
		{
			myTexture.texture = falseTex;
			clickFlag = false;
		}
		else
		{
			clickFlag = false;
		}
	}

	public virtual void Main()
	{
	}
}
