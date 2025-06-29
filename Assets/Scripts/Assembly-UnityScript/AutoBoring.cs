using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoBoring : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024SetBoring_0024914 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AutoBoring _0024self__0024915;

			public _0024(AutoBoring self_)
			{
				_0024self__0024915 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024915.animator.SetBool("Boring", true);
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024915.animator.SetBool("Boring", false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoBoring _0024self__0024916;

		public _0024SetBoring_0024914(AutoBoring self_)
		{
			_0024self__0024916 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024916);
		}
	}

	public float minTime;

	public float maxTime;

	private Animator animator;

	private float randomTime;

	public virtual void Awake()
	{
		animator = (Animator)GetComponent(typeof(Animator));
		SetRandomTime();
	}

	public virtual void Update()
	{
		if (!(randomTime > 0f))
		{
			SetRandomTime();
			StartCoroutine_Auto(SetBoring());
		}
		else
		{
			randomTime -= 1f * Time.deltaTime;
		}
	}

	public virtual void SetRandomTime()
	{
		randomTime = UnityEngine.Random.Range(minTime, maxTime);
	}

	public virtual IEnumerator SetBoring()
	{
		return new _0024SetBoring_0024914(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
