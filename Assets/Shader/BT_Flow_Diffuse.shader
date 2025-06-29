Shader "Vacuum/Flow/Base_Transparent/Flow_Diffuse" {
Properties {
 _BaseColor ("Base Color (A)", Color) = (1,1,1,1)
 _MainTex ("Base Texture", 2D) = "" {}
 _FlowColor ("Flow Color (A)", Color) = (1,1,1,1)
 _FlowTexture ("Flow Texture", 2D) = "" {}
 _FlowMap ("FlowMap (RG) Alpha (B) Gradient (A)", 2D) = "" {}
 _RevealSize ("Flow Reveal Size", Range(-1,1)) = 1
 _RevealPow ("Reveal Pow", Range(1,128)) = 1
 _Strength ("Noise strength", Range(0,1)) = 0
 _Noise ("Flow Noise (R)", 2D) = "" {}
 _Emission ("Flow Emission", Range(0,2)) = 0
 _DistorScale ("Distortion Scale", Float) = 0
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