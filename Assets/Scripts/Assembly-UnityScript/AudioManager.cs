using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class AudioManager : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024DelayFadeIn_0024907 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AudioSource _0024source_0024908;

			internal float _0024volume_0024909;

			internal float _0024time_0024910;

			public _0024(AudioSource source, float volume, float time)
			{
				_0024source_0024908 = source;
				_0024volume_0024909 = volume;
				_0024time_0024910 = time;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024source_0024908.Stop();
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					DOTween.Kill(_0024source_0024908, true);
					_0024source_0024908.Play();
					_0024source_0024908.DOFade(_0024volume_0024909, _0024time_0024910).SetUpdate(true);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AudioSource _0024source_0024911;

		internal float _0024volume_0024912;

		internal float _0024time_0024913;

		public _0024DelayFadeIn_0024907(AudioSource source, float volume, float time)
		{
			_0024source_0024911 = source;
			_0024volume_0024912 = volume;
			_0024time_0024913 = time;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024source_0024911, _0024volume_0024912, _0024time_0024913);
		}
	}

	public System.Collections.Generic.List<AudioContainer> normalSoundList;

	public System.Collections.Generic.List<AudioContainer> ambientSoundList;

	private Player_Status Status;

	private BlackOutController waitTime;

	private int i;

	private int j;

	public virtual void Start()
	{
		Status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		waitTime = (BlackOutController)GetComponent(typeof(BlackOutController));
		ambientSoundList = new System.Collections.Generic.List<AudioContainer>();
		GameObject gameObject = null;
		gameObject = GameObject.Find("SYSTEM_AUDIOZONE");
		if (gameObject != null)
		{
			AudioSource[] array = null;
			array = gameObject.GetComponentsInChildren<AudioSource>(true);
			for (i = 0; i < array.Length; i++)
			{
				AudioContainer audioContainer = new AudioContainer();
				audioContainer.source = array[i];
				audioContainer.defaultVolume = array[i].volume;
				audioContainer.autoPlayAudio = (AutoPlayAudio)array[i].GetComponent(typeof(AutoPlayAudio));
				ambientSoundList.Add(audioContainer);
			}
		}
		GameObject gameObject2 = null;
		gameObject2 = GameObject.FindWithTag("Player");
		if (gameObject2 != null)
		{
			AudioSource[] array2 = null;
			array2 = gameObject2.GetComponentsInChildren<AudioSource>(true);
			for (i = 0; i < array2.Length; i++)
			{
				AudioContainer audioContainer2 = new AudioContainer();
				audioContainer2.source = array2[i];
				audioContainer2.defaultVolume = array2[i].volume;
				normalSoundList.Add(audioContainer2);
			}
		}
		GameObject gameObject3 = null;
		gameObject3 = GameObject.FindWithTag("NPC");
		if (gameObject3 != null)
		{
			AudioSource[] array3 = null;
			array3 = gameObject3.GetComponentsInChildren<AudioSource>(true);
			for (i = 0; i < array3.Length; i++)
			{
				AudioContainer audioContainer3 = new AudioContainer();
				audioContainer3.source = array3[i];
				audioContainer3.defaultVolume = array3[i].volume;
				normalSoundList.Add(audioContainer3);
			}
		}
		GameObject[] array4 = null;
		array4 = GameObject.FindGameObjectsWithTag("Event");
		for (i = 0; i < array4.Length; i++)
		{
			AudioSource[] array5 = null;
			array5 = array4[i].GetComponentsInChildren<AudioSource>(true);
			for (j = 0; j < array5.Length; j++)
			{
				AudioContainer audioContainer4 = new AudioContainer();
				audioContainer4.source = array5[j];
				audioContainer4.defaultVolume = array5[j].volume;
				normalSoundList.Add(audioContainer4);
			}
		}
		for (i = 0; i < ambientSoundList.Count; i++)
		{
			if (ambientSoundList[i].source.loop)
			{
				ambientSoundList[i].source.playOnAwake = true;
				ambientSoundList[i].source.Play();
			}
		}
		if (!Status.audioFadeFlag && !(Application.loadedLevelName == "[00-]saveload") && Status.saveLoadFlag != 2 && Status.saveLoadFlag != 3)
		{
			return;
		}
		for (i = 0; i < ambientSoundList.Count; i++)
		{
			ambientSoundList[i].source.volume = 0f;
			if (ambientSoundList[i].source.loop)
			{
				StartCoroutine_Auto(DelayFadeIn(ambientSoundList[i].source, ambientSoundList[i].defaultVolume, (waitTime.firstFadeWaitTime + waitTime.FadeSpeed) / 2f));
			}
			else
			{
				DOTween.Kill(ambientSoundList[i].source, true);
				ambientSoundList[i].source.DOFade(ambientSoundList[i].defaultVolume, (waitTime.firstFadeWaitTime + waitTime.FadeSpeed) / 2f).SetUpdate(true);
			}
		}
		for (i = 0; i < normalSoundList.Count; i++)
		{
			normalSoundList[i].source.volume = 0f;
			if (normalSoundList[i].source.loop && normalSoundList[i].source.playOnAwake)
			{
				StartCoroutine_Auto(DelayFadeIn(normalSoundList[i].source, normalSoundList[i].defaultVolume, (waitTime.firstFadeWaitTime + waitTime.FadeSpeed) / 2f));
			}
			else
			{
				DOTween.Kill(normalSoundList[i].source, true);
				normalSoundList[i].source.DOFade(normalSoundList[i].defaultVolume, (waitTime.firstFadeWaitTime + waitTime.FadeSpeed) / 2f).SetUpdate(true);
			}
		}
	}

	public virtual IEnumerator DelayFadeIn(AudioSource source, float volume, float time)
	{
		return new _0024DelayFadeIn_0024907(source, volume, time).GetEnumerator();
	}

	public virtual void AudioFadeOut(float time)
	{
		for (i = 0; i < ambientSoundList.Count; i++)
		{
			DOTween.Kill(ambientSoundList[i].source, true);
			ambientSoundList[i].source.DOFade(0f, time).SetUpdate(true);
		}
		for (i = 0; i < normalSoundList.Count; i++)
		{
			DOTween.Kill(normalSoundList[i].source, true);
			normalSoundList[i].source.DOFade(0f, time).SetUpdate(true);
		}
	}

	public virtual void FixAmbientSound(float time, float mul)
	{
		for (i = 0; i < ambientSoundList.Count; i++)
		{
			DOTween.Kill(ambientSoundList[i].source, true);
			ambientSoundList[i].source.DOFade(ambientSoundList[i].defaultVolume * mul, time).SetUpdate(true);
			if (ambientSoundList[i].autoPlayAudio != null)
			{
				ambientSoundList[i].autoPlayAudio.SetMultiply(mul);
			}
		}
	}

	public virtual void Main()
	{
	}
}
