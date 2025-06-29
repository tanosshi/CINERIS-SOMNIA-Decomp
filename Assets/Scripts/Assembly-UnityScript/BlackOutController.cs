using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BlackOutController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024FirstFadeOut_0024933 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BlackOutController _0024self__0024934;

			public _0024(BlackOutController self_)
			{
				_0024self__0024934 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024934.curFade = 1f;
					if (!_0024self__0024934.notWait_Debug)
					{
						result = (Yield(2, new WaitForSeconds(_0024self__0024934.firstFadeWaitTime)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__0024934.nowFadeIn = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal BlackOutController _0024self__0024935;

		public _0024FirstFadeOut_0024933(BlackOutController self_)
		{
			_0024self__0024935 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024935);
		}
	}

	public Texture2D BlackTex;

	public float FadeSpeed;

	public float firstFadeWaitTime;

	public bool notWait_Debug;

	[NonSerialized]
	public static int guiDepth = -10;

	private float curFade;

	private bool nowFadeIn;

	private float fadeColorR;

	private float fadeColorG;

	private float fadeColorB;

	private Player_Status status;

	public BlackOutController()
	{
		FadeSpeed = 1f;
		firstFadeWaitTime = 2f;
		nowFadeIn = true;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		SetFadeColor(status.fadeColor);
	}

	public virtual void Update()
	{
		if (nowFadeIn)
		{
			curFade += Time.deltaTime / FadeSpeed;
			if (!(curFade < 1f))
			{
				curFade = 1f;
			}
		}
		else
		{
			curFade -= Time.deltaTime / FadeSpeed;
			if (!(curFade > 0f))
			{
				curFade = 0f;
			}
		}
	}

	public virtual void FadeIn()
	{
		nowFadeIn = true;
		curFade = 0f;
	}

	public virtual void FadeOut()
	{
		nowFadeIn = false;
		curFade = 1f;
	}

	public virtual void SetFadeSpeed(float speed)
	{
		FadeSpeed = speed;
	}

	public virtual void SetFadeColor(Color color)
	{
		fadeColorR = color.r;
		fadeColorG = color.g;
		fadeColorB = color.b;
	}

	public virtual void OnGUI()
	{
		if (!(curFade <= 0f))
		{
			GUI.depth = guiDepth;
			GUI.color = new Color(fadeColorR, fadeColorG, fadeColorB, curFade);
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), BlackTex);
		}
	}

	public virtual IEnumerator FirstFadeOut()
	{
		return new _0024FirstFadeOut_0024933(this).GetEnumerator();
	}

	public virtual void ChangeCurFade(float num)
	{
		curFade = num;
	}

	public virtual void ChangeFadeFlag(bool flag)
	{
		nowFadeIn = flag;
	}

	public virtual void Main()
	{
	}
}
