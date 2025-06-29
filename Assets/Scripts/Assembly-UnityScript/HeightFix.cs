using System;
using UnityEngine;

[Serializable]
public class HeightFix : MonoBehaviour
{
	public float height;

	private Transform myTransform;

	public virtual void Start()
	{
		myTransform = gameObject.transform;
	}

	public virtual void Update()
	{
		float y = height;
		Vector3 position = myTransform.position;
		float num = (position.y = y);
		Vector3 vector = (myTransform.position = position);
	}

	public virtual void Main()
	{
	}
}
