using System;
using UnityEngine;

namespace Aubergine
{
	[ExecuteInEditMode]
	[AddComponentMenu("Aubergine/Image Effects/HeightFog")]
	public class PP_HeightFog : PostProcessBase
	{
		public float Density = 100f;

		public float Height;

		public float FallOff = 1f;

		public float Scale = 0.0025f;

		public float Speed = 0.005f;

		public Texture2D NoiseTex;

		public Color FogColor = Color.gray;

		private void Awake()
		{
			shader = Shader.Find("Hidden/Aubergine/ImageEffects/HeightFog");
			base.camera.depthTextureMode |= DepthTextureMode.Depth;
		}

		private void Start()
		{
			base.material.SetVector("_Height", new Vector4(Height, 1f / FallOff));
			base.material.SetFloat("_Density", Density * 0.01f);
			base.material.SetTexture("_NoiseTex", NoiseTex);
			base.material.SetColor("_FogColor", FogColor);
			base.material.SetFloat("_Scale", Scale);
			base.material.SetFloat("_Speed", Speed);
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
			base.material.SetVector("_Height", new Vector4(Height, 1f / FallOff));
			base.material.SetFloat("_Density", Density * 0.01f);
			base.material.SetTexture("_NoiseTex", NoiseTex);
			base.material.SetColor("_FogColor", FogColor);
			base.material.SetFloat("_Scale", Scale);
			base.material.SetFloat("_Speed", Speed);
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
