using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Pixelated")]
	[ExecuteInEditMode]
	public sealed class PP_Pixelated : PostProcessBase
	{
		public int pixelWidth = 16;

		public int pixelHeight = 16;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Pixelated");
		}

		private void Start()
		{
			base.material.SetFloat("_PixWidth", pixelWidth);
			base.material.SetFloat("_PixHeight", pixelHeight);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_PixWidth", pixelWidth);
			base.material.SetFloat("_PixHeight", pixelHeight);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
