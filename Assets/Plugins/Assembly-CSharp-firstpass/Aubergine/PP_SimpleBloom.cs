using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/SimpleBloom")]
	public sealed class PP_SimpleBloom : PostProcessBase
	{
		public float strength = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/SimpleBloom");
		}

		private void Start()
		{
			base.material.SetFloat("_Strength", strength);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Strength", strength);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
