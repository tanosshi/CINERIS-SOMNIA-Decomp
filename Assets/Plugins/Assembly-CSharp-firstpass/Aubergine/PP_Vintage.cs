using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Vintage")]
	public sealed class PP_Vintage : PostProcessBase
	{
		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Vintage");
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, base.material);
		}
	}
}
