using System;
using UnityEngine;

[Serializable]
public class PositionSync : MonoBehaviour
{
	public AnimationTargetType targetType;

	public GameObject target;

	public string tagName;

	public bool useWorldVector;

	public Vector3 worldVector;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = transform;
		if (targetType == AnimationTargetType.Tag)
		{
			target = GameObject.FindWithTag(tagName);
		}
	}

	public virtual void Update()
	{
		if (target != null)
		{
			if (!useWorldVector)
			{
				myTransform.position = target.transform.position;
			}
			else
			{
				myTransform.position = target.transform.position + worldVector;
			}
		}
	}

	public virtual void Main()
	{
	}
}
