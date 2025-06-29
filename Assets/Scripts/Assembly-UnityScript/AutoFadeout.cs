using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoFadeout : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StartDelay_0024917 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AutoFadeout _0024self__0024918;

			public _0024(AutoFadeout self_)
			{
				_0024self__0024918 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__0024918.delayTime)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024918.startFlag = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoFadeout _0024self__0024919;

		public _0024StartDelay_0024917(AutoFadeout self_)
		{
			_0024self__0024919 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024919);
		}
	}

	public float delayTime;

	public float fadeSpeed;

	private Material myMaterial;

	private bool startFlag;

	private Color firstColor;

	private float alpha;

	public virtual void Start()
	{
		myMaterial = gameObject.renderer.material;
		firstColor = myMaterial.GetColor("_Color");
		alpha = firstColor.a;
		StartCoroutine_Auto(StartDelay());
	}

	public virtual void Update()
	{
		if (startFlag)
		{
			alpha -= fadeSpeed * Time.deltaTime;
			myMaterial.SetColor("_Color", new Color(firstColor.r, firstColor.g, firstColor.b, alpha));
		}
	}

	public virtual IEnumerator StartDelay()
	{
		return new _0024StartDelay_0024917(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
