using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/NightVision")]
	[ExecuteInEditMode]
	public sealed class PP_NightVision : PostProcessBase
	{
		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/NightVision");
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, base.material);
		}
	}
}
