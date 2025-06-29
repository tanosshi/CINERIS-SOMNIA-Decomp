using System;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
	public Vector3 amplitude;

	public Vector3 speed;

	public Vector3 basePosition;

	private void Start()
	{
		basePosition = base.transform.position;
	}

	private void Update()
	{
		Vector3 vector = Time.time * speed * 2f * (float)Math.PI;
		Vector3 vector2 = new Vector3(amplitude.x * Mathf.Sin(vector.x), amplitude.y * Mathf.Sin(vector.y), amplitude.z * Mathf.Sin(vector.z));
		base.transform.position = basePosition + vector2;
	}
}
