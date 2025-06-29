using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/SobelEdge")]
	[ExecuteInEditMode]
	public sealed class PP_SobelEdge : PostProcessBase
	{
		public float threshold = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/SobelEdge");
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
