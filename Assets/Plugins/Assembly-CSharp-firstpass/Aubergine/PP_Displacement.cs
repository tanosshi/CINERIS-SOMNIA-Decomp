using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Displacement")]
	[ExecuteInEditMode]
	public sealed class PP_Displacement : PostProcessBase
	{
		public Texture bumpTexture;

		public float amount = 0.5f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Displacement");
		}

		private void Start()
		{
			if ((bool)bumpTexture)
			{
				base.material.SetTexture("_BumpTex", bumpTexture);
			}
			else
			{
				Debug.LogWarning("You must set the bumpTexture Texture");
			}
			base.material.SetFloat("_Amount", amount);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetTexture("_BumpTex", bumpTexture);
			base.material.SetFloat("_Amount", amount);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
