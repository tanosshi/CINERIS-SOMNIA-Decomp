using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Charcoal")]
	public sealed class PP_Charcoal : PostProcessBase
	{
		public Color lineColor = Color.black;

		public float strength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Charcoal");
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
