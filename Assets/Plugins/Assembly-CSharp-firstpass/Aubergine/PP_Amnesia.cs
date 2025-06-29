using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Amnesia")]
	[ExecuteInEditMode]
	public sealed class PP_Amnesia : PostProcessBase
	{
		public float density = 1f;

		public float speed = 3f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Amnesia");
		}

		private void Start()
		{
			base.material.SetFloat("_Density", density);
			base.material.SetFloat("_Speed", speed);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Density", density);
			base.material.SetFloat("_Speed", speed);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
