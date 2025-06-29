Shader "Hidden/Marmoset/Terrain/Terrain IBL AddPass" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _DetailWeight ("DetailWeight", Float) = 1
 _FadeNear ("Fade Near", Float) = 500
 _FadeRange ("Fade Range", Float) = 100
 _DiffFresnel ("Master Diffuse Fresnel", Range(0,1)) = 0
 _Fresnel0 ("Diffuse Fresnel 0", Range(0,1)) = 0
 _Fresnel1 ("Diffuse Fresnel 1", Range(0,1)) = 0
 _Fresnel2 ("Diffuse Fresnel 2", Range(0,1)) = 0
 _Fresnel3 ("Diffuse Fresnel 3", Range(0,1)) = 0
 _Fresnel4 ("Diffuse Fresnel 4", Range(0,1)) = 0
 _Fresnel5 ("Diffuse Fresnel 5", Range(0,1)) = 0
 _Fresnel6 ("Diffuse Fresnel 6", Range(0,1)) = 0
 _Fresnel7 ("Diffuse Fresnel 7", Range(0,1)) = 0
 _BaseTex ("Base Diffuse (RGB) Gloss (A)", 2D) = "white" {}
[HideInInspector]  _Control ("Splatmap (RGBA)", 2D) = "red" {}
[HideInInspector]  _Splat0 ("Layer 0 (R)", 2D) = "white" {}
[HideInInspector]  _Splat1 ("Layer 1 (G)", 2D) = "white" {}
[HideInInspector]  _Splat2 ("Layer 2 (B)", 2D) = "white" {}
[HideInInspector]  _Splat3 ("Layer 3 (A)", 2D) = "white" {}
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}