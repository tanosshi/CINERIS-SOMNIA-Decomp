using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/BlackAndWhite")]
	[ExecuteInEditMode]
	public sealed class PP_BlackAndWhite : PostProcessBase
	{
		public float threshold = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/BlackAndWhite");
		}

		private void Start()
		{
			base.material.SetFloat("_Threshold", threshold);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Threshold", threshold);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
