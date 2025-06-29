using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Vignette")]
	[ExecuteInEditMode]
	public sealed class PP_Vignette : PostProcessBase
	{
		public float radius = 10f;

		public float darkness = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Vignette");
		}

		private void Start()
		{
			base.material.SetFloat("_Radius", radius);
			base.material.SetFloat("_Darkness", darkness);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Radius", radius);
			base.material.SetFloat("_Darkness", darkness);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
