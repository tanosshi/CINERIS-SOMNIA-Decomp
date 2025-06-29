using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Frost")]
	[ExecuteInEditMode]
	public sealed class PP_Frost : PostProcessBase
	{
		public Texture noiseTexture;

		public float amount = 1f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Frost");
		}

		private void Start()
		{
			if ((bool)noiseTexture)
			{
				base.material.SetTexture("_NoiseTex", noiseTexture);
			}
			else
			{
				Debug.LogWarning("You must set the noiseTexture Texture");
			}
			base.material.SetFloat("_Amount", amount);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetTexture("_NoiseTex", noiseTexture);
			base.material.SetFloat("_Amount", amount);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
