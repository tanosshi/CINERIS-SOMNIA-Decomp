using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Noise")]
	public sealed class PP_Noise : PostProcessBase
	{
		public float noiseScale = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Noise");
		}

		private void Start()
		{
			base.material.SetFloat("_NoiseScale", noiseScale);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_NoiseScale", noiseScale);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
