using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class RoomCamera : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ChangeSmooth_00241353 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal RoomCamera _0024self__00241354;

			public _0024(RoomCamera self_)
			{
				_0024self__00241354 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241354.smoothed = false;
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241354.smoothed = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RoomCamera _0024self__00241355;

		public _0024ChangeSmooth_00241353(RoomCamera self_)
		{
			_0024self__00241355 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241355);
		}
	}

	public AnimationTargetType targetType;

	public Transform target;

	public string tagName;

	public float height;

	public float camSpeed;

	public bool smoothed;

	public float ignoreDistance;

	private Vector3 targetTransform;

	private Transform myTransform;

	public RoomCamera()
	{
		camSpeed = 2f;
		smoothed = true;
	}

	public virtual void Awake()
	{
		myTransform = transform;
	}

	public virtual void Start()
	{
		if (targetType == AnimationTargetType.Tag)
		{
			target = GameObject.FindWithTag(tagName).transform;
		}
		if (smoothed)
		{
			StartCoroutine_Auto(ChangeSmooth());
		}
	}

	public virtual void LateUpdate()
	{
		if ((bool)target && Vector3.Distance(target.position, myTransform.position) <= ignoreDistance)
		{
			targetTransform = target.position;
			targetTransform.y = target.position.y + height;
			LookAtMe();
		}
	}

	public virtual void LookAtMe()
	{
		if (smoothed)
		{
			Quaternion to = Quaternion.LookRotation(targetTransform - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * camSpeed);
		}
		else
		{
			transform.LookAt(targetTransform);
		}
	}

	public virtual IEnumerator ChangeSmooth()
	{
		return new _0024ChangeSmooth_00241353(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
