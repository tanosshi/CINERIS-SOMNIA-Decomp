using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class DelayDestroy : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ObjectDestroy_00241006 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal DelayDestroy _0024self__00241007;

			public _0024(DelayDestroy self_)
			{
				_0024self__00241007 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__00241007.destroyTime)) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024self__00241007.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DelayDestroy _0024self__00241008;

		public _0024ObjectDestroy_00241006(DelayDestroy self_)
		{
			_0024self__00241008 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241008);
		}
	}

	public float destroyTime;

	public virtual void Start()
	{
		StartCoroutine_Auto(ObjectDestroy());
	}

	public virtual IEnumerator ObjectDestroy()
	{
		return new _0024ObjectDestroy_00241006(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
