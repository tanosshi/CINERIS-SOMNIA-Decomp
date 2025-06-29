using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoPlayAudioDelay : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024DelayStartAudio_0024926 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AutoPlayAudioDelay _0024self__0024927;

			public _0024(AutoPlayAudioDelay self_)
			{
				_0024self__0024927 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__0024927.delayTime)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024927.audio.Play();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoPlayAudioDelay _0024self__0024928;

		public _0024DelayStartAudio_0024926(AutoPlayAudioDelay self_)
		{
			_0024self__0024928 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024928);
		}
	}

	public float delayTime;

	public virtual void Start()
	{
		StartCoroutine_Auto(DelayStartAudio());
	}

	public virtual IEnumerator DelayStartAudio()
	{
		return new _0024DelayStartAudio_0024926(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
