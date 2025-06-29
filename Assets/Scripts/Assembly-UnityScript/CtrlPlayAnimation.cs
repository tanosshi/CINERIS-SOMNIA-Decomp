using System;
using UnityEngine;

[Serializable]
public class CtrlPlayAnimation
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public PlayOrStop operation;

	public float fadeTime;

	public AnimationType animationType;

	public int animationId;

	public string animationName;

	public int legacyLayer;

	public Animator animator;
}
