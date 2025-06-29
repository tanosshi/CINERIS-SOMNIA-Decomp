using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/Holywood")]
	[ExecuteInEditMode]
	public sealed class PP_Holywood : PostProcessBase
	{
		public float lumThreshold = 0.13f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/Holywood");
		}

		private void Start()
		{
			Matrix4x4 zero = Matrix4x4.zero;
			zero.m00 = 0.5149f;
			zero.m01 = 0.3244f;
			zero.m02 = 0.1607f;
			zero.m03 = 0f;
			zero.m10 = 0.2654f;
			zero.m11 = 0.6704f;
			zero.m12 = 0.0642f;
			zero.m13 = 0f;
			zero.m20 = 0.0248f;
			zero.m21 = 0.1248f;
			zero.m22 = 0.8504f;
			zero.m23 = 0f;
			zero.m30 = 0f;
			zero.m31 = 0f;
			zero.m32 = 0f;
			zero.m33 = 0f;
			base.material.SetMatrix("_MtxColor", zero);
			base.material.SetFloat("_LumThreshold", lumThreshold);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_LumThreshold", lumThreshold);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
