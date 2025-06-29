using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Girl3Controller : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Find_00241124 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl3Controller _0024self__00241125;

			public _0024(Girl3Controller self_)
			{
				_0024self__00241125 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241125.nowFinding)
					{
						_0024self__00241125.nowFinding = true;
						_0024self__00241125.navagent.Stop();
						_0024self__00241125.animator.SetBool("Find", true);
						_0024self__00241125.animator.SetBool("Walk", false);
						_0024self__00241125.random = (int)UnityEngine.Random.Range(4f, 12f);
						result = (Yield(2, new WaitForSeconds(_0024self__00241125.random)) ? 1 : 0);
						break;
					}
					goto IL_00ef;
				case 2:
					_0024self__00241125.findCount = UnityEngine.Random.Range(_0024self__00241125.findCountMin, _0024self__00241125.findCountMax);
					_0024self__00241125.animator.SetBool("Find", false);
					_0024self__00241125.nowFinding = false;
					goto IL_00ef;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ef:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Girl3Controller _0024self__00241126;

		public _0024Find_00241124(Girl3Controller self_)
		{
			_0024self__00241126 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241126);
		}
	}

	public float walkSpeed;

	public float rotateSpeed;

	public Transform target;

	public Transform[] movePoint;

	public TransformArray[] lookPoint;

	public float movingCountMin;

	public float movingCountMax;

	public float findCountMin;

	public float findCountMax;

	public float lookCountMin;

	public float lookCountMax;

	public float lookAtFadeSpeed;

	private Animator animator;

	private NavMeshAgent navagent;

	private Transform myTransform;

	private Transform playerTransform;

	private Transform nowMovingPoint;

	private int nowMovingId;

	private int random;

	private float movingCount;

	private bool nowFinding;

	private float findCount;

	private float lookCount;

	private Vector3 moveDirection;

	public Girl3Controller()
	{
		lookAtFadeSpeed = 2f;
		moveDirection = Vector3.zero;
	}

	public virtual void Awake()
	{
		animator = (Animator)GetComponent(typeof(Animator));
		navagent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
		myTransform = transform;
	}

	public virtual void Start()
	{
		navagent.speed = walkSpeed;
		navagent.angularSpeed = rotateSpeed;
		playerTransform = GameObject.FindWithTag("Player").transform;
	}

	public virtual void FixedUpdate()
	{
		if (!(navagent != null))
		{
			return;
		}
		if (!(findCount <= 0f))
		{
			findCount -= 1f * Time.deltaTime;
			if (!(movingCount > 0f))
			{
				random = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)movePoint));
				nowMovingPoint = movePoint[random];
				nowMovingId = random;
				navagent.SetDestination(nowMovingPoint.position);
				animator.SetBool("Walk", true);
				movingCount = UnityEngine.Random.Range(movingCountMin, movingCountMax);
			}
			else
			{
				movingCount -= 1f * Time.deltaTime;
				moveDirection = myTransform.TransformDirection(Vector3.forward);
				if (Vector3.Distance(myTransform.position, nowMovingPoint.position) <= 1.2f || !(Vector3.Distance(myTransform.position, playerTransform.position) > 0.8f))
				{
					navagent.Stop();
					animator.SetBool("Walk", false);
				}
			}
			if (!(lookCount > 0f))
			{
				if (lookPoint.Length != 0 && lookPoint[nowMovingId].point.Length != 0)
				{
					random = UnityEngine.Random.Range(0, lookPoint[nowMovingId].point.Length);
				}
				if (lookPoint[nowMovingId].point[random] != null)
				{
					SendMessage("SetLookAtFadeSpeed", lookAtFadeSpeed, SendMessageOptions.DontRequireReceiver);
					SendMessage("SetLookAtTarget", lookPoint[nowMovingId].point[random].gameObject, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					SendMessage("DeleteLookAtTarget", SendMessageOptions.DontRequireReceiver);
				}
				lookCount = UnityEngine.Random.Range(lookCountMin, lookCountMax);
			}
			else
			{
				lookCount -= 1f * Time.deltaTime;
			}
		}
		else
		{
			SendMessage("DeleteLookAtTarget", SendMessageOptions.DontRequireReceiver);
			StartCoroutine_Auto(Find());
		}
	}

	public virtual IEnumerator Find()
	{
		return new _0024Find_00241124(this).GetEnumerator();
	}

	public virtual void InitFindFlag()
	{
		nowFinding = false;
		findCount = 1f;
	}

	public virtual void AnimationManager(int id)
	{
		if (id == 0)
		{
			animator.SetBool("Find", false);
			animator.SetBool("Walk", false);
		}
	}

	public virtual void Main()
	{
	}
}
