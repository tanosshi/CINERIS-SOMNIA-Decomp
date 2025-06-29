using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Bleach")]
	public sealed class PP_Bleach : PostProcessBase
	{
		public float opacity = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Bleach");
		}

		private void Start()
		{
			base.material.SetFloat("_Opacity", opacity);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Opacity", opacity);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
