Shader "Custom/NormalMap" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_NormalTex ("Normal Map", 2D) = "bump" {}
		_NormalMapIntensity ("Intensity", Range(0,10)) = 1
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float2 uv_NormalTex;
		};

		sampler2D _NormalTex;
		float _NormalMapIntensity;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float3 normalMap = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));

			normalMap.x *= _NormalMapIntensity;
			normalMap.y *= _NormalMapIntensity;

			o.Normal = normalMap.rgb;

			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
