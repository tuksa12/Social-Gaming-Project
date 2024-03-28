// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:Bumped Specular,lico:1,lgpr:1,nrmq:1,limd:1,uamb:False,mssp:False,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32623,y:32759|diff-2-RGB,spec-29-OUT,gloss-40-OUT,normal-13-RGB,amdfl-297-OUT,olwid-315-OUT,olcol-327-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32990,y:32615,ptlb:Main Tex,ptin:_MainTex,tex:0b3a4f8834f265647a2936f082b684b5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:13,x:34085,y:33247,ptlb:Normalmap,ptin:_Normalmap,tex:925d4bb2c4e3dbe4389cf04d5afe6a95,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ValueProperty,id:29,x:33032,y:32807,ptlb:Specular,ptin:_Specular,glob:False,v1:1;n:type:ShaderForge.SFN_Slider,id:40,x:32954,y:32903,ptlb:Shininess,ptin:_Shininess,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_AmbientLight,id:295,x:33121,y:33239;n:type:ShaderForge.SFN_ValueProperty,id:296,x:33118,y:33443,ptlb:Ambient Power,ptin:_AmbientPower,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:297,x:32920,y:33321|A-295-RGB,B-296-OUT;n:type:ShaderForge.SFN_ValueProperty,id:315,x:34058,y:33467,ptlb:Outline Width,ptin:_OutlineWidth,glob:False,v1:0.1;n:type:ShaderForge.SFN_LightColor,id:321,x:33608,y:33213;n:type:ShaderForge.SFN_SwitchProperty,id:327,x:33348,y:33268,ptlb:Use Light Color,ptin:_UseLightColor,on:False|A-329-RGB,B-321-RGB;n:type:ShaderForge.SFN_Color,id:329,x:33596,y:33374,ptlb:Outline Color,ptin:_OutlineColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:2-13-29-40-296-315-329-327;pass:END;sub:END;*/

Shader "DLNK/Mobile/Bumped Outline" {
    Properties {
        _MainTex ("Main Tex", 2D) = "white" {}
        _Normalmap ("Normalmap", 2D) = "bump" {}
        _Specular ("Specular", Float ) = 1
        _Shininess ("Shininess", Range(0, 1)) = 0.5
        _AmbientPower ("Ambient Power", Float ) = 1
        _OutlineWidth ("Outline Width", Float ) = 0.1
        _OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _UseLightColor ("Use Light Color", Float ) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _OutlineWidth;
            uniform fixed _UseLightColor;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*_OutlineWidth,1));
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                return fixed4(lerp( _OutlineColor.rgb, _LightColor0.rgb, _UseLightColor ),0);
            }
            ENDCG
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
                float2 node_363 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_363.rg, _Normalmap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = _Shininess;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight += (UNITY_LIGHTMODEL_AMBIENT.rgb*_AmbientPower); // Diffuse Ambient Light
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_363.rg, _MainTex));
                finalColor += diffuseLight * node_2.rgb;
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
                float2 node_364 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_364.rg, _Normalmap))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = _Shininess;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_364.rg, _MainTex));
                finalColor += diffuseLight * node_2.rgb;
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
