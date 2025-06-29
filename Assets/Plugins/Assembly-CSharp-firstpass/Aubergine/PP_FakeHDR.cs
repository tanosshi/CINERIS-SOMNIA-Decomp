using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/FakeHDR")]
	[ExecuteInEditMode]
	public sealed class PP_FakeHDR : PostProcessBase
	{
		public float amount = 0.5f;

		public float multiplier = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/FakeHDR");
		}

		private void Start()
		{
			base.material.SetFloat("_Amount", amount);
			base.material.SetFloat("_Multiplier", multiplier);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Amount", amount);
			base.material.SetFloat("_Multiplier", multiplier);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
