using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/SinCity")]
	[ExecuteInEditMode]
	public sealed class PP_SinCity : PostProcessBase
	{
		public Color selectedColor = Color.red;

		public Color replacementColor = Color.white;

		public float desaturation = 0.5f;

		public float tolerance = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/SinCity");
		}

		private void Start()
		{
			base.material.SetVector("_SelectedColor", selectedColor);
			base.material.SetVector("_ReplacedColor", replacementColor);
			base.material.SetFloat("_Desaturation", desaturation);
			base.material.SetFloat("_Tolerance", tolerance);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetColor("_SelectedColor", selectedColor);
			base.material.SetColor("_ReplacedColor", replacementColor);
			base.material.SetFloat("_Desaturation", desaturation);
			base.material.SetFloat("_Tolerance", tolerance);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
