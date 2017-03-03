Shader "Custom/Fur2" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_FurLength("Fur Length", Range(.0002, 1)) = .25
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
		_CutoffEnd("Alpha cutoff end", Range(0,1)) = 0.5
		_EdgeFade("Edge Fade", Range(0,1)) = 0.4
		_Gravity("Gravity direction", Vector) = (0,0,1,0)
		_GravityStrength("G strenght", Range(0,1)) = 0.25
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.05 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM 
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.10 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.15 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.20 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.25 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.30 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.35 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.40
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.45 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.50
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.55 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.60
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.65 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.70 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.75 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.80 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.85 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.90 
			#include "FurPass.cginc" 
			ENDCG
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:blend vertex:vert
			#define FUR_MULTIPLIER 0.95 
			#include "FurPass.cginc" 
			ENDCG
				
		
	}
	FallBack "Diffuse"
}
