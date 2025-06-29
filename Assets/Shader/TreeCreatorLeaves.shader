Shader "Marmoset/Nature/Tree Creator Leaves" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.078125
 _SpecInt ("Specular Intensity", Float) = 1
 _Fresnel ("Fresnel Falloff", Range(0,1)) = 1
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _GlossMap ("Gloss (A)", 2D) = "black" {}
 _TranslucencyMap ("Translucency (A)", 2D) = "white" {}
 _ShadowOffset ("Shadow Offset (A)", 2D) = "black" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.3
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
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