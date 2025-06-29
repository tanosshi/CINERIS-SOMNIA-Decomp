using System;
using UnityEngine;

[Serializable]
public class DoorAnimationController : MonoBehaviour
{
	public string animationName;

	private Animator animator;

	public virtual void Start()
	{
		animator = (Animator)GetComponent(typeof(Animator));
	}

	public virtual void Open()
	{
		animator.Play(animationName, 0);
	}

	public virtual void Main()
	{
	}
}
