Shader "Custom/BlinnPhong" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecularPower ("Specular Power", Range(0.1,60)) = 3
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf CustomBlinnPhong

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _SpecularColor;
		float _SpecularPower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			o.Alpha = c.a;
		}

		fixed4 LightingCustomBlinnPhong(SurfaceOutput s, fixed3 lightDir, half3 viewDir, half atten)
		{
			float NdotL = max(0, dot(lightDir, s.Normal));
			float3 halfVector = normalize(viewDir + lightDir);

			float3 NdotH = max(0, dot(s.Normal, halfVector));
			float spec = pow(NdotH, _SpecularPower) * _SpecularColor;

			float4 finalColor;

			finalColor.rgb = s.Albedo * _LightColor0.rgb * NdotL + _SpecularColor.rgb * _LightColor0.rgb * spec * atten;
			finalColor.a = s.Alpha;

			return finalColor;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
