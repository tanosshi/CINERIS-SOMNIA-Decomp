using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Crosshatch")]
	[ExecuteInEditMode]
	public sealed class PP_Crosshatch : PostProcessBase
	{
		public Color lineColor = Color.white;

		public float strength = 0.01f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Crosshatch");
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
