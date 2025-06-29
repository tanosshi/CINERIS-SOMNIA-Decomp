using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Wiggle")]
	[ExecuteInEditMode]
	public sealed class PP_Wiggle : PostProcessBase
	{
		public float speed = 10f;

		public float amplitude = 0.01f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Wiggle");
		}

		private void Start()
		{
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Amplitude", amplitude);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Amplitude", amplitude);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
