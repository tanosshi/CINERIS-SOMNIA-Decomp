using System;
using UnityEngine;

[Serializable]
public class OverlayMovieTexture : MonoBehaviour
{
	public MovieTexture movieTexture;

	public bool enable;

	public float alpha;

	public virtual void Start()
	{
		movieTexture.loop = true;
	}

	public virtual void Update()
	{
		if (!movieTexture.isPlaying && enable)
		{
			movieTexture.Play();
		}
		else if (movieTexture.isPlaying && !enable)
		{
			movieTexture.Stop();
		}
	}

	public virtual void OnGUI()
	{
		if (enable)
		{
			float a = alpha;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), movieTexture, ScaleMode.StretchToFill, true);
		}
	}

	public virtual void Main()
	{
	}
}
