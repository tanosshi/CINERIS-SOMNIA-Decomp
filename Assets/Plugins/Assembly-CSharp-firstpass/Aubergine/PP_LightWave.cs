using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/LightWave")]
	public sealed class PP_LightWave : PostProcessBase
	{
		public float red = 4f;

		public float green = 4f;

		public float blue = 4f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/LightWave");
		}

		private void Start()
		{
			base.material.SetFloat("_Red", red);
			base.material.SetFloat("_Green", green);
			base.material.SetFloat("_Blue", blue);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Red", red);
			base.material.SetFloat("_Green", green);
			base.material.SetFloat("_Blue", blue);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
