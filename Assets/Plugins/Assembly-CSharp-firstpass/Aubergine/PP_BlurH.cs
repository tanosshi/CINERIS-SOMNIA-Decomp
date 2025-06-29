using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/BlurH")]
	[ExecuteInEditMode]
	public sealed class PP_BlurH : PostProcessBase
	{
		public float blurStrength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/BlurH");
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
