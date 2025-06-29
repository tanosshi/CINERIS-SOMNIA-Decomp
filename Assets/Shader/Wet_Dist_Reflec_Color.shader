Shader "Wet Shaders/Colored/Wet_Dist_Reflec_Color" {
Properties {
 _Texture1 ("_Texture1", 2D) = "black" {}
 _BumpMap1 ("_BumpMap1", 2D) = "black" {}
 _WetMap ("_WetMap", 2D) = "black" {}
 _Specular ("_Specular", Range(0,5)) = 1
 _Gloss ("_Gloss", Range(0,10)) = 0.3
 _Reflection ("_Reflection", CUBE) = "black" {}
 _ReflectPower ("_ReflectPower", Range(0,1)) = 0
 _DistortionMap1 ("_DistortionMap1", 2D) = "black" {}
 _DistortionMap2 ("_DistortionMap2", 2D) = "black" {}
 _DistortPower ("_DistortPower", Float) = 100
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