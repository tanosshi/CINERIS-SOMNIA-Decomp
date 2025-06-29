using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Posterize")]
	[ExecuteInEditMode]
	public sealed class PP_Posterize : PostProcessBase
	{
		public int colors = 4;

		public float gamma = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Posterize");
		}

		private void Start()
		{
			base.material.SetFloat("_Colors", colors);
			base.material.SetFloat("_Gamma", gamma);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Colors", colors);
			base.material.SetFloat("_Gamma", gamma);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
