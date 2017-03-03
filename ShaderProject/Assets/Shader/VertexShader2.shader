Shader "Custom/VertexShader2" {
	Properties 
	{
		_Color("Color", Color) = (1,0,0,1) // Red 
		_MainTex ("Base texture", 2D) = "white" {} 
	}
	SubShader 
	{
		Pass
		{
			CGPROGRAM

			// Declare vertex and fragment functions
			#pragma vertex vert        
			#pragma fragment frag

			half4 _Color;
			sampler2D _MainTex;

			// Input
			struct vertInput
			{
				float4 pos : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			// Output
			struct vertOutput
			{
				float4 pos : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};

			// Vertex Shader
			vertOutput vert(vertInput input)
			{
				vertOutput o;
				o.pos = mul(UNITY_MATRIX_MVP, input.pos);
				o.texcoord = input.texcoord;
				return o;
			}

			// Frag Shader
			half4 frag(vertOutput output) : COLOR
			{
				half4 mainColour = tex2D(_MainTex, output.texcoord);
				return mainColour * _Color;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
