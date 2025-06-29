using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Girl2BrotherController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Page_00241121 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl2BrotherController _0024self__00241122;

			public _0024(Girl2BrotherController self_)
			{
				_0024self__00241122 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241122.pageAnimator.Play("Page", 0);
					result = (Yield(2, new WaitForSeconds(0.8f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241122.pageAnimator.Play("Empty", 0);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Girl2BrotherController _0024self__00241123;

		public _0024Page_00241121(Girl2BrotherController self_)
		{
			_0024self__00241123 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241123);
		}
	}

	public Transform lookAtPoint;

	public float lookAtWeight;

	public float lookAtBodyWeight;

	public float lookAtHeadWeight;

	public float lookAtEyeWeight;

	public float lookAtClampWeight;

	public GameObject pageObject;

	public Animator pageAnimator;

	private bool pageFlag;

	private float pageCount;

	private Animator animator;

	public virtual void Awake()
	{
		animator = (Animator)GetComponent(typeof(Animator));
		pageCount = 1f;
	}

	public virtual void Update()
	{
		if (!pageFlag)
		{
			pageCount = UnityEngine.Random.Range(8f, 16f);
			pageFlag = true;
		}
		pageCount -= 1f * Time.deltaTime;
		animator.SetFloat("pageCount", pageCount);
		if (!(pageCount > 0f))
		{
			pageFlag = false;
		}
		animator.SetLookAtPosition(lookAtPoint.position);
		animator.SetLookAtWeight(lookAtWeight, lookAtBodyWeight, lookAtHeadWeight, lookAtEyeWeight, lookAtClampWeight);
	}

	public virtual IEnumerator Page()
	{
		return new _0024Page_00241121(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
