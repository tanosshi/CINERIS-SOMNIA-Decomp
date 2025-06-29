using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Contours")]
	[ExecuteInEditMode]
	public sealed class PP_Contours : PostProcessBase
	{
		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Contours");
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, base.material);
		}
	}
}
