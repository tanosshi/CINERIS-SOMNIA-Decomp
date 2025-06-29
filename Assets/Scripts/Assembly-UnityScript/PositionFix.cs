using System;
using UnityEngine;

[Serializable]
public class PositionFix : MonoBehaviour
{
	public Vector3 setPosition;

	private Transform myTransform;

	public virtual void Awake()
	{
		myTransform = transform;
	}

	public virtual void Update()
	{
		myTransform.position = setPosition;
	}

	public virtual void Main()
	{
	}
}
