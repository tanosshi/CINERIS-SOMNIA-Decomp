using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/LineArt")]
	[ExecuteInEditMode]
	public sealed class PP_LineArt : PostProcessBase
	{
		public Color lineColor = Color.black;

		public float strength = 80f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/LineArt");
		}

		private void Start()
		{
			base.material.SetVector("_LineColor", lineColor);
			base.material.SetFloat("_Strength", strength);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetVector("_LineColor", lineColor);
			base.material.SetFloat("_Strength", strength);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
