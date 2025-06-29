using System;
using UnityEngine;

[Serializable]
public class Shaker
{
	public float frequency = 0.1f;

	public float amount = 1f;

	public int octave = 3;

	private Vector2[] vectors;

	private float time;

	public float Scalar
	{
		get
		{
			ResetIfNeed();
			return Perlin.Fbm(vectors[0] * time, octave) * amount * 2f;
		}
	}

	public Vector3 Position
	{
		get
		{
			ResetIfNeed();
			return new Vector3(Perlin.Fbm(vectors[0] * time, octave), Perlin.Fbm(vectors[1] * time, octave), Perlin.Fbm(vectors[2] * time, octave)) * (amount * 2f);
		}
	}

	public Quaternion YawPitch
	{
		get
		{
			ResetIfNeed();
			return Quaternion.AngleAxis(Perlin.Fbm(vectors[0] * time, octave) * amount * 2f, Vector3.up) * Quaternion.AngleAxis(Perlin.Fbm(vectors[1] * time, octave) * amount * 2f, Vector3.right);
		}
	}

	public void Update(float delta)
	{
		ResetIfNeed();
		time += delta * frequency;
	}

	public void Reset()
	{
		vectors = new Vector2[3];
		time = UnityEngine.Random.value * 10f;
		for (int i = 0; i < 3; i++)
		{
			float f = UnityEngine.Random.value * (float)Math.PI * 2f;
			vectors[i].Set(Mathf.Cos(f), Mathf.Sin(f));
		}
	}

	public void ResetIfNeed()
	{
		if (vectors == null)
		{
			Reset();
		}
	}
}
