Shader "Custom/RadiusShader" {
	Properties {
		_Center ("Center", Vector) = (0,0,0)
		_Radius ("Radius", Float) = 1
		_RadiusColor ("RadiusColor", Color) = (1,0,0,1)
		_DefColor ("DefColor", Color) = (1,1,1,1)
		_RadiusWidth ("RadiusWidth", Float) = 1
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
			float2 uv_MainTex;
			float3 worldPos;
		};

		fixed4 _Color;
		fixed4 _DefColor;
		float3 _Center;
		float _Radius;
		fixed4 _RadiusColor;
		float _RadiusWidth;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float d = distance(_Center, IN.worldPos);

			if (d > _Radius && d < _Radius + _RadiusWidth)
			{
				o.Albedo = _RadiusColor.rgb;
			}
			else
			{
				o.Albedo = _DefColor.rgb;
			}
					
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
