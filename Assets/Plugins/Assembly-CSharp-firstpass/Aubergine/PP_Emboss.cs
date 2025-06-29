using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Emboss")]
	[ExecuteInEditMode]
	public sealed class PP_Emboss : PostProcessBase
	{
		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Emboss");
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, base.material);
		}
	}
}
