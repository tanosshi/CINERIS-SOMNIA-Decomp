using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PositionShake : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ShakeX_00241340 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PositionShake _0024self__00241341;

			public _0024(PositionShake self_)
			{
				_0024self__00241341 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241341.flagX = true;
					iTween.ShakePosition(_0024self__00241341.gameObject, iTween.Hash("x", _0024self__00241341.magnitudeX, "time", _0024self__00241341.timeX));
					result = (Yield(2, new WaitForSeconds(_0024self__00241341.timeX)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241341.flagX = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PositionShake _0024self__00241342;

		public _0024ShakeX_00241340(PositionShake self_)
		{
			_0024self__00241342 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241342);
		}
	}

	[Serializable]
	internal sealed class _0024ShakeY_00241343 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PositionShake _0024self__00241344;

			public _0024(PositionShake self_)
			{
				_0024self__00241344 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241344.flagY = true;
					iTween.ShakePosition(_0024self__00241344.gameObject, iTween.Hash("y", _0024self__00241344.magnitudeY, "time", _0024self__00241344.timeY));
					result = (Yield(2, new WaitForSeconds(_0024self__00241344.timeY)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241344.flagY = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PositionShake _0024self__00241345;

		public _0024ShakeY_00241343(PositionShake self_)
		{
			_0024self__00241345 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241345);
		}
	}

	[Serializable]
	internal sealed class _0024ShakeZ_00241346 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PositionShake _0024self__00241347;

			public _0024(PositionShake self_)
			{
				_0024self__00241347 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241347.flagZ = true;
					iTween.ShakePosition(_0024self__00241347.gameObject, iTween.Hash("z", _0024self__00241347.magnitudeZ, "time", _0024self__00241347.timeZ));
					result = (Yield(2, new WaitForSeconds(_0024self__00241347.timeZ)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241347.flagZ = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PositionShake _0024self__00241348;

		public _0024ShakeZ_00241346(PositionShake self_)
		{
			_0024self__00241348 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241348);
		}
	}

	public bool activeX;

	public float magnitudeX;

	public float timeX;

	public bool activeY;

	public float magnitudeY;

	public float timeY;

	public bool activeZ;

	public float magnitudeZ;

	public float timeZ;

	public bool activeRandomTime;

	public float randomTimeMin;

	public float randomTimeMax;

	private bool flagX;

	private bool flagY;

	private bool flagZ;

	private float randomTime;

	private bool flagRandom;

	public virtual void Update()
	{
		if (activeRandomTime)
		{
			if (!flagRandom)
			{
				flagRandom = true;
				randomTime = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);
			}
			if (randomTime > 0f)
			{
				randomTime -= Time.deltaTime;
				return;
			}
			flagRandom = false;
		}
		if (activeX && !flagX)
		{
			StartCoroutine_Auto(ShakeX());
		}
		if (activeY && !flagY)
		{
			StartCoroutine_Auto(ShakeY());
		}
		if (activeZ && !flagZ)
		{
			StartCoroutine_Auto(ShakeZ());
		}
	}

	public virtual IEnumerator ShakeX()
	{
		return new _0024ShakeX_00241340(this).GetEnumerator();
	}

	public virtual IEnumerator ShakeY()
	{
		return new _0024ShakeY_00241343(this).GetEnumerator();
	}

	public virtual IEnumerator ShakeZ()
	{
		return new _0024ShakeZ_00241346(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
