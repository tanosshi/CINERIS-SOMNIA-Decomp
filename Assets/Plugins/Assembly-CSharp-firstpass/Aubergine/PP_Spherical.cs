using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/Spherical")]
	public sealed class PP_Spherical : PostProcessBase
	{
		public float radius = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Spherical");
		}

		private void Start()
		{
			base.material.SetFloat("_Radius", radius);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Radius", radius);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
