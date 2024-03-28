// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:Bumped Specular,lico:1,lgpr:1,nrmq:1,limd:1,uamb:False,mssp:False,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32623,y:32759|diff-150-OUT,spec-247-OUT,gloss-217-OUT,normal-13-RGB,lwrap-253-OUT,amdfl-297-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33326,y:32637,ptlb:Main Tex,ptin:_MainTex,tex:0b3a4f8834f265647a2936f082b684b5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:13,x:33326,y:32820,ptlb:Normalmap,ptin:_Normalmap,tex:925d4bb2c4e3dbe4389cf04d5afe6a95,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ValueProperty,id:29,x:33189,y:32737,ptlb:Specular,ptin:_Specular,glob:False,v1:1;n:type:ShaderForge.SFN_Slider,id:40,x:32991,y:32912,ptlb:Shininess,ptin:_Shininess,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2d,id:58,x:34052,y:32374,ptlb:Tint Mask,ptin:_TintMask,tex:d7c23120784aec24f918f0ddc02f1295,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:95,x:33826,y:32211,ptlb:Color A (RGB) Gloss(A),ptin:_ColorARGBGlossA,glob:False,c1:0.2228401,c2:0.1956099,c3:0.9852941,c4:0.2;n:type:ShaderForge.SFN_Color,id:102,x:33826,y:32053,ptlb:Color B (RGB) Gloss(A),ptin:_ColorBRGBGlossA,glob:False,c1:0.4068966,c2:1,c3:0,c4:0.4;n:type:ShaderForge.SFN_Color,id:108,x:33826,y:31881,ptlb:Color C (RGB) Gloss(A),ptin:_ColorCRGBGlossA,glob:False,c1:1,c2:0.2352941,c3:0.2352941,c4:0.6;n:type:ShaderForge.SFN_Multiply,id:126,x:34101,y:32577|A-58-R,B-58-G,C-58-B;n:type:ShaderForge.SFN_Color,id:128,x:33826,y:32374,ptlb:Color D (RGB) Gloss(A),ptin:_ColorDRGBGlossA,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:134,x:33627,y:32040|A-102-RGB,B-58-G;n:type:ShaderForge.SFN_Multiply,id:135,x:33627,y:31881|A-108-RGB,B-58-R;n:type:ShaderForge.SFN_Multiply,id:139,x:33622,y:32211|A-95-RGB,B-58-B;n:type:ShaderForge.SFN_Add,id:142,x:33435,y:32060|A-135-OUT,B-134-OUT,C-139-OUT;n:type:ShaderForge.SFN_Lerp,id:143,x:33435,y:32211|A-142-OUT,B-128-RGB,T-126-OUT;n:type:ShaderForge.SFN_Multiply,id:144,x:33233,y:32473|A-143-OUT,B-2-RGB,C-234-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:150,x:33044,y:32473,ptlb:Tint Enable,ptin:_TintEnable,on:False|A-2-RGB,B-144-OUT;n:type:ShaderForge.SFN_Multiply,id:192,x:33622,y:32477|A-58-R,B-108-A;n:type:ShaderForge.SFN_Multiply,id:194,x:33622,y:32603|A-58-G,B-102-A;n:type:ShaderForge.SFN_Multiply,id:196,x:33622,y:32725|A-58-B,B-95-A;n:type:ShaderForge.SFN_Add,id:197,x:33471,y:32411|A-192-OUT,B-194-OUT,C-196-OUT;n:type:ShaderForge.SFN_Lerp,id:198,x:33454,y:32535|A-197-OUT,B-128-A,T-126-OUT;n:type:ShaderForge.SFN_Multiply,id:217,x:32991,y:32752|A-198-OUT,B-40-OUT;n:type:ShaderForge.SFN_Tex2d,id:233,x:33622,y:32890,ptlb:Height Occ Trans,ptin:_HeightOccTrans,tex:aa4fa9d366778434487bfe578f342a8c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:234,x:33044,y:32318|VAL-233-G,EXP-235-OUT;n:type:ShaderForge.SFN_ValueProperty,id:235,x:33233,y:32341,ptlb:Occlusion Power,ptin:_OcclusionPower,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:247,x:33009,y:32635|A-234-OUT,B-29-OUT;n:type:ShaderForge.SFN_Multiply,id:253,x:33143,y:33027|A-233-B,B-143-OUT,C-256-OUT,D-262-OUT;n:type:ShaderForge.SFN_ValueProperty,id:256,x:33411,y:33148,ptlb:Trans Power,ptin:_TransPower,glob:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:262,x:33411,y:33007|IN-198-OUT;n:type:ShaderForge.SFN_AmbientLight,id:295,x:33121,y:33239;n:type:ShaderForge.SFN_ValueProperty,id:296,x:33118,y:33443,ptlb:Ambient Power,ptin:_AmbientPower,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:297,x:32927,y:33290|A-295-RGB,B-296-OUT;proporder:2-13-29-40-150-58-95-102-108-128-233-235-256-296;pass:END;sub:END;*/

Shader "DLNK/Mobile/CharacterMobile" {
    Properties {
        _MainTex ("Main Tex", 2D) = "white" {}
        _Normalmap ("Normalmap", 2D) = "bump" {}
        _Specular ("Specular", Float ) = 1
        _Shininess ("Shininess", Range(0, 1)) = 0.5
        [MaterialToggle] _TintEnable ("Tint Enable", Float ) = 1
        _TintMask ("Tint Mask", 2D) = "white" {}
        _ColorARGBGlossA ("Color A (RGB) Gloss(A)", Color) = (0.2228401,0.1956099,0.9852941,0.2)
        _ColorBRGBGlossA ("Color B (RGB) Gloss(A)", Color) = (0.4068966,1,0,0.4)
        _ColorCRGBGlossA ("Color C (RGB) Gloss(A)", Color) = (1,0.2352941,0.2352941,0.6)
        _ColorDRGBGlossA ("Color D (RGB) Gloss(A)", Color) = (0.5,0.5,0.5,1)
        _HeightOccTrans ("Height Occ Trans", 2D) = "white" {}
        _OcclusionPower ("Occlusion Power", Float ) = 1
        _TransPower ("Trans Power", Float ) = 1
        _AmbientPower ("Ambient Power", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _Specular;
            uniform float _Shininess;
            uniform sampler2D _TintMask; uniform float4 _TintMask_ST;
            uniform float4 _ColorARGBGlossA;
            uniform float4 _ColorBRGBGlossA;
            uniform float4 _ColorCRGBGlossA;
            uniform float4 _ColorDRGBGlossA;
            uniform fixed _TintEnable;
            uniform sampler2D _HeightOccTrans; uniform float4 _HeightOccTrans_ST;
            uniform float _OcclusionPower;
            uniform float _TransPower;
            uniform float _AmbientPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_321 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_321.rg, _Normalmap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float4 node_233 = tex2D(_HeightOccTrans,TRANSFORM_TEX(node_321.rg, _HeightOccTrans));
                float4 node_58 = tex2D(_TintMask,TRANSFORM_TEX(node_321.rg, _TintMask));
                float node_126 = (node_58.r*node_58.g*node_58.b);
                float3 node_143 = lerp(((_ColorCRGBGlossA.rgb*node_58.r)+(_ColorBRGBGlossA.rgb*node_58.g)+(_ColorARGBGlossA.rgb*node_58.b)),_ColorDRGBGlossA.rgb,node_126);
                float node_198 = lerp(((node_58.r*_ColorCRGBGlossA.a)+(node_58.g*_ColorBRGBGlossA.a)+(node_58.b*_ColorARGBGlossA.a)),_ColorDRGBGlossA.a,node_126);
                float3 w = (node_233.b*node_143*_TransPower*(1.0 - node_198))*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 diffuse = forwardLight * attenColor;
///////// Gloss:
                float gloss = (node_198*_Shininess);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_234 = pow(node_233.g,_OcclusionPower);
                float node_247 = (node_234*_Specular);
                float3 specularColor = float3(node_247,node_247,node_247);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight += (UNITY_LIGHTMODEL_AMBIENT.rgb*_AmbientPower); // Diffuse Ambient Light
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_321.rg, _MainTex));
                finalColor += diffuseLight * lerp( node_2.rgb, (node_143*node_2.rgb*node_234), _TintEnable );
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _Specular;
            uniform float _Shininess;
            uniform sampler2D _TintMask; uniform float4 _TintMask_ST;
            uniform float4 _ColorARGBGlossA;
            uniform float4 _ColorBRGBGlossA;
            uniform float4 _ColorCRGBGlossA;
            uniform float4 _ColorDRGBGlossA;
            uniform fixed _TintEnable;
            uniform sampler2D _HeightOccTrans; uniform float4 _HeightOccTrans_ST;
            uniform float _OcclusionPower;
            uniform float _TransPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_322 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_322.rg, _Normalmap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float4 node_233 = tex2D(_HeightOccTrans,TRANSFORM_TEX(node_322.rg, _HeightOccTrans));
                float4 node_58 = tex2D(_TintMask,TRANSFORM_TEX(node_322.rg, _TintMask));
                float node_126 = (node_58.r*node_58.g*node_58.b);
                float3 node_143 = lerp(((_ColorCRGBGlossA.rgb*node_58.r)+(_ColorBRGBGlossA.rgb*node_58.g)+(_ColorARGBGlossA.rgb*node_58.b)),_ColorDRGBGlossA.rgb,node_126);
                float node_198 = lerp(((node_58.r*_ColorCRGBGlossA.a)+(node_58.g*_ColorBRGBGlossA.a)+(node_58.b*_ColorARGBGlossA.a)),_ColorDRGBGlossA.a,node_126);
                float3 w = (node_233.b*node_143*_TransPower*(1.0 - node_198))*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 diffuse = forwardLight * attenColor;
///////// Gloss:
                float gloss = (node_198*_Shininess);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_234 = pow(node_233.g,_OcclusionPower);
                float node_247 = (node_234*_Specular);
                float3 specularColor = float3(node_247,node_247,node_247);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_322.rg, _MainTex));
                finalColor += diffuseLight * lerp( node_2.rgb, (node_143*node_2.rgb*node_234), _TintEnable );
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Bumped Specular"
    CustomEditor "ShaderForgeMaterialInspector"
}
