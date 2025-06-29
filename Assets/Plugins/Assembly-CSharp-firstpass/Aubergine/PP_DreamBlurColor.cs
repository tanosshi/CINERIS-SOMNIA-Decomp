using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/DreamBlurColor")]
	public sealed class PP_DreamBlurColor : PostProcessBase
	{
		public float blurStrength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/DreamBlurColor");
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
