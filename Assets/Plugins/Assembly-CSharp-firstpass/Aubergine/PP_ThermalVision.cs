using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/ThermalVision")]
	public sealed class PP_ThermalVision : PostProcessBase
	{
		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/ThermalVision");
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, base.material);
		}
	}
}
