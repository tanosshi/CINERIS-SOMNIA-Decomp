using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ClockController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ClockAlarm_00241001 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241002;

			internal ClockController _0024self__00241003;

			public _0024(int num, ClockController self_)
			{
				_0024num_00241002 = num;
				_0024self__00241003 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241003.i = 0;
					goto IL_0082;
				case 2:
					_0024self__00241003.i++;
					goto IL_0082;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0082:
					if (_0024self__00241003.i < _0024num_00241002)
					{
						_0024self__00241003.alarmAudioSource[_0024self__00241003.i].audio.PlayOneShot(_0024self__00241003.audioClipShort);
						result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241004;

		internal ClockController _0024self__00241005;

		public _0024ClockAlarm_00241001(int num, ClockController self_)
		{
			_0024num_00241004 = num;
			_0024self__00241005 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241004, _0024self__00241005);
		}
	}

	public AudioClip audioClip;

	public AudioClip audioClipLong;

	public AudioClip audioClipShort;

	public GameObject[] alarmAudioSource;

	public GameObject arrowLong;

	public GameObject arrowShort;

	public int hour;

	public int minute;

	public int seconds;

	private bool nowPlaying;

	private Transform myTransform;

	private bool firstIgnore;

	private SinRotate sinRotate;

	private Player_Status status;

	private int i;

	public virtual void Start()
	{
		myTransform = transform;
		sinRotate = (SinRotate)GetComponent(typeof(SinRotate));
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		hour = (int)status.variables[14];
		minute = (int)status.variables[15];
	}

	public virtual void FixedUpdate()
	{
		if (!sinRotate.enabled && !(status.playTimeSeconds % 1f > 0.2f) && !(status.playTimeSeconds % 1f < -0.2f))
		{
			seconds = (int)status.playTimeSeconds;
			sinRotate.enabled = true;
		}
		float z = Mathf.LerpAngle(arrowLong.transform.localEulerAngles.z, (float)minute * 6f, 0.4f);
		Vector3 localEulerAngles = arrowLong.transform.localEulerAngles;
		float num = (localEulerAngles.z = z);
		Vector3 vector = (arrowLong.transform.localEulerAngles = localEulerAngles);
		float z2 = Mathf.LerpAngle(arrowShort.transform.localEulerAngles.z, (float)hour * 30f + (float)minute * 0.5f, 0.4f);
		Vector3 localEulerAngles2 = arrowShort.transform.localEulerAngles;
		float num2 = (localEulerAngles2.z = z2);
		Vector3 vector3 = (arrowShort.transform.localEulerAngles = localEulerAngles2);
		status.variables[14] = hour;
		status.variables[15] = minute;
		if (myTransform.rotation.eulerAngles.z >= 359.6f || !(myTransform.rotation.eulerAngles.z > 0.4f))
		{
			if (firstIgnore)
			{
				if (nowPlaying)
				{
					return;
				}
				nowPlaying = true;
				audio.PlayOneShot(audioClip);
				seconds++;
				if (seconds < 60)
				{
					return;
				}
				seconds = 0;
				arrowLong.audio.PlayOneShot(audioClipLong);
				minute++;
				if (minute >= 60)
				{
					minute = 0;
					hour++;
					StartCoroutine_Auto(ClockAlarm(hour));
					if (hour >= 12)
					{
						hour = 0;
					}
				}
			}
			else
			{
				firstIgnore = true;
				nowPlaying = true;
			}
		}
		else
		{
			nowPlaying = false;
		}
	}

	public virtual IEnumerator ClockAlarm(int num)
	{
		return new _0024ClockAlarm_00241001(num, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
