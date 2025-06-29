using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/LensCircle")]
	[ExecuteInEditMode]
	public sealed class PP_LensCircle : PostProcessBase
	{
		public float centerX = 0.5f;

		public float centerY = 0.5f;

		public float radiusX = 1f;

		public float radiusY;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/LensCircle");
		}

		private void Start()
		{
			base.material.SetFloat("_CenterX", centerX);
			base.material.SetFloat("_CenterY", centerY);
			base.material.SetFloat("_RadiusX", radiusX);
			base.material.SetFloat("_RadiusY", radiusY);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_CenterX", centerX);
			base.material.SetFloat("_CenterY", centerY);
			base.material.SetFloat("_RadiusX", radiusX);
			base.material.SetFloat("_RadiusY", radiusY);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
