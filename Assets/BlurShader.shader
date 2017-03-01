// COMP30019 Graphics and Interaction
// Project 2
// Author: traillj


// Normal distribution and summing based on
// http://answers.unity3d.com/questions/407214/gaussian-blur-shader.html
// Recieves shadows based on
// https://alastaira.wordpress.com/2014/12/30/adding-shadows-to-a-unity-vertexfragment-shader-in-7-easy-steps/
Shader "Unlit/BlurShader"
{
	SubShader
	{
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			uniform sampler2D _MainTex;
			uniform float _BlurAmount;
			
			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				LIGHTING_COORDS(1, 2)
			};

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
				vertOut o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;

				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				float blurAmount = _BlurAmount;
				float4 sum = float4(0.0, 0.0, 0.0, 0.0);

				// Sum horizonally adjacent colours on the texture
				// according to a Normal distribution
				sum += tex2D(_MainTex, float2(v.uv.x - 5.0 * blurAmount, v.uv.y)) * 0.025;
				sum += tex2D(_MainTex, float2(v.uv.x - 4.0 * blurAmount, v.uv.y)) * 0.05;
				sum += tex2D(_MainTex, float2(v.uv.x - 3.0 * blurAmount, v.uv.y)) * 0.09;
				sum += tex2D(_MainTex, float2(v.uv.x - 2.0 * blurAmount, v.uv.y)) * 0.12;
				sum += tex2D(_MainTex, float2(v.uv.x - blurAmount, v.uv.y)) * 0.15;

				sum += tex2D(_MainTex, float2(v.uv.x, v.uv.y)) * 0.16;

				sum += tex2D(_MainTex, float2(v.uv.x + blurAmount, v.uv.y)) * 0.15;
				sum += tex2D(_MainTex, float2(v.uv.x + 2.0 * blurAmount, v.uv.y)) * 0.12;
				sum += tex2D(_MainTex, float2(v.uv.x + 3.0 * blurAmount, v.uv.y)) * 0.09;
				sum += tex2D(_MainTex, float2(v.uv.x + 4.0 * blurAmount, v.uv.y)) * 0.05;
				sum += tex2D(_MainTex, float2(v.uv.x + 5.0 * blurAmount, v.uv.y)) * 0.025;

				sum.a = 1;

				float attenuation = LIGHT_ATTENUATION(v);
				return sum * attenuation;
			}
			ENDCG
		}
	}
	Fallback "VertexLit"
}
