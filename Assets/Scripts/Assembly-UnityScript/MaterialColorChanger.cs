using System;
using UnityEngine;

[Serializable]
public class MaterialColorChanger : MonoBehaviour
{
	public AlphaChanger[] state;

	public virtual void MaterialColorChange(int id)
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", gameObject.renderer.material.color.a, "to", state[id].matAlpha, "time", state[id].changeTime, "onupdate", "SetMaterialAlpha"));
	}

	public virtual void SetMaterialAlpha(float alpha)
	{
		Color color = gameObject.renderer.material.color;
		float num = (color.a = alpha);
		Color color2 = (gameObject.renderer.material.color = color);
	}

	public virtual void Main()
	{
	}
}
