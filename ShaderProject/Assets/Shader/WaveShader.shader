﻿Shader "Custom/WaveShader" {
	Properties {
		_TintAmount ("Tint Amount", Range(0,1)) = 0.5
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Amplitude ("Wave Amplitude", Range(-1,1)) = 1
		_Frequency ("Wave Frequency", Range(0,5)) =2
		_Speed ("Speed", Range(0.1,80)) = 5
		_ColorA ("Color A", Color) = (1,1,1,1)
		_ColorB ("Color B", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		struct Input {
			float2 uv_MainTex;
			float3 vertColor;
		};

		sampler2D _MainTex;
		float4 _ColorA;
		float4 _ColorB;
		float _TintAmount;
		float _Frequency;
		float _Amplitude;
		float _Speed;
		float _OffsetVal;

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o)

			float time = _Time * _Speed;
			float waveValueA = sin(time + v.vertex.x * _Frequency) * _Amplitude;
			
			v.vertex.xyz = float3(v.vertex.x, v.vertex.y + waveValueA, v.vertex.z);
			v.normal = normalize(float3(v.normal.x + waveValueA, v.normal.y, v.normal.z));
			o.vertColor = float3(waveValueA, waveValueA, waveValueA);
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			float3 tintColor = lerp(_ColorA, _ColorB, IN.vertColor).rgb;
			o.Albedo = c.rgb * (tintColor * _TintAmount);
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
