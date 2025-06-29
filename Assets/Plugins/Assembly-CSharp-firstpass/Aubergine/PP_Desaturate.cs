using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Desaturate")]
	public sealed class PP_Desaturate : PostProcessBase
	{
		public float amount = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Desaturate");
		}

		private void Start()
		{
			base.material.SetFloat("_Amount", amount);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Amount", amount);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
