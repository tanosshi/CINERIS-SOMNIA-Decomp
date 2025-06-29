using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class Event_16_PlayBGMorBGS : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024DelayPlay_00241095 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241096;

			internal Event_16_PlayBGMorBGS _0024self__00241097;

			public _0024(int num, Event_16_PlayBGMorBGS self_)
			{
				_0024num_00241096 = num;
				_0024self__00241097 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241097.interruptFlag = false;
					result = (Yield(2, new WaitForSeconds(_0024self__00241097.state[_0024num_00241096].delayTime)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241097.interruptFlag)
					{
						_0024self__00241097.interruptFlag = false;
					}
					else
					{
						_0024self__00241097.delayCompleteFlag = true;
						_0024self__00241097.PlayBGMorBGS(_0024num_00241096);
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241098;

		internal Event_16_PlayBGMorBGS _0024self__00241099;

		public _0024DelayPlay_00241095(int num, Event_16_PlayBGMorBGS self_)
		{
			_0024num_00241098 = num;
			_0024self__00241099 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241098, _0024self__00241099);
		}
	}

	public CtrlPlayBGM[] state;

	private AudioSource bgm;

	private AudioSource bgs;

	private AudioClip audioFileTemp;

	private bool delayCompleteFlag;

	private bool interruptFlag;

	private AudioManager audioManager;

	public virtual void Start()
	{
		bgm = (AudioSource)GameObject.Find("BGM").GetComponent(typeof(AudioSource));
		bgs = (AudioSource)GameObject.Find("BGS").GetComponent(typeof(AudioSource));
		audioManager = (AudioManager)GameObject.Find("SystemObject").GetComponent(typeof(AudioManager));
	}

	public virtual void PlayBGMorBGS(int num)
	{
		if (state[num].delay && !delayCompleteFlag)
		{
			StartCoroutine_Auto(DelayPlay(num));
			SendMessage("ExitCommandProcessing");
			return;
		}
		delayCompleteFlag = false;
		interruptFlag = true;
		if (state[num].type == BGMorBGS.BGM)
		{
			audioFileTemp = bgm.clip;
			if (state[num].audioFile != null)
			{
				bgm.loop = state[num].loop;
				if (state[num].fadeTime == 0f)
				{
					bgm.volume = state[num].volume;
				}
				else
				{
					DOTween.Kill(bgm);
					bgm.DOFade(state[num].volume, state[num].fadeTime).SetUpdate(true);
				}
				bgm.pitch = state[num].pitch;
				bgm.clip = state[num].audioFile;
				if (!(bgm.clip == audioFileTemp) || !bgm.audio.isPlaying)
				{
					if (!(state[num].fadeTime <= 0f))
					{
						bgm.volume = 0f;
					}
					bgm.audio.Play();
					bgm.audio.time = state[num].startSeconds;
				}
			}
			else
			{
				bgm.clip = null;
				bgm.audio.Stop();
			}
		}
		else
		{
			audioFileTemp = bgs.clip;
			if (state[num].audioFile != null)
			{
				bgs.loop = state[num].loop;
				if (state[num].fadeTime == 0f)
				{
					bgs.volume = state[num].volume;
				}
				else
				{
					DOTween.Kill(bgs);
					bgs.DOFade(state[num].volume, state[num].fadeTime).SetUpdate(true);
				}
				bgs.pitch = state[num].pitch;
				bgs.clip = state[num].audioFile;
				if (!(bgs.clip == audioFileTemp) || !bgs.audio.isPlaying)
				{
					if (!(state[num].fadeTime <= 0f))
					{
						bgs.volume = 0f;
					}
					bgs.audio.Play();
					bgs.audio.time = state[num].startSeconds;
				}
			}
			else
			{
				bgs.clip = null;
				bgs.audio.Stop();
			}
		}
		if (state[num].fixAmbientSound)
		{
			audioManager.FixAmbientSound(state[num].ambientSoundFadeTime, state[num].ambientSoundMultiply);
		}
		if (!state[num].delay)
		{
			SendMessage("ExitCommandProcessing");
		}
	}

	public virtual IEnumerator DelayPlay(int num)
	{
		return new _0024DelayPlay_00241095(num, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
