using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/StereoAnaglyph-GreenMagenta")]
	[ExecuteInEditMode]
	public sealed class PP_StereoAnaglyph_GreenMagenta : PostProcessBase
	{
		public float distance = 0.005f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/StereoAnaglyph-GreenMagenta");
		}

		private void Start()
		{
			Matrix4x4 zero = Matrix4x4.zero;
			zero.m00 = -0.062f;
			zero.m01 = 0.284f;
			zero.m02 = -0.015f;
			zero.m03 = 0f;
			zero.m10 = -0.158f;
			zero.m11 = 0.668f;
			zero.m12 = -0.027f;
			zero.m13 = 0f;
			zero.m20 = -0.039f;
			zero.m21 = 0.143f;
			zero.m22 = 0.021f;
			zero.m23 = 0f;
			zero.m30 = 0f;
			zero.m31 = 0f;
			zero.m32 = 0f;
			zero.m33 = 0f;
			Matrix4x4 zero2 = Matrix4x4.zero;
			zero2.m00 = 0.529f;
			zero2.m01 = -0.016f;
			zero2.m02 = 0.009f;
			zero2.m03 = 0f;
			zero2.m10 = 0.705f;
			zero2.m11 = -0.015f;
			zero2.m12 = 0.075f;
			zero2.m13 = 0f;
			zero2.m20 = 0.024f;
			zero2.m21 = -0.065f;
			zero2.m22 = 0.937f;
			zero2.m23 = 0f;
			zero2.m30 = 0f;
			zero2.m31 = 0f;
			zero2.m32 = 0f;
			zero2.m33 = 0f;
			base.material.SetMatrix("_MtxColor0", zero);
			base.material.SetMatrix("_MtxColor1", zero2);
			base.material.SetFloat("_Distance", distance);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_Distance", distance);
			Graphics.Blit(source, destination, base.material);
		}
	}
}
