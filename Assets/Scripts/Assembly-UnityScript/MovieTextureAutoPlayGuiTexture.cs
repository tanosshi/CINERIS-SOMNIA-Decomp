using System;
using UnityEngine;

[Serializable]
public class MovieTextureAutoPlayGuiTexture : MonoBehaviour
{
	public MovieTexture movTexture;

	private GUITexture gTexture;

	public virtual void Start()
	{
		gTexture = (GUITexture)gameObject.GetComponent(typeof(GUITexture));
		guiTexture.texture = movTexture;
		movTexture.loop = false;
		movTexture.Play();
	}

	public virtual void Main()
	{
	}
}
