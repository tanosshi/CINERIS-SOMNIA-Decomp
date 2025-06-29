using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Pulse")]
	public sealed class PP_Pulse : PostProcessBase
	{
		public float directionX = 0.5f;

		public float directionY = 0.5f;

		public float speed = 5f;

		public float amplitude = 0.1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Pulse");
		}

		private void Start()
		{
			base.material.SetFloat("_DirectionX", directionX);
			base.material.SetFloat("_DirectionY", directionY);
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Amplitude", amplitude);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_DirectionX", directionX);
			base.material.SetFloat("_DirectionY", directionY);
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Amplitude", amplitude);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
