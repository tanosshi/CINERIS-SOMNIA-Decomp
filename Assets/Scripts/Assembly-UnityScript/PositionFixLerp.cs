using System;
using UnityEngine;

[Serializable]
public class PositionFixLerp : MonoBehaviour
{
	public Transform objectA;

	public Transform objectB;

	public float t;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = transform;
	}

	public virtual void Update()
	{
		myTransform.position = Vector3.Lerp(objectA.position, objectB.position, t);
	}

	public virtual void Main()
	{
	}
}
