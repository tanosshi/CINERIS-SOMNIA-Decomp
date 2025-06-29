using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/BlurV")]
	[ExecuteInEditMode]
	public sealed class PP_BlurV : PostProcessBase
	{
		public float blurStrength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/BlurV");
		}

		private void Start()
		{
			base.material.SetFloat("_BlurStrength", blurStrength);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_BlurStrength", blurStrength);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
