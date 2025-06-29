using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/FakeSSAO")]
	public sealed class PP_FakeSSAO : PostProcessBase
	{
		public int amount = 4;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/FakeSSAO");
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
