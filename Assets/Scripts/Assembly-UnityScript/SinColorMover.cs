using System;
using UnityEngine;

[Serializable]
public class SinColorMover : MonoBehaviour
{
	public float moveSpeed;

	public float minRange;

	public float maxRange;

	private float nowTime;

	public SinColorMover()
	{
		moveSpeed = 1f;
	}

	public virtual void OnEnable()
	{
		nowTime = 0f;
	}

	public virtual void Update()
	{
		nowTime += 1f * Time.deltaTime;
		float num = Mathf.Sin(nowTime * moveSpeed);
		float r = (maxRange + minRange) / 2f + num * (maxRange - minRange) / 2f;
		Color color = gameObject.renderer.material.color;
		float num2 = (color.r = r);
		Color color2 = (gameObject.renderer.material.color = color);
		float g = (maxRange + minRange) / 2f + num * (maxRange - minRange) / 2f;
		Color color4 = gameObject.renderer.material.color;
		float num3 = (color4.g = g);
		Color color5 = (gameObject.renderer.material.color = color4);
		float b = (maxRange + minRange) / 2f + num * (maxRange - minRange) / 2f;
		Color color7 = gameObject.renderer.material.color;
		float num4 = (color7.b = b);
		Color color8 = (gameObject.renderer.material.color = color7);
	}

	public virtual void Main()
	{
	}
}
