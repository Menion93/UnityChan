Shader "Custom/PhongModel" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecPower ("Spec Power", Range(0,30)) = 1
		_SpecularColor("Spec Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Phong

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		float4 _SpecularColor;
		float _SpecPower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		fixed4 LightingPhong(SurfaceOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
		{
			float lamb = dot(lightDir, s.Normal);
			float3 reflectionVec = normalize(2 * lamb*s.Normal - lightDir);
			float3 specular = pow(max(0, dot(reflectionVec, viewDir)), _SpecPower) * _SpecularColor.rgb;

			fixed4 finalColor;
			finalColor.rgb = s.Albedo * _LightColor0.rgb * max(0, lamb) * atten + (_LightColor0.rgb * specular) + 0.1;
			finalColor.a = s.Alpha;

			return finalColor;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
