using System;
using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("Aubergine/Image Effects/ThermalVisionV2")]
	[ExecuteInEditMode]
	public class PP_ThermalVisionV2 : PostProcessBase
	{
		public Texture2D ThermalTex;

		public Texture2D NoiseTex;

		public float noiseAmount = 100f;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/ThermalVisionV2");
			base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
		}

		private void Start()
		{
			base.material.SetTexture("_ThermalTex", ThermalTex);
			base.material.SetTexture("_NoiseTex", NoiseTex);
			base.material.SetFloat("_NoiseAmount", noiseAmount);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!base.enabled)
			{
				Graphics.Blit(source, destination);
				return;
			}
			float nearClipPlane = base.camera.nearClipPlane;
			float farClipPlane = base.camera.farClipPlane;
			float fieldOfView = base.camera.fieldOfView;
			float num = fieldOfView * 0.5f;
			float aspect = base.camera.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			Vector3 vector = base.transform.right * nearClipPlane * Mathf.Tan(num * ((float)Math.PI / 180f)) * aspect;
			Vector3 vector2 = base.transform.up * nearClipPlane * Mathf.Tan(num * ((float)Math.PI / 180f));
			Vector3 vector3 = base.transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			identity.SetRow(0, vector3);
			vector3 = base.transform.forward * nearClipPlane + vector + vector2;
			vector3.Normalize();
			vector3 *= num2;
			identity.SetRow(1, vector3);
			vector3 = base.transform.forward * nearClipPlane + vector - vector2;
			vector3.Normalize();
			vector3 *= num2;
			identity.SetRow(2, vector3);
			vector3 = base.transform.forward * nearClipPlane - vector - vector2;
			vector3.Normalize();
			vector3 *= num2;
			identity.SetRow(3, vector3);
			base.material.SetMatrix("_WS_FrustumCorners", identity);
			base.material.SetVector("_WS_CameraPosition", base.transform.position);
			base.material.SetTexture("_ThermalTex", ThermalTex);
			base.material.SetTexture("_NoiseTex", NoiseTex);
			base.material.SetFloat("_NoiseAmount", noiseAmount);
			CustomGraphicsBlit(source, destination, base.material, 0);
		}

		private static void CustomGraphicsBlit(RenderTexture source, RenderTexture dest, Material mat, int pass)
		{
			RenderTexture.active = dest;
			mat.SetTexture("_MainTex", source);
			GL.PushMatrix();
			GL.LoadOrtho();
			mat.SetPass(pass);
			GL.Begin(7);
			GL.MultiTexCoord2(0, 0f, 0f);
			GL.Vertex3(0f, 0f, 3f);
			GL.MultiTexCoord2(0, 1f, 0f);
			GL.Vertex3(1f, 0f, 2f);
			GL.MultiTexCoord2(0, 1f, 1f);
			GL.Vertex3(1f, 1f, 1f);
			GL.MultiTexCoord2(0, 0f, 1f);
			GL.Vertex3(0f, 1f, 0f);
			GL.End();
			GL.PopMatrix();
		}
	}
}
