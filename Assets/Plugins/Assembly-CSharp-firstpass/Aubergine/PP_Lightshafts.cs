using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Lightshafts")]
	[ExecuteInEditMode]
	public sealed class PP_Lightshafts : PostProcessBase
	{
		public Transform lightSource;

		public float density = 1f;

		public float weight = 1f;

		public float decay = 1f;

		public float exposure = 1f;

		private Vector3 lightPos;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Lightshafts");
		}

		private void Start()
		{
			base.material.SetFloat("_Density", density);
			base.material.SetFloat("_Weight", weight);
			base.material.SetFloat("_Decay", decay);
			base.material.SetFloat("_Exposure", exposure);
			lightPos = base.camera.WorldToViewportPoint(lightSource.position);
			base.material.SetVector("_LightPos", lightPos);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			lightPos = base.camera.WorldToViewportPoint(lightSource.position);
			if (lightPos.x < 0f || lightPos.x > 1f || lightPos.y < 0f || lightPos.y > 1f || lightPos.z < 0f)
			{
				base.material.SetVector("_LightPos", new Vector3(0.5f, 0.5f, 0f));
				base.material.SetFloat("_Density", density - density + 0.1f);
				base.material.SetFloat("_Weight", weight);
				base.material.SetFloat("_Decay", decay);
				base.material.SetFloat("_Exposure", exposure);
			}
			else
			{
				base.material.SetVector("_LightPos", lightPos);
				base.material.SetFloat("_Density", density);
				base.material.SetFloat("_Weight", weight);
				base.material.SetFloat("_Decay", decay);
				base.material.SetFloat("_Exposure", exposure);
			}
			Graphics.Blit(source, destination, base.material);
		}
	}
}
