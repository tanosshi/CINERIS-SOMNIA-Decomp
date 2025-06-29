using System;
using UnityEngine;

[Serializable]
public class Animate : MonoBehaviour
{
	public Vector2 distortSpeed1;

	public Vector2 distortSpeed2;

	public virtual void Start()
	{
		distortSpeed1 /= 10f;
		distortSpeed2 /= 10f;
	}

	public virtual void Update()
	{
		Vector2 offset = new Vector2
		{
			x = Time.time * distortSpeed1.x,
			y = Time.time * distortSpeed1.y
		};
		Vector2 offset2 = new Vector2
		{
			x = Time.time * distortSpeed2.x % 1f,
			y = Time.time * distortSpeed2.y % 1f
		};
		renderer.material.SetTextureOffset("_DistortionMap1", offset);
		renderer.material.SetTextureOffset("_DistortionMap2", offset2);
	}

	public virtual void Main()
	{
	}
}
