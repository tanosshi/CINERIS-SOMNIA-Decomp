using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/SecurityCamera")]
	[ExecuteInEditMode]
	public sealed class PP_SecurityCamera : PostProcessBase
	{
		public float speed = 2f;

		public float thickness = 3f;

		public float luminance = 0.5f;

		public float darkness = 0.75f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/SecurityCamera");
		}

		private void Start()
		{
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Thickness", thickness);
			base.material.SetFloat("_Luminance", luminance);
			base.material.SetFloat("_Darkness", darkness);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Thickness", thickness);
			base.material.SetFloat("_Luminance", luminance);
			base.material.SetFloat("_Darkness", darkness);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
