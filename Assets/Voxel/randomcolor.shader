Shader "Custom/RandomColor" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" "DisableBatching" = "True" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;

		float rand(float3 co)
		{
			return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
		}

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			float3 pos = mul(unity_ObjectToWorld, fixed4(0, 0, 0, 1)).xyz;

			float r = rand(pos);
			pos += float3(.5, .5, .5);
			float g = rand(pos);
			pos += float3(1, 1, 1);
			float b = rand(pos);

			o.Albedo = half3(r,g,b) * tex2D(_MainTex, IN.uv_MainTex);
			o.Alpha = 1.0;
		}
		ENDCG
	}
	FallBack "Diffuse"
}