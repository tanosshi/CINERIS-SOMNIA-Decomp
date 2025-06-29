using System;
using UnityEngine;

[Serializable]
public class TitlePhotoScreenController : MonoBehaviour
{
	public GameObject photo;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		float a = photo.renderer.material.color.a;
		Color color = renderer.material.color;
		float num = (color.a = a);
		Color color2 = (renderer.material.color = color);
		renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
	}

	public virtual void Main()
	{
	}
}
