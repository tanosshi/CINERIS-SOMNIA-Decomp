using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SkinnedClothController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ChangeMeshRenderer_00241382 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024fl_00241383;

			internal SkinnedClothController _0024self__00241384;

			public _0024(bool fl, SkinnedClothController self_)
			{
				_0024fl_00241383 = fl;
				_0024self__00241384 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.04f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241384.render.enabled = _0024fl_00241383;
					_0024self__00241384.target.SetActive(!_0024fl_00241383);
					result = (Yield(3, new WaitForSeconds(0.04f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241384.target.SetActive(_0024fl_00241383);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024fl_00241385;

		internal SkinnedClothController _0024self__00241386;

		public _0024ChangeMeshRenderer_00241382(bool fl, SkinnedClothController self_)
		{
			_0024fl_00241385 = fl;
			_0024self__00241386 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024fl_00241385, _0024self__00241386);
		}
	}

	public GameObject target;

	private SkinnedMeshRenderer render;

	private bool flag;

	public virtual void Start()
	{
		flag = true;
		render = (SkinnedMeshRenderer)target.GetComponent(typeof(SkinnedMeshRenderer));
	}

	public virtual void Update()
	{
		if (Time.timeScale == 0f)
		{
			flag = false;
			target.SetActive(flag);
			StartCoroutine_Auto(ChangeMeshRenderer(flag));
		}
		else if (!flag)
		{
			flag = true;
			target.SetActive(flag);
			StartCoroutine_Auto(ChangeMeshRenderer(flag));
		}
	}

	public virtual IEnumerator ChangeMeshRenderer(bool fl)
	{
		return new _0024ChangeMeshRenderer_00241382(fl, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
