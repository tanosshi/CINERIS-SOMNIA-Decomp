Shader "Advanced Hair Shader Pack/doublesided/Aniso Kajiya DoubleSided Correct" {
Properties {
 _MainTex ("Diffuse (RGB) Alpha (A)", 2D) = "white" {}
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecularTex ("Specular (R) Gloss (G) Anisotropic Mask (B)", 2D) = "gray" {}
 _SpecularMultiplier ("Specular Multiplier", Float) = 1
 _SpecularColor ("Specular Color", Color) = (1,1,1,1)
 _Cutoff ("Alpha Cut-Off Threshold", Float) = 0.95
 _Gloss ("Gloss Multiplier", Float) = 128
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