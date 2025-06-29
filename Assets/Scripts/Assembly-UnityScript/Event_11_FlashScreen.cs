using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_11_FlashScreen : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Flash_00241090 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241091;

			internal Event_11_FlashScreen _0024self__00241092;

			public _0024(int num, Event_11_FlashScreen self_)
			{
				_0024num_00241091 = num;
				_0024self__00241092 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241092.black.SetFadeColor(_0024self__00241092.state[_0024num_00241091].flashColor);
					_0024self__00241092.black.SetFadeSpeed(0.1f);
					_0024self__00241092.black.FadeIn();
					result = (Yield(2, new WaitForSeconds(0.12f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241092.black.SetFadeSpeed(_0024self__00241092.state[_0024num_00241091].flashTime - 0.12f);
					_0024self__00241092.black.FadeOut();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241093;

		internal Event_11_FlashScreen _0024self__00241094;

		public _0024Flash_00241090(int num, Event_11_FlashScreen self_)
		{
			_0024num_00241093 = num;
			_0024self__00241094 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241093, _0024self__00241094);
		}
	}

	public CtrlFlashScreen[] state;

	private BlackOutController black;

	public virtual void Start()
	{
		black = (BlackOutController)GameObject.Find("SystemObject").GetComponent(typeof(BlackOutController));
	}

	public virtual void FlashScreen(int num)
	{
		StartCoroutine_Auto(Flash(num));
		SendMessage("ExitCommandProcessing");
	}

	public virtual IEnumerator Flash(int num)
	{
		return new _0024Flash_00241090(num, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
