Shader "QuantumTheory/QT-DiffuseVCCubemap"
{
	Properties 
	{
_MainTex("Diffuse", 2D) = "white" {}
_Cube("Cubemap", Cube) = "black" {}
_CubeMask("Cubemap Mask (RGB)", 2D) = "black" {}

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  
#pragma target 2.0


sampler2D _MainTex;
samplerCUBE _Cube;
sampler2D _CubeMask;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
float4 Multiply1=float4( s.Albedo.x, s.Albedo.y, s.Albedo.z, 1.0 ) * light;
float4 Splat0=light.w;
float4 Multiply0=float4( s.Gloss.x, s.Gloss.y, s.Gloss.z, 1.0 ) * Splat0;
float4 Multiply2=light * Multiply0;
float4 Add2=Multiply1 + Multiply2;
float4 Mask1=float4(Add2.x,Add2.y,Add2.z,0.0);
float4 Luminance1= Luminance( Multiply0.xyz ).xxxx;
float4 Add0=Luminance1 + float4( s.Albedo.x, s.Albedo.y, s.Albedo.z, 1.0 );
float4 Mask0=float4(0.0,0.0,0.0,Add0.w);
float4 Add1=Mask1 + Mask0;
return Add1;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_MainTex;
float4 color : COLOR;
float3 viewDir;
float2 uv_CubeMask;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D0=tex2D(_MainTex,(IN.uv_MainTex.xyxy).xy);
float4 Multiply1=IN.color * float4( 2,2,2,2 );
float4 Multiply0=Tex2D0 * Multiply1;
float4 Split0=float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 );
float4 Multiply3=float4( Split0.y, Split0.y, Split0.y, Split0.y) * float4( -1,-1,-1,-1 );
float4 Assemble0=float4(float4( Split0.x, Split0.x, Split0.x, Split0.x).x, Multiply3.y, float4( Split0.z, Split0.z, Split0.z, Split0.z).z, float4( Split0.w, Split0.w, Split0.w, Split0.w).w);
float4 TexCUBE0=texCUBE(_Cube,Assemble0);
float4 Tex2D1=tex2D(_CubeMask,(IN.uv_CubeMask.xyxy).xy);
float4 Multiply2=TexCUBE0 * Tex2D1;
float4 Add0=Multiply0 + Multiply2;
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_2_NoInput = float4(0,0,0,0);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_4_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Add0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}