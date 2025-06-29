using System;
using UnityEngine;

[Serializable]
public class BirdWalkController : MonoBehaviour
{
	public Animator animator;

	public Transform root;

	private float firstRootY;

	public virtual void Start()
	{
		firstRootY = root.transform.localPosition.y;
	}

	public virtual void Update()
	{
		float y = animator.GetFloat("Walk") + firstRootY;
		Vector3 localPosition = root.localPosition;
		float num = (localPosition.y = y);
		Vector3 vector = (root.localPosition = localPosition);
	}

	public virtual void Main()
	{
	}
}
