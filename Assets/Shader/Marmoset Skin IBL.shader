Shader "Marmoset/Beta/Skin IBL" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (1,1,1,1)
 _SpecInt ("Specular Intensity", Float) = 1
 _Shininess ("Specular Sharpness", Range(2,8)) = 4
 _Fresnel ("Specular Fresnel", Range(0,1)) = 0
 _MainTex ("Diffuse(RGB) Alpha(A)", 2D) = "white" {}
 _SpecTex ("Specular(RGB) Gloss(A)", 2D) = "white" {}
 _BumpMap ("Normal Map", 2D) = "bump" {}
 _NormalSmoothing ("Normal Smoothing", Range(0,1)) = 1
 _SubdermisColor ("Subdermis Color", Color) = (1,1,1,1)
 _Subdermis ("Subdermis", Range(0,1)) = 1
 _ConserveEnergy ("Conserve Energy", Range(0,1)) = 1
 _SubdermisTex ("Subdermis(RGB) Skin Mask(A)", 2D) = "white" {}
 _TranslucencyColor ("Translucency Color", Color) = (1,0.5,0.4,1)
 _Translucency ("Translucency", Range(0,1)) = 0
 _TranslucencySky ("Sky Translucency", Range(0,1)) = 0
 _TranslucencyMap ("Translucency Map", 2D) = "white" {}
 _FuzzColor ("Fuzz Color", Color) = (1,1,1,1)
 _Fuzz ("Fuzz", Range(0,1)) = 0
 _FuzzScatter ("Fuzz Scatter", Range(0,1)) = 1
 _FuzzOcc ("Fuzz Occlusion", Range(0.5,1)) = 0.5
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