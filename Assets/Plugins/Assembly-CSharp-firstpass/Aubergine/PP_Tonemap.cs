using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Tonemap")]
	[ExecuteInEditMode]
	public sealed class PP_Tonemap : PostProcessBase
	{
		public float exposure = 0.1f;

		public float gamma = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Tonemap");
		}

		private void Start()
		{
			base.material.SetFloat("_Exposure", exposure);
			base.material.SetFloat("_Gamma", gamma);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Exposure", exposure);
			base.material.SetFloat("_Gamma", gamma);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
