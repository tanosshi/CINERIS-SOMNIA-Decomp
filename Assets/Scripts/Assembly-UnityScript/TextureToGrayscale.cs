using System;
using UnityEngine;

[Serializable]
public class TextureToGrayscale : MonoBehaviour
{
	private int i;

	public virtual void MakeGrayscale(Texture2D tex)
	{
		Color[] pixels = tex.GetPixels();
		for (i = 0; i < pixels.Length; i++)
		{
			float grayscale = pixels[i].grayscale;
			pixels[i] = new Color(grayscale, grayscale, grayscale, pixels[i].a);
		}
		tex.SetPixels(pixels);
		tex.Apply();
	}

	public virtual void Main()
	{
	}
}
