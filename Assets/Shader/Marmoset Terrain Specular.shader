Shader "Marmoset/Terrain/Terrain Specular IBL" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (1,1,1,1)
 _DetailWeight ("DetailWeight", Float) = 1
 _FadeNear ("Fade Start", Float) = 500
 _FadeRange ("Fade Range", Float) = 100
 _SpecInt ("Master Specular Intensity", Float) = 1
 _SpecInt0 ("Intensity 0", Range(0,1)) = 1
 _SpecInt1 ("Intensity 1", Range(0,1)) = 1
 _SpecInt2 ("Intensity 2", Range(0,1)) = 1
 _SpecInt3 ("Intensity 3", Range(0,1)) = 1
 _Shininess ("Master Specular Sharpness", Range(2,8)) = 4
 _Gloss0 ("Sharpness 0", Range(0,1)) = 1
 _Gloss1 ("Sharpness 1", Range(0,1)) = 1
 _Gloss2 ("Sharpness 2", Range(0,1)) = 1
 _Gloss3 ("Sharpness 3", Range(0,1)) = 1
 _SpecFresnel ("Specular Fresnel", Range(0,1)) = 0
 _DiffFresnel ("Master Diffuse Fresnel", Float) = 0
 _Fresnel0 ("Diffuse Fresnel 0", Range(0,1)) = 0
 _Fresnel1 ("Diffuse Fresnel 1", Range(0,1)) = 0
 _Fresnel2 ("Diffuse Fresnel 2", Range(0,1)) = 0
 _Fresnel3 ("Diffuse Fresnel 3", Range(0,1)) = 0
 _Fresnel4 ("Secondary Fresnel 4", Range(0,1)) = 0
 _Fresnel5 ("Secondary Fresnel 5", Range(0,1)) = 0
 _Fresnel6 ("Secondary Fresnel 6", Range(0,1)) = 0
 _Fresnel7 ("Secondary Fresnel 7", Range(0,1)) = 0
 _BaseTex ("Base Diffuse (RGB) AO (A)", 2D) = "white" {}
 _BumpMap ("Base Normalmap (RGB)", 2D) = "bump" {}
 _Control ("Splatmap (RGBA)", 2D) = "red" {}
 _Splat0 ("Layer 0 (RGB) Spec (A)", 2D) = "white" {}
 _Splat1 ("Layer 1 (RGB) Spec (A)", 2D) = "white" {}
 _Splat2 ("Layer 2 (RGB) Spec (A)", 2D) = "white" {}
 _Splat3 ("Layer 3 (RGB) Spec (A)", 2D) = "white" {}
 _Normal0 ("Normal 0", 2D) = "bump" {}
 _Normal1 ("Normal 1", 2D) = "bump" {}
 _Normal2 ("Normal 2", 2D) = "bump" {}
 _Normal3 ("Normal 3", 2D) = "bump" {}
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