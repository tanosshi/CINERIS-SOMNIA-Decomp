Shader "Mirror" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Tags { "RenderType"="Opaque" }
  SetTexture [_MainTex] { combine texture }
  SetTexture [_ReflectionTex] { Matrix [_ProjMatrix] combine texture * previous }
 }
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Tags { "RenderType"="Opaque" }
  SetTexture [_MainTex] { combine texture }
 }
}
}