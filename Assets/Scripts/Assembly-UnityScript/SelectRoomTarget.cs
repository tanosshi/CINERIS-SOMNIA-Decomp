using System;
using UnityEngine;

[Serializable]
public class SelectRoomTarget : MonoBehaviour
{
	public SelectRoomController selectRoomObject;

	public int commonId;

	public GameObject glassObject;

	public float speed;

	public float fadeSpeed;

	public float maxAlpha;

	public float intervalTime;

	public float firstOffset;

	private bool nowSelect;

	private Material glassMaterial;

	private float offsetX;

	private float offsetY;

	private float alpha;

	private float emission;

	private bool nowShining;

	private float remainingTime;

	private bool canShine;

	public virtual void Start()
	{
		if (glassObject != null)
		{
			glassMaterial = glassObject.renderer.material;
			glassMaterial.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha));
			glassMaterial.SetFloat("_Emission", emission);
		}
		remainingTime = UnityEngine.Random.Range(0f, intervalTime);
	}

	public virtual void Update()
	{
		nowSelect = selectRoomObject.ShowSelectFlag();
		if (!nowSelect)
		{
			canShine = false;
		}
		if (nowSelect)
		{
			if (selectRoomObject.ShowSelectId() != commonId)
			{
				canShine = false;
			}
			else if (!canShine)
			{
				canShine = true;
				if (alpha == 0f)
				{
					offsetY = firstOffset;
				}
			}
		}
		if (nowShining && canShine)
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
			if (glassObject != null)
			{
				glassMaterial.SetColor("_BaseColor", new Color(1f, 1f, 1f, alpha));
				glassMaterial.SetFloat("_Emission", emission);
			}
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
			if (glassObject != null)
			{
				glassMaterial.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
			}
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
			if (glassObject != null)
			{
				glassMaterial.SetColor("_BaseColor", new Color(1f, 1f, 1f, alpha));
				glassMaterial.SetFloat("_Emission", emission);
			}
			offsetX += speed * Time.deltaTime;
			offsetY += speed * Time.deltaTime;
			if (!(offsetX < 1f))
			{
				offsetX = 0f;
			}
			if (!(offsetY < 1f))
			{
				offsetY = 0f;
			}
			if (!(offsetX > -1f))
			{
				offsetX = 0f;
			}
			if (!(offsetY > -1f))
			{
				offsetY = 0f;
			}
			if (glassObject != null)
			{
				glassMaterial.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
			}
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

	public virtual void OnMouseEnter()
	{
		if (nowSelect)
		{
			Debug.Log("MouseEnter:" + gameObject.name);
			selectRoomObject.SetSelectId(commonId);
		}
	}

	public virtual void OnMouseExit()
	{
		if (nowSelect)
		{
			Debug.Log("MouseExit:" + gameObject.name);
		}
	}

	public virtual void OnMouseDown()
	{
		if (nowSelect)
		{
			Debug.Log("MouseDown:" + gameObject.name);
			canShine = false;
			selectRoomObject.SendMessage("SelectComplete", commonId);
		}
	}

	public virtual void Main()
	{
	}
}
