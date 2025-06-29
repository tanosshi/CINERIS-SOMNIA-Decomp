using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MecanimAnimationManager : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024AnimationManager_00241233 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024num_00241234;

			internal MecanimAnimationManager _0024self__00241235;

			public _0024(int num, MecanimAnimationManager self_)
			{
				_0024num_00241234 = num;
				_0024self__00241235 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241235.startFlag = true;
					_0024self__00241235.startCount = 0;
					_0024self__00241235.animator.SetBool("Boring", false);
					_0024self__00241235.animator.SetBool("Walk", false);
					_0024self__00241235.animator.SetBool("Run", false);
					_0024self__00241235.animator.SetBool("ForceAnimation", true);
					_0024self__00241235.animator.SetInteger("AnimationId", _0024num_00241234);
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241235.animator.SetBool("ForceAnimation", false);
					if (_0024self__00241235.animationFadeTime != 0f)
					{
						goto case 3;
					}
					_0024self__00241235.animator.SetLayerWeight(1, 1f);
					_0024self__00241235.startFlag = false;
					goto IL_0205;
				case 3:
					_0024self__00241235.layerWeight = Mathf.Lerp(_0024self__00241235.layerWeight, 1f, Time.deltaTime * 5f / _0024self__00241235.animationFadeTime);
					_0024self__00241235.animator.SetLayerWeight(1, _0024self__00241235.layerWeight);
					if (!(_0024self__00241235.layerWeight <= 0.99f))
					{
						_0024self__00241235.animator.SetLayerWeight(1, 1f);
						_0024self__00241235.startFlag = false;
					}
					else
					{
						if (!_0024self__00241235.stopFlag || _0024self__00241235.stopCount >= _0024self__00241235.startCount)
						{
							_0024self__00241235.startCount++;
							result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
							break;
						}
						_0024self__00241235.startFlag = false;
					}
					goto IL_0205;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0205:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241236;

		internal MecanimAnimationManager _0024self__00241237;

		public _0024AnimationManager_00241233(int num, MecanimAnimationManager self_)
		{
			_0024num_00241236 = num;
			_0024self__00241237 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241236, _0024self__00241237);
		}
	}

	[Serializable]
	internal sealed class _0024StopAnimation_00241238 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal MecanimAnimationManager _0024self__00241239;

			public _0024(MecanimAnimationManager self_)
			{
				_0024self__00241239 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241239.stopFlag = true;
					_0024self__00241239.stopCount = 0;
					_0024self__00241239.animator.SetBool("ForceAnimation", true);
					_0024self__00241239.animator.SetInteger("AnimationId", 0);
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241239.animator.SetBool("ForceAnimation", false);
					if (_0024self__00241239.animationFadeTime != 0f)
					{
						goto case 3;
					}
					_0024self__00241239.animator.SetLayerWeight(1, 0f);
					_0024self__00241239.stopFlag = false;
					_0024self__00241239.animator.Play("Idle", 1);
					goto IL_01e1;
				case 3:
					_0024self__00241239.layerWeight = Mathf.Lerp(_0024self__00241239.layerWeight, 0f, Time.deltaTime * 5f / _0024self__00241239.animationFadeTime);
					_0024self__00241239.animator.SetLayerWeight(1, _0024self__00241239.layerWeight);
					if (!(_0024self__00241239.layerWeight >= 0.01f))
					{
						_0024self__00241239.animator.SetLayerWeight(1, 0f);
						_0024self__00241239.stopFlag = false;
						_0024self__00241239.animator.Play("Idle", 1);
					}
					else
					{
						if (!_0024self__00241239.startFlag || _0024self__00241239.startCount >= _0024self__00241239.stopCount)
						{
							_0024self__00241239.stopCount++;
							result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
							break;
						}
						_0024self__00241239.stopFlag = false;
					}
					goto IL_01e1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e1:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MecanimAnimationManager _0024self__00241240;

		public _0024StopAnimation_00241238(MecanimAnimationManager self_)
		{
			_0024self__00241240 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241240);
		}
	}

	public GameObject defaultLookAtTarget;

	public GameObject lookAtTarget;

	public AudioSource footStepAudioSource;

	public AudioClip[] footStepSE;

	public int footStepId;

	public GameObject[] footEffect;

	public int footEffectId;

	public Transform leftFoot;

	public Transform rightFoot;

	private Animator animator;

	private AnimatorStateInfo currentState;

	private float layerWeight;

	private float animationFadeTime;

	private bool startFlag;

	private bool stopFlag;

	private int startCount;

	private int stopCount;

	private Vector3 defaultLookAtPoint;

	private Vector3 lookAtPoint;

	public float lookAtWeight;

	public float lookAtBodyWeight;

	public float lookAtHeadWeight;

	public float lookAtEyeWeight;

	public float lookAtClampWeight;

	public float lookAtFadeSpeed;

	private float lookAtBodyWeightTemp;

	private float lookAtHeadWeightTemp;

	private float lookAtEyeWeightTemp;

	private float lookAtClampWeightTemp;

	private float ignoreAngle;

	private Transform myTransform;

	private float blinkTime;

	private Player_Status status;

	public MecanimAnimationManager()
	{
		animationFadeTime = 1f;
		lookAtPoint = Vector3.zero;
		lookAtBodyWeight = 0.1f;
		lookAtHeadWeight = 1f;
		lookAtEyeWeight = 1f;
		lookAtClampWeight = 1f;
		lookAtFadeSpeed = 2f;
	}

	public virtual void Awake()
	{
		myTransform = transform;
		animator = (Animator)GetComponent(typeof(Animator));
		animator.SetLayerWeight(1, 0f);
		lookAtBodyWeightTemp = lookAtBodyWeight;
		lookAtHeadWeightTemp = lookAtHeadWeight;
		lookAtEyeWeightTemp = lookAtEyeWeight;
		lookAtClampWeightTemp = lookAtClampWeight;
		blinkTime = UnityEngine.Random.Range(2f, 8f);
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		blinkTime -= Time.deltaTime;
		if (!(blinkTime > 0f))
		{
			AutoBlink();
			blinkTime = UnityEngine.Random.Range(2f, 8f);
		}
		LookAtTarget();
	}

	public virtual void LookAtTarget()
	{
		if (defaultLookAtTarget != null)
		{
			defaultLookAtPoint = defaultLookAtTarget.transform.position;
		}
		else
		{
			defaultLookAtPoint = lookAtPoint;
		}
		if (lookAtBodyWeightTemp != lookAtBodyWeight)
		{
			lookAtBodyWeightTemp = Mathf.Lerp(lookAtBodyWeightTemp, lookAtBodyWeight, Time.deltaTime * lookAtFadeSpeed);
			if (!(Mathf.Abs(lookAtBodyWeight - lookAtBodyWeightTemp) > 0.0001f))
			{
				lookAtBodyWeightTemp = lookAtBodyWeight;
			}
		}
		if (lookAtHeadWeightTemp != lookAtHeadWeight)
		{
			lookAtHeadWeightTemp = Mathf.Lerp(lookAtHeadWeightTemp, lookAtHeadWeight, Time.deltaTime * lookAtFadeSpeed);
			if (!(Mathf.Abs(lookAtHeadWeight - lookAtHeadWeightTemp) > 0.0001f))
			{
				lookAtHeadWeightTemp = lookAtHeadWeight;
			}
		}
		if (lookAtEyeWeightTemp != lookAtEyeWeight)
		{
			lookAtEyeWeightTemp = Mathf.Lerp(lookAtEyeWeightTemp, lookAtEyeWeight, Time.deltaTime * lookAtFadeSpeed);
			if (!(Mathf.Abs(lookAtEyeWeight - lookAtEyeWeightTemp) > 0.0001f))
			{
				lookAtEyeWeightTemp = lookAtEyeWeight;
			}
		}
		if (lookAtClampWeightTemp != lookAtClampWeight)
		{
			lookAtClampWeightTemp = Mathf.Lerp(lookAtClampWeightTemp, lookAtClampWeight, Time.deltaTime * lookAtFadeSpeed);
			if (!(Mathf.Abs(lookAtClampWeight - lookAtClampWeightTemp) > 0.0001f))
			{
				lookAtClampWeightTemp = lookAtClampWeight;
			}
		}
		if (lookAtTarget != null && (ignoreAngle == 0f || !(Vector2.Angle(new Vector2(defaultLookAtTarget.transform.position.x - myTransform.position.x, defaultLookAtTarget.transform.position.z - myTransform.position.z), new Vector2(lookAtTarget.transform.position.x - myTransform.position.x, lookAtTarget.transform.position.z - myTransform.position.z)) >= ignoreAngle)))
		{
			lookAtPoint = Vector3.Lerp(lookAtPoint, lookAtTarget.transform.position, Time.deltaTime * lookAtFadeSpeed);
			animator.SetLookAtPosition(lookAtPoint);
			if (!(lookAtWeight < 0.9999f))
			{
				lookAtWeight = 1f;
			}
			else
			{
				lookAtWeight = Mathf.Lerp(lookAtWeight, 1f, Time.deltaTime * lookAtFadeSpeed);
			}
			animator.SetLookAtWeight(lookAtWeight, lookAtBodyWeightTemp, lookAtHeadWeightTemp, lookAtEyeWeightTemp, lookAtClampWeightTemp);
		}
		else
		{
			lookAtPoint = Vector3.Lerp(lookAtPoint, defaultLookAtPoint, Time.deltaTime * lookAtFadeSpeed);
			if (!(lookAtWeight > 0.0001f))
			{
				lookAtWeight = 0f;
			}
			else
			{
				lookAtWeight = Mathf.Lerp(lookAtWeight, 0f, Time.deltaTime * lookAtFadeSpeed);
			}
			animator.SetLookAtPosition(lookAtPoint);
			animator.SetLookAtWeight(lookAtWeight, lookAtBodyWeightTemp, lookAtHeadWeightTemp, lookAtEyeWeightTemp, lookAtClampWeightTemp);
		}
	}

	public virtual void SetLookAtTarget(GameObject target)
	{
		lookAtTarget = target;
	}

	public virtual void DeleteLookAtTarget()
	{
		lookAtTarget = null;
	}

	public virtual void SetLookAtBodyWeight(float weight)
	{
		lookAtBodyWeight = weight;
	}

	public virtual void SetLookAtHeadWeight(float weight)
	{
		lookAtHeadWeight = weight;
	}

	public virtual void SetLookAtEyeWeight(float weight)
	{
		lookAtEyeWeight = weight;
	}

	public virtual void SetLookAtClampWeight(float weight)
	{
		lookAtClampWeight = weight;
	}

	public virtual void SetIgnoreAngle(float angle)
	{
		ignoreAngle = angle;
	}

	public virtual void SetLookAtFadeSpeed(float speed)
	{
		lookAtFadeSpeed = speed;
	}

	public virtual void Footsteps()
	{
		if (!status.nowPausing && footStepSE[footStepId] != null)
		{
			footStepAudioSource.PlayOneShot(footStepSE[footStepId]);
		}
	}

	public virtual void ChangeFootstepId(int num)
	{
		footStepId = num;
	}

	public virtual int ShowFootstepId()
	{
		return footStepId;
	}

	public virtual void FootEffectLeft()
	{
		if (footEffect[footEffectId] != null)
		{
			UnityEngine.Object.Instantiate(footEffect[footEffectId], new Vector3(leftFoot.position.x, myTransform.position.y + 0.06f, leftFoot.position.z), Quaternion.Euler(-90f, myTransform.rotation.eulerAngles.y, 0f));
		}
	}

	public virtual void FootEffectRight()
	{
		if (footEffect[footEffectId] != null)
		{
			UnityEngine.Object.Instantiate(footEffect[footEffectId], new Vector3(rightFoot.position.x, myTransform.position.y + 0.06f, rightFoot.position.z), Quaternion.Euler(-90f, myTransform.rotation.eulerAngles.y, 0f));
		}
	}

	public virtual void ChangeFootEffectId(int num)
	{
		footEffectId = num;
	}

	public virtual int ShowFootEffectId()
	{
		return footEffectId;
	}

	public virtual IEnumerator AnimationManager(int num)
	{
		return new _0024AnimationManager_00241233(num, this).GetEnumerator();
	}

	public virtual IEnumerator StopAnimation()
	{
		return new _0024StopAnimation_00241238(this).GetEnumerator();
	}

	public virtual void SetAnimationFadeTime(float time)
	{
		animationFadeTime = time;
	}

	public virtual void AutoBlink()
	{
		animator.CrossFade("Blink", 0.1f, 2);
	}

	public virtual void Main()
	{
	}
}
