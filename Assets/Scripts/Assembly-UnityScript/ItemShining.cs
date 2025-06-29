using System;
using UnityEngine;

[Serializable]
public class ItemShining : MonoBehaviour
{
	public float speed;

	public float fadeSpeed;

	public float maxAlpha;

	public float intervalTime;

	public bool syncBaseColor;

	private Material myMaterial;

	private float offsetX;

	private float offsetY;

	private float alpha;

	private float emission;

	private bool nowShining;

	private float remainingTime;

	private Color myColor;

	public virtual void Start()
	{
		myMaterial = gameObject.renderer.material;
		remainingTime = UnityEngine.Random.Range(0f, intervalTime);
		myMaterial.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha));
		myMaterial.SetFloat("_Emission", emission);
		myColor = myMaterial.GetColor("_BaseColor");
	}

	public virtual void Update()
	{
		if (syncBaseColor)
		{
			myMaterial.SetColor("_BaseColor", new Color(myColor.r, myColor.g, myColor.b, alpha));
		}
		if (nowShining)
		{
			alpha += fadeSpeed * Time.deltaTime;
			if (!(alpha < maxAlpha))
			{
				alpha = maxAlpha;
			}
			emission += fadeSpeed * Time.deltaTime;
			if (!(emission < 1f))
			{
				emission = 1f;
			}
			myMaterial.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha));
			myMaterial.SetFloat("_Emission", emission);
			offsetX += speed * Time.deltaTime;
			offsetY += speed * Time.deltaTime;
			if (!(offsetX < 1f))
			{
				offsetX = 0f;
				EndItemShining();
			}
			if (!(offsetY < 1f))
			{
				offsetY = 0f;
				EndItemShining();
			}
			if (!(offsetX > -1f))
			{
				offsetX = 0f;
				EndItemShining();
			}
			if (!(offsetY > -1f))
			{
				offsetY = 0f;
				EndItemShining();
			}
			myMaterial.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
		}
		else
		{
			remainingTime -= Time.deltaTime * 1f;
			alpha -= fadeSpeed * Time.deltaTime;
			if (!(alpha > 0f))
			{
				alpha = 0f;
			}
			emission -= fadeSpeed * Time.deltaTime;
			if (!(emission > 0f))
			{
				emission = 0f;
			}
			myMaterial.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha));
			myMaterial.SetFloat("_Emission", emission);
			if (!(remainingTime > 0f))
			{
				StartItemShining();
			}
		}
	}

	public virtual void StartItemShining()
	{
		nowShining = true;
	}

	public virtual void EndItemShining()
	{
		remainingTime = intervalTime;
		nowShining = false;
	}

	public virtual void Main()
	{
	}
}
