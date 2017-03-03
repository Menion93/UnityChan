Shader "Custom/ScrollingTexture" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SliderX ("Slider Vel X", Range(0,10)) = 2
		_SliderY ("Slider Vel Y", Range(0,10)) = 2
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;
		float _SliderX;
		float _SliderY;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed2 newUv = IN.uv_MainTex;

			fixed velx = _SliderX * _Time;
			fixed vely = _SliderY * _Time;

			newUv += fixed2(velx, vely);

			fixed4 newCol = tex2D(_MainTex, newUv);

			fixed4 c = tex2D (_MainTex, newUv) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
