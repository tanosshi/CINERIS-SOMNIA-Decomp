using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoPlayAudio : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024FirstDelay_0024923 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AutoPlayAudio _0024self__0024924;

			public _0024(AutoPlayAudio self_)
			{
				_0024self__0024924 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__0024924.delayTime)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024924.audio.pitch = UnityEngine.Random.Range(_0024self__0024924.pitchMin, _0024self__0024924.pitchMax);
					_0024self__0024924.volume = UnityEngine.Random.Range(_0024self__0024924.volumeMin, _0024self__0024924.volumeMax);
					_0024self__0024924.random = UnityEngine.Random.Range(0, _0024self__0024924.audioClips.Length);
					_0024self__0024924.audio.PlayOneShot(_0024self__0024924.audioClips[_0024self__0024924.random], _0024self__0024924.volume * _0024self__0024924.multiply);
					_0024self__0024924.endDelay = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoPlayAudio _0024self__0024925;

		public _0024FirstDelay_0024923(AutoPlayAudio self_)
		{
			_0024self__0024925 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024925);
		}
	}

	public float firstDelayTimeMin;

	public float firstDelayTimeMax;

	public float minTime;

	public float maxTime;

	public float volumeMin;

	public float volumeMax;

	public float pitchMin;

	public float pitchMax;

	public AudioClip[] audioClips;

	public bool forGirl;

	public Animator girlAnimator;

	private bool endDelay;

	private float delayTime;

	private float randomTime;

	private float volume;

	private int random;

	private float multiply;

	public AutoPlayAudio()
	{
		multiply = 1f;
	}

	public virtual void Start()
	{
		delayTime = UnityEngine.Random.Range(firstDelayTimeMin, firstDelayTimeMax);
		randomTime = UnityEngine.Random.Range(minTime, maxTime);
		StartCoroutine_Auto(FirstDelay());
	}

	public virtual void Update()
	{
		if (!endDelay)
		{
			return;
		}
		if (!(randomTime > 0f))
		{
			audio.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
			volume = UnityEngine.Random.Range(volumeMin, volumeMax);
			random = UnityEngine.Random.Range(0, audioClips.Length);
			audio.PlayOneShot(audioClips[random], volume * multiply);
			if (forGirl)
			{
				switch (random)
				{
				case 0:
					girlAnimator.CrossFade("19_01", 0.1f, 5);
					break;
				case 1:
					girlAnimator.CrossFade("19_02", 0.1f, 5);
					break;
				case 2:
					girlAnimator.CrossFade("19_03", 0.1f, 5);
					break;
				case 3:
					girlAnimator.CrossFade("19_04", 0.1f, 5);
					break;
				case 4:
					girlAnimator.CrossFade("19_05", 0.1f, 5);
					break;
				case 5:
					girlAnimator.CrossFade("19_06", 0.1f, 5);
					break;
				}
			}
			randomTime = UnityEngine.Random.Range(minTime, maxTime);
		}
		else
		{
			randomTime -= Time.deltaTime;
		}
	}

	public virtual IEnumerator FirstDelay()
	{
		return new _0024FirstDelay_0024923(this).GetEnumerator();
	}

	public virtual void SetMultiply(float mul)
	{
		multiply = mul;
	}

	public virtual void Main()
	{
	}
}
