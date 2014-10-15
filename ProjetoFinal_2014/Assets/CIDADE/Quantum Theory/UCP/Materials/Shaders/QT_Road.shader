Shader "QuantumTheory/QT-Road"
{
	Properties 
	{
_MainTex("Base (RGB) Gloss (A)", 2D) = "white" {}
_MaskBias("Bias of the Mask", Range(-1,1) ) = 0.5
_Subtraction("Mask Subtraction", Range(0,1) ) = 0.5

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
float _MaskBias;
float _Subtraction;

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
float4 Multiply0=_MaskBias.xxxx * float4( 20,20,20,20 );
float4 Split0=Tex2D0;
float4 Subtract0=float4( Split0.x, Split0.x, Split0.x, Split0.x) - _Subtraction.xxxx;
float4 Multiply3=Multiply0 * Subtract0;
float4 Add0=Multiply3 + _Subtraction.xxxx;
float4 Saturate0=saturate(Add0);
float4 Multiply1=IN.color * Saturate0;
float4 Add1=Tex2D0 + Multiply1;
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_2_NoInput = float4(0,0,0,0);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_4_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Add1;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}