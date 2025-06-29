using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class FirePlaceController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Burst_00241118 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal FirePlaceController _0024self__00241119;

			public _0024(FirePlaceController self_)
			{
				_0024self__00241119 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241119.nowBurst = true;
					_0024self__00241119.burstObject.SetActive(true);
					_0024self__00241119.random = UnityEngine.Random.Range(0, _0024self__00241119.burstSE.Length);
					_0024self__00241119.audio.PlayOneShot(_0024self__00241119.burstSE[_0024self__00241119.random]);
					result = (Yield(2, new WaitForSeconds(0.6f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241119.burstObject.SetActive(false);
					_0024self__00241119.nowBurst = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FirePlaceController _0024self__00241120;

		public _0024Burst_00241118(FirePlaceController self_)
		{
			_0024self__00241120 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241120);
		}
	}

	public GameObject burstObject;

	public AudioClip[] burstSE;

	private bool nowBurst;

	private float burstTime;

	private int random;

	public virtual void Start()
	{
		burstTime = UnityEngine.Random.Range(2f, 16f);
	}

	public virtual void Update()
	{
		burstTime -= Time.deltaTime;
		if (!(burstTime > 0f) && !nowBurst)
		{
			StartCoroutine_Auto(Burst());
			burstTime = UnityEngine.Random.Range(2f, 16f);
		}
	}

	public virtual IEnumerator Burst()
	{
		return new _0024Burst_00241118(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
