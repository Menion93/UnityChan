Shader "Custom/VertexShader" {
	Properties {
		_MainTint ("Main Tint", Color) = (1,1,1,1)
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
			float4 vertColor;
		};

		fixed4 _MainTint;

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o)
			o.vertColor = v.color;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = _MainTint.rgb * IN.vertColor.rgb;
			o.Alpha = _MainTint.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
