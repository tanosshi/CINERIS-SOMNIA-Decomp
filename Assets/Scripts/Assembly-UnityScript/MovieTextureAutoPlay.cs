using System;
using UnityEngine;

[Serializable]
public class MovieTextureAutoPlay : MonoBehaviour
{
	public MovieTexture movTexture;

	public virtual void Start()
	{
		movTexture.loop = true;
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}

	public virtual void Main()
	{
	}
}
