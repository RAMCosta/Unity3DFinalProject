Shader "Reflective/River Water Vertex Color" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_ChromaticDispersion ("_ChromaticDispersion", Range(0.0,4.0)) = 0.1
	_Refraction ("Refraction", Range (0.00, 100.0)) = 1.0
	_ReflToRefrExponent ("_ReflToRefrExponent", Range(0.00,4.00)) = 1.0
	_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
	_BumpReflectionStr ("_BumpReflectionStr", Range(0.00,1.00)) = 0.5
	_MainTex ("Base (RGB) RefStrGloss (A)", 2D) = "white" {}
	_ReflectionTex ("_ReflectionTex", CUBE) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	//_Up ("_Up", Vector) = (0,1,0,1)
}

SubShader 
{	
	
	Tags { "RenderType"="Transparent" }
	LOD 400
	
	GrabPass 
	{ 
		
	}
	
	//Pass {

CGPROGRAM

#pragma surface surf BlinnPhong alpha
#pragma target 3.0

sampler2D _GrabTexture : register(s0);
sampler2D _MainTex : register(s1);
sampler2D _BumpMap : register(s2);
samplerCUBE _ReflectionTex : register(s3);

sampler2D _CameraDepthTexture; // : register(s4);

float4 _Color;
float4 _ReflectColor;
float _ChromaticDispersion;
float _Shininess;
float _WeirdScale;
float _Refraction;
float _BumpReflectionStr;
float _ReflToRefrExponent;

float4 _GrabTexture_TexelSize;
float4 _CameraDepthTexture_TexelSize;


struct Input {
	float4 color : COLOR;
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float3 worldRefl; 
	float4 screenPos;
	INTERNAL_DATA
};

void surf (Input IN, inout SurfaceOutput o) 
{
	half4 tex = half4(1,1,1,1); //tex2D(_MainTex, IN.uv_MainTex);
	tex.g = tex2D(_MainTex, IN.uv_MainTex + _CameraDepthTexture_TexelSize.xy*_ChromaticDispersion).g;
	
	// shore blending
	float z1 = tex2Dproj(_CameraDepthTexture,  IN.screenPos); // in /.w space
	z1 =  LinearEyeDepth(z1);	
	float z2 = (IN.screenPos.z);
	z1 = saturate( 0.125 * (abs(z2-z1)) );
	
	half4 c = tex * _Color;
	o.Albedo = c.rgb;
	
	o.Gloss = tex.a;
	o.Specular = _Shininess;
	
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	o.Normal += UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - 5.0 * _Time.y * _GrabTexture_TexelSize.xy));
	o.Normal *= 0.5;

	float2 offset = o.Normal * _Refraction * z1 * _GrabTexture_TexelSize.xy;
	IN.screenPos.xy = offset * IN.screenPos.z + IN.screenPos.xy;	
	
	float3 worldRefl = WorldReflectionVector(IN, o.Normal*half3(_BumpReflectionStr,_BumpReflectionStr,_BumpReflectionStr));
	half4 reflcol = texCUBE(_ReflectionTex, worldRefl);
	reflcol *= tex.a;
	
	float3 reflColor = reflcol.rgb * _ReflectColor.rgb;
	float3 refrColor = tex2Dproj(_GrabTexture, IN.screenPos);
	
	o.Alpha = saturate(z1*1.0) * IN.color.a; // this magic constant might needed to be tweaked
	
	float refl2Refr = abs(dot(o.Normal,normalize(worldRefl)));
	
	// clamp to always have a little bit of everything
	o.Emission = c * lerp(reflColor,refrColor, clamp(pow(refl2Refr,_ReflToRefrExponent),0.1,0.9));
	o.Albedo = o.Emission;
	o.Emission *= 0.5;
}
ENDCG
//}
}

	
FallBack "Reflective/Bumped Diffuse"
}
