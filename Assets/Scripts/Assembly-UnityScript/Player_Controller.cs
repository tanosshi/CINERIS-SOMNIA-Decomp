using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Player_Controller : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024AnimationManager_00241303 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024num_00241304;

			internal Player_Controller _0024self__00241305;

			public _0024(int num, Player_Controller self_)
			{
				_0024num_00241304 = num;
				_0024self__00241305 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241305.startFlag = true;
					_0024self__00241305.startCount = 0;
					_0024self__00241305.animator.SetBool("Boring", false);
					_0024self__00241305.animator.SetBool("Walk", false);
					_0024self__00241305.animator.SetBool("Run", false);
					_0024self__00241305.animator.SetBool("ForceAnimation", true);
					_0024self__00241305.animator.SetInteger("AnimationId", _0024num_00241304);
					result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				case 2:
					_0024self__00241305.animator.SetBool("ForceAnimation", false);
					if (_0024self__00241305.animationFadeTime != 0f)
					{
						goto case 3;
					}
					_0024self__00241305.animator.SetLayerWeight(1, 1f);
					_0024self__00241305.startFlag = false;
					goto IL_01ff;
				case 3:
					_0024self__00241305.layerWeight = Mathf.MoveTowards(_0024self__00241305.layerWeight, 1f, Time.deltaTime / _0024self__00241305.animationFadeTime);
					_0024self__00241305.animator.SetLayerWeight(1, _0024self__00241305.layerWeight);
					if (!(_0024self__00241305.layerWeight <= 0.99f))
					{
						_0024self__00241305.animator.SetLayerWeight(1, 1f);
						_0024self__00241305.startFlag = false;
					}
					else
					{
						if (!_0024self__00241305.stopFlag || _0024self__00241305.stopCount >= _0024self__00241305.startCount)
						{
							_0024self__00241305.startCount++;
							result = (Yield(3, new WaitForEndOfFrame()) ? 1 : 0);
							break;
						}
						_0024self__00241305.startFlag = false;
					}
					goto IL_01ff;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01ff:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241306;

		internal Player_Controller _0024self__00241307;

		public _0024AnimationManager_00241303(int num, Player_Controller self_)
		{
			_0024num_00241306 = num;
			_0024self__00241307 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024num_00241306, _0024self__00241307);
		}
	}

	[Serializable]
	internal sealed class _0024StopAnimation_00241308 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal Player_Controller _0024self__00241309;

			public _0024(Player_Controller self_)
			{
				_0024self__00241309 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241309.stopFlag = true;
					_0024self__00241309.stopCount = 0;
					if (_0024self__00241309.animationFadeTime != 0f)
					{
						goto case 2;
					}
					_0024self__00241309.animator.SetLayerWeight(1, 0f);
					_0024self__00241309.stopFlag = false;
					_0024self__00241309.animator.Play("Idle", 1);
					goto IL_0184;
				case 2:
					_0024self__00241309.layerWeight = Mathf.MoveTowards(_0024self__00241309.layerWeight, 0f, Time.deltaTime / _0024self__00241309.animationFadeTime);
					_0024self__00241309.animator.SetLayerWeight(1, _0024self__00241309.layerWeight);
					if (!(_0024self__00241309.layerWeight >= 0.01f))
					{
						_0024self__00241309.animator.SetLayerWeight(1, 0f);
						_0024self__00241309.stopFlag = false;
						_0024self__00241309.animator.Play("Idle", 1);
					}
					else
					{
						if (!_0024self__00241309.startFlag || _0024self__00241309.startCount >= _0024self__00241309.stopCount)
						{
							_0024self__00241309.stopCount++;
							result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
							break;
						}
						_0024self__00241309.stopFlag = false;
					}
					goto IL_0184;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0184:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Player_Controller _0024self__00241310;

		public _0024StopAnimation_00241308(Player_Controller self_)
		{
			_0024self__00241310 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241310);
		}
	}

	public float walkSpeed;

	public float runSpeed;

	public float rotateSpeed;

	public float gravity;

	public float boringWaitTime;

	public GameObject defaultLookAtTarget;

	public bool freeLook;

	public AudioSource footStepAudioSource;

	public AudioClip[] footStepSE;

	public GameObject[] footEffect;

	public Transform leftFoot;

	public Transform rightFoot;

	public bool canRun;

	public bool isControllable;

	public CharacterController controller;

	public GameObject[] lightHouseStairTarget;

	public float moveSpeedMultiply;

	private Animator animator;

	private AnimatorStateInfo currentState;

	private float layerWeight;

	private float animationFadeTime;

	private bool startFlag;

	private bool stopFlag;

	private int startCount;

	private int stopCount;

	private Transform myTransform;

	private Transform cameraTransform;

	private Vector3 foward;

	private Vector3 right;

	private float v;

	private float h;

	private Vector3 moveDirection;

	private Vector3 targetDirection;

	private float nowSpeed;

	private float boringTimeTemp;

	private bool grounded;

	private bool isWalking;

	private bool isRunning;

	private bool isBoring;

	private bool rotateFlag;

	private Vector3 defaultLookAtPoint;

	private GameObject lookAtTarget;

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

	private int footStepId;

	private int footEffectId;

	private float blinkTime;

	private Player_Status status;

	public Player_Controller()
	{
		walkSpeed = 2f;
		runSpeed = 3f;
		rotateSpeed = 10f;
		gravity = 20f;
		canRun = true;
		moveSpeedMultiply = 1f;
		foward = Vector3.zero;
		right = Vector3.zero;
		moveDirection = Vector3.zero;
		targetDirection = Vector3.zero;
		rotateFlag = true;
		lookAtPoint = Vector3.zero;
		lookAtBodyWeight = 0.1f;
		lookAtHeadWeight = 1f;
		lookAtEyeWeight = 1f;
		lookAtClampWeight = 1f;
		lookAtFadeSpeed = 2f;
		ignoreAngle = 90f;
	}

	public virtual void Awake()
	{
		boringTimeTemp = boringWaitTime;
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
		cameraTransform = GameObject.FindWithTag("MainCamera").transform;
	}

	public virtual void Update()
	{
		currentState = animator.GetCurrentAnimatorStateInfo(0);
		if (status.nowPausing)
		{
			footStepAudioSource.bypassReverbZones = true;
		}
		else if (footStepAudioSource.bypassReverbZones)
		{
			footStepAudioSource.bypassReverbZones = false;
		}
		if (!isControllable)
		{
			nowSpeed = Mathf.Lerp(nowSpeed, 0f, 16f * Time.deltaTime);
			if (!(nowSpeed > 0.01f))
			{
				nowSpeed = 0f;
				moveDirection.x = 0f;
				moveDirection.z = 0f;
			}
		}
		else
		{
			isWalking = false;
			isRunning = false;
			Vector3 vector = ((!rotateFlag) ? myTransform.TransformDirection(Vector3.forward) : cameraTransform.TransformDirection(Vector3.forward));
			vector.y = 0f;
			vector = vector.normalized;
			right = new Vector3(vector.z, 0f, 0f - vector.x);
			if (status.switches[528] == 0)
			{
				v = Mathf.Clamp(cInput.GetAxisRaw("Vertical") + cInput.GetAxisRaw("J_Vertical"), -1f, 1f);
				h = Mathf.Clamp(cInput.GetAxisRaw("Horizontal") + cInput.GetAxisRaw("J_Horizontal"), -1f, 1f);
			}
			else
			{
				v = Mathf.Clamp(cInput.GetAxisRaw("Vertical") + cInput.GetAxisRaw("J_Vertical"), 0f, 1f);
			}
			if (rotateFlag)
			{
				targetDirection = h * right + v * vector;
			}
			if (status.switches[109] == 1 && lightHouseStairTarget.Length != 0)
			{
				Vector3 vector2 = default(Vector3);
				if (!(h < 0f))
				{
					vector2 = lightHouseStairTarget[1].transform.position - myTransform.transform.position;
				}
				else
				{
					vector2 = lightHouseStairTarget[0].transform.position - myTransform.transform.position;
					vector2 *= -1f;
				}
				vector2.y = 0f;
				targetDirection = h * vector2.normalized + v * vector;
			}
			if (targetDirection == Vector3.zero)
			{
				if (nowSpeed != 0f)
				{
					nowSpeed = Mathf.Lerp(nowSpeed, 0f, 8f * Time.deltaTime);
					if (!(nowSpeed > 0.01f))
					{
						nowSpeed = 0f;
						moveDirection = Vector3.zero;
					}
					else
					{
						moveDirection.x = (moveDirection.normalized * nowSpeed).x;
						moveDirection.z = (moveDirection.normalized * nowSpeed).z;
					}
				}
			}
			else
			{
				isWalking = true;
				Quaternion to = Quaternion.LookRotation(targetDirection);
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation, to, rotateSpeed * Time.deltaTime);
				if ((cInput.GetButton("Sprint") || cInput.GetButton("J_Sprint")) && canRun)
				{
					if (status.walkFlag == 0 && canRun)
					{
						isRunning = true;
						if (nowSpeed != runSpeed)
						{
							nowSpeed = Mathf.Lerp(nowSpeed, runSpeed, 4f * Time.deltaTime);
							if (!(Mathf.Abs(nowSpeed - runSpeed) > 0.01f))
							{
								nowSpeed = runSpeed;
							}
						}
					}
					else if (nowSpeed != walkSpeed)
					{
						nowSpeed = Mathf.Lerp(nowSpeed, walkSpeed, 4f * Time.deltaTime);
						if (!(Mathf.Abs(nowSpeed - walkSpeed) > 0.01f))
						{
							nowSpeed = walkSpeed;
						}
					}
				}
				else if (status.walkFlag != 0 && canRun)
				{
					isRunning = true;
					if (nowSpeed != runSpeed)
					{
						nowSpeed = Mathf.Lerp(nowSpeed, runSpeed, 4f * Time.deltaTime);
						if (!(Mathf.Abs(nowSpeed - runSpeed) > 0.01f))
						{
							nowSpeed = runSpeed;
						}
					}
				}
				else if (nowSpeed != walkSpeed)
				{
					nowSpeed = Mathf.Lerp(nowSpeed, walkSpeed, 4f * Time.deltaTime);
					if (!(Mathf.Abs(nowSpeed - walkSpeed) > 0.01f))
					{
						nowSpeed = walkSpeed;
					}
				}
				moveDirection.x = (targetDirection.normalized * nowSpeed * moveSpeedMultiply).x;
				moveDirection.z = (targetDirection.normalized * nowSpeed * moveSpeedMultiply).z;
			}
			if (isRunning)
			{
				animator.speed = 1f;
				isBoring = false;
				animator.SetBool("Boring", false);
				animator.SetBool("Walk", true);
				boringTimeTemp = boringWaitTime;
				animator.SetBool("Run", true);
			}
			else if (isWalking)
			{
				isBoring = false;
				animator.SetBool("Boring", false);
				animator.SetBool("Run", false);
				boringTimeTemp = boringWaitTime;
				animator.SetBool("Walk", true);
			}
			else
			{
				animator.speed = 1f;
				isBoring = true;
				if (!(boringTimeTemp <= 0f))
				{
					animator.SetBool("Boring", false);
					animator.SetBool("Walk", false);
					animator.SetBool("Run", false);
				}
				else
				{
					boringTimeTemp = 0f;
					animator.SetBool("Boring", true);
					animator.SetBool("Walk", false);
					animator.SetBool("Run", false);
				}
			}
			if (grounded)
			{
				moveDirection.y = 0f;
			}
			else
			{
				moveDirection.y -= gravity * Time.deltaTime;
			}
		}
		blinkTime -= Time.deltaTime;
		if (!(blinkTime > 0f))
		{
			AutoBlink();
			blinkTime = UnityEngine.Random.Range(2f, 8f);
		}
		LookAtTarget();
		if (isBoring)
		{
			boringTimeTemp -= Time.deltaTime;
		}
	}

	public virtual void FixedUpdate()
	{
		if (isControllable)
		{
			CollisionFlags collisionFlags = controller.Move(moveDirection * Time.deltaTime);
			grounded = (collisionFlags & CollisionFlags.Below) != 0;
		}
	}

	public virtual void Controllable(bool controllableInfo)
	{
		if (controllableInfo)
		{
			isControllable = true;
		}
		else
		{
			isControllable = false;
		}
	}

	public virtual void Rotatable(bool info)
	{
		if (info)
		{
			rotateFlag = true;
		}
		else
		{
			rotateFlag = false;
		}
	}

	public virtual void LookAtTarget()
	{
		Vector3 vector = myTransform.TransformDirection(Vector3.forward);
		if (defaultLookAtTarget != null)
		{
			defaultLookAtPoint = defaultLookAtTarget.transform.position;
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
		if (lookAtTarget != null && (ignoreAngle == 0f || !(Vector2.Angle(new Vector2(vector.x, vector.z), new Vector2(lookAtTarget.transform.position.x - myTransform.position.x, lookAtTarget.transform.position.z - myTransform.position.z)) >= ignoreAngle)))
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
			return;
		}
		if (freeLook)
		{
			if (!(Time.timeSinceLevelLoad < 1f))
			{
				lookAtPoint = Vector3.Lerp(lookAtPoint, defaultLookAtPoint, Time.deltaTime * lookAtFadeSpeed);
				lookAtWeight = Mathf.Lerp(lookAtWeight, 1f, Time.deltaTime * lookAtFadeSpeed);
			}
			else
			{
				lookAtPoint = defaultLookAtPoint;
				lookAtWeight = Mathf.Lerp(lookAtWeight, 1f, Time.deltaTime * lookAtFadeSpeed * 10f);
			}
		}
		else if (!(lookAtWeight > 0.0001f))
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

	public virtual void ChangeFreeLook(bool flag)
	{
		if (flag)
		{
			freeLook = true;
		}
		else
		{
			freeLook = false;
		}
	}

	public virtual void Footsteps()
	{
		if (!status.nowPausing && footStepSE[footStepId] != null)
		{
			footStepAudioSource.PlayOneShot(footStepSE[footStepId]);
		}
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

	public virtual void ChangeFootstepId(int num)
	{
		footStepId = num;
	}

	public virtual int ShowFootstepId()
	{
		return footStepId;
	}

	public virtual void ChangeFootEffectId(int num)
	{
		footEffectId = num;
	}

	public virtual int ShowFootEffectId()
	{
		return footEffectId;
	}

	public virtual void SetAnimationFadeTime(float time)
	{
		animationFadeTime = time;
	}

	public virtual IEnumerator AnimationManager(int num)
	{
		return new _0024AnimationManager_00241303(num, this).GetEnumerator();
	}

	public virtual IEnumerator StopAnimation()
	{
		return new _0024StopAnimation_00241308(this).GetEnumerator();
	}

	public virtual void AddLookAtPoint(Vector3 addVector)
	{
		lookAtPoint += addVector;
		animator.SetLookAtPosition(lookAtPoint);
	}

	public virtual void AutoBlink()
	{
		animator.CrossFade("Blink", 0.1f, 2);
	}

	public virtual void Main()
	{
		controller = (CharacterController)GetComponent(typeof(CharacterController));
	}
}
