using System;
using UnityEngine;

[Serializable]
public class FollowTarget : MonoBehaviour
{
	public AnimationTargetType targetType;

	public Transform target;

	public string tagName;

	public float walkSpeed;

	public float runSpeed;

	public float backSpeed;

	public float startWalkDistance;

	public float startRunDistance;

	public float startBackDistance;

	public float stopDistance;

	private Animator animator;

	private AnimatorStateInfo currentState;

	public bool canRun;

	public bool nowFollowing;

	private NavMeshAgent navagent;

	private Vector3 moveDirection;

	public bool lookAtTarget;

	public float lookAtAngle;

	public float lookSpeed;

	public FollowTarget()
	{
		canRun = true;
		nowFollowing = true;
		moveDirection = Vector3.zero;
	}

	public virtual void Awake()
	{
		animator = (Animator)GetComponent(typeof(Animator));
	}

	public virtual void Start()
	{
		navagent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
		if (targetType == AnimationTargetType.Tag)
		{
			target = GameObject.FindWithTag(tagName).transform;
		}
		if (target != null)
		{
			navagent.SetDestination(target.position);
		}
	}

	public virtual void FixedUpdate()
	{
		if (nowFollowing)
		{
			if (target == null && targetType == AnimationTargetType.Tag)
			{
				target = GameObject.FindWithTag(tagName).transform;
			}
			if (!((transform.position - target.position).magnitude > stopDistance))
			{
				navagent.Stop();
				moveDirection = transform.TransformDirection(Vector3.forward);
				if (!((transform.position - target.position).magnitude > startBackDistance) && !(Vector3.Angle(moveDirection, target.position - transform.position) >= 80f))
				{
					animator.SetBool("Walk", false);
					animator.SetBool("Run", false);
					animator.SetBool("Back", true);
					navagent.Move(moveDirection * backSpeed * Time.deltaTime * -1f);
				}
				else
				{
					animator.SetBool("Walk", false);
					animator.SetBool("Run", false);
					animator.SetBool("Back", false);
				}
			}
			else if (!((transform.position - target.position).magnitude < startRunDistance) && canRun)
			{
				navagent.speed = runSpeed;
				navagent.SetDestination(target.position);
				animator.SetBool("Walk", true);
				animator.SetBool("Run", true);
				animator.SetBool("Back", false);
			}
			else if ((transform.position - target.position).magnitude <= startWalkDistance || !canRun)
			{
				navagent.speed = walkSpeed;
				navagent.SetDestination(target.position);
				animator.SetBool("Walk", true);
				animator.SetBool("Run", false);
				animator.SetBool("Back", false);
			}
			if (lookAtTarget && !(Vector3.Angle(moveDirection, target.position - transform.position) <= lookAtAngle))
			{
				transform.LookAt(Vector3.Lerp(transform.position + moveDirection, new Vector3(target.position.x, transform.position.y, target.position.z), lookSpeed * Time.deltaTime));
			}
			if (!(navagent.velocity.magnitude > 0.01f))
			{
				animator.SetBool("Walk", false);
				animator.SetBool("Run", false);
				animator.SetBool("Back", false);
			}
		}
		else
		{
			navagent.Stop();
		}
	}

	public virtual void ChangeFollow(int num)
	{
		if (num == 0)
		{
			navagent.Stop();
			nowFollowing = false;
			navagent.enabled = false;
		}
		else
		{
			nowFollowing = true;
			navagent.enabled = true;
		}
	}

	public virtual void ChangeWalkSpeed(float num)
	{
		walkSpeed = num;
	}

	public virtual void ChangeStartWalkDistance(float num)
	{
		startWalkDistance = num;
	}

	public virtual void ChangeStopDistance(float num)
	{
		stopDistance = num;
	}

	public virtual void Main()
	{
	}
}
