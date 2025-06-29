using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/StereoAnaglyph-AmberBlue")]
	[ExecuteInEditMode]
	public sealed class PP_StereoAnaglyph_AmberBlue : PostProcessBase
	{
		public float distance = 0.005f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/StereoAnaglyph-AmberBlue");
		}

		private void Start()
		{
			Matrix4x4 zero = Matrix4x4.zero;
			zero.m00 = 1.062f;
			zero.m01 = -0.026f;
			zero.m02 = -0.038f;
			zero.m03 = 0f;
			zero.m10 = -0.205f;
			zero.m11 = 0.908f;
			zero.m12 = -0.173f;
			zero.m13 = 0f;
			zero.m20 = 0.299f;
			zero.m21 = 0.068f;
			zero.m22 = 0.022f;
			zero.m23 = 0f;
			zero.m30 = 0f;
			zero.m31 = 0f;
			zero.m32 = 0f;
			zero.m33 = 0f;
			Matrix4x4 zero2 = Matrix4x4.zero;
			zero2.m00 = -0.016f;
			zero2.m01 = 0.006f;
			zero2.m02 = 0.094f;
			zero2.m03 = 0f;
			zero2.m10 = -0.123f;
			zero2.m11 = 0.062f;
			zero2.m12 = 0.185f;
			zero2.m13 = 0f;
			zero2.m20 = -0.017f;
			zero2.m21 = -0.017f;
			zero2.m22 = 0.911f;
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
