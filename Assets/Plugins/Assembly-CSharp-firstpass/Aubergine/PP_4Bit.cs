using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/4Bit")]
	public sealed class PP_4Bit : PostProcessBase
	{
		public int bitDepth = 2;

		public float contrast = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/4Bit");
		}

		private void Start()
		{
			base.material.SetFloat("_BitDepth", bitDepth);
			base.material.SetFloat("_Contrast", contrast);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_BitDepth", bitDepth);
			base.material.SetFloat("_Contrast", contrast);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
