using System;
using UnityEngine;

[Serializable]
public class HeightFixWithObject : MonoBehaviour
{
	public GameObject target;

	public float height;

	public float speed;

	private Transform myTransform;

	private Transform targetTransform;

	public virtual void Start()
	{
		myTransform = transform;
		targetTransform = target.transform;
	}

	public virtual void Update()
	{
		float y = Mathf.Lerp(myTransform.position.y, targetTransform.position.y + height, speed * Time.deltaTime);
		Vector3 position = myTransform.position;
		float num = (position.y = y);
		Vector3 vector = (myTransform.position = position);
	}

	public virtual void Main()
	{
	}
}
