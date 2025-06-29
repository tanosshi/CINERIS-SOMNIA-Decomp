using System;
using UnityEngine;

[Serializable]
public class BloodLeakController : MonoBehaviour
{
	public float minPosition;

	public float maxPosition;

	public float speed;

	private Transform playerTransform;

	private Material myMaterial;

	private float size;

	private float offset;

	public virtual void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").transform;
		myMaterial = gameObject.renderer.material;
	}

	public virtual void Update()
	{
		if (!(playerTransform.position.x < minPosition))
		{
			myMaterial.SetFloat("_RevealSize", 0f);
		}
		else if (!(playerTransform.position.x > maxPosition))
		{
			myMaterial.SetFloat("_RevealSize", 1f);
		}
		else
		{
			size = (playerTransform.position.x - minPosition) / (maxPosition - minPosition);
			myMaterial.SetFloat("_RevealSize", size);
		}
		offset += speed * Time.deltaTime;
		if (!(offset < 1f))
		{
			offset = 0f;
		}
		myMaterial.SetTextureOffset("_FlowTexture", new Vector2(0f, offset));
		myMaterial.SetTextureOffset("_FlowBump", new Vector2(0f, offset));
	}

	public virtual void Main()
	{
	}
}
