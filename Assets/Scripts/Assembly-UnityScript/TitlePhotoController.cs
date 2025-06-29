using System;
using UnityEngine;

[Serializable]
public class TitlePhotoController : MonoBehaviour
{
	public GameObject samplePhoto;

	public float firstHeight;

	public virtual void Update()
	{
		if (samplePhoto.renderer.material.color.a != 0f)
		{
			float y = firstHeight;
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
		}
		else
		{
			int num2 = 100;
			Vector3 position2 = transform.position;
			float num3 = (position2.y = num2);
			Vector3 vector3 = (transform.position = position2);
		}
	}

	public virtual void Main()
	{
	}
}
