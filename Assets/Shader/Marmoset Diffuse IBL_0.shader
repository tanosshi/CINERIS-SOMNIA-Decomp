Shader "Marmoset/Transparent/Cutout/Diffuse IBL" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
 _MainTex ("Diffuse(RGB) Alpha(A)", 2D) = "white" {}
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