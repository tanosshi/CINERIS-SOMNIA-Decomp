using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/RadialBlur")]
	[ExecuteInEditMode]
	public sealed class PP_RadialBlur : PostProcessBase
	{
		public float centerX = 0.5f;

		public float centerY = 0.5f;

		public float strength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/RadialBlur");
		}

		private void Start()
		{
			base.material.SetFloat("_CenterX", centerX);
			base.material.SetFloat("_CenterY", centerY);
			base.material.SetFloat("_Strength", strength);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_CenterX", centerX);
			base.material.SetFloat("_CenterY", centerY);
			base.material.SetFloat("_Strength", strength);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
