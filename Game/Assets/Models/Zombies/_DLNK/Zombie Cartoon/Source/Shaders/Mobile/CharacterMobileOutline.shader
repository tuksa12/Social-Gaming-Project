// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Bumped Specular,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:False,bkdf:False,hqlp:True,rprd:True,enco:True,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1,x:34118,y:32759,varname:node_1,prsc:2|diff-150-OUT,spec-247-OUT,gloss-217-OUT,normal-13-RGB,lwrap-253-OUT,amdfl-297-OUT,olwid-315-OUT,olcol-327-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33484,y:32637,ptovrint:False,ptlb:Main Tex,ptin:_MainTex,varname:node_2715,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b3a4f8834f265647a2936f082b684b5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:13,x:33484,y:32820,ptovrint:False,ptlb:Normalmap,ptin:_Normalmap,varname:node_3762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:925d4bb2c4e3dbe4389cf04d5afe6a95,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ValueProperty,id:29,x:33621,y:32737,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_614,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:40,x:33662,y:32912,ptovrint:False,ptlb:Shininess,ptin:_Shininess,varname:node_6810,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2d,id:58,x:32758,y:32374,ptovrint:False,ptlb:Tint Mask,ptin:_TintMask,varname:node_300,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d7c23120784aec24f918f0ddc02f1295,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:95,x:32984,y:32211,ptovrint:False,ptlb:Color A (RGB) Gloss(A),ptin:_ColorARGBGlossA,varname:node_2841,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2228401,c2:0.1956099,c3:0.9852941,c4:0.2;n:type:ShaderForge.SFN_Color,id:102,x:32984,y:32053,ptovrint:False,ptlb:Color B (RGB) Gloss(A),ptin:_ColorBRGBGlossA,varname:node_6120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4068966,c2:1,c3:0,c4:0.4;n:type:ShaderForge.SFN_Color,id:108,x:32984,y:31881,ptovrint:False,ptlb:Color C (RGB) Gloss(A),ptin:_ColorCRGBGlossA,varname:node_5941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2352941,c3:0.2352941,c4:0.6;n:type:ShaderForge.SFN_Multiply,id:126,x:32709,y:32577,varname:node_126,prsc:2|A-58-R,B-58-G,C-58-B;n:type:ShaderForge.SFN_Color,id:128,x:32984,y:32374,ptovrint:False,ptlb:Color D (RGB) Gloss(A),ptin:_ColorDRGBGlossA,varname:node_8506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:134,x:33183,y:32040,varname:node_134,prsc:2|A-102-RGB,B-58-G;n:type:ShaderForge.SFN_Multiply,id:135,x:33183,y:31881,varname:node_135,prsc:2|A-108-RGB,B-58-R;n:type:ShaderForge.SFN_Multiply,id:139,x:33188,y:32211,varname:node_139,prsc:2|A-95-RGB,B-58-B;n:type:ShaderForge.SFN_Add,id:142,x:33375,y:32060,varname:node_142,prsc:2|A-135-OUT,B-134-OUT,C-139-OUT;n:type:ShaderForge.SFN_Lerp,id:143,x:33375,y:32211,varname:node_143,prsc:2|A-142-OUT,B-128-RGB,T-126-OUT;n:type:ShaderForge.SFN_Multiply,id:144,x:33577,y:32473,varname:node_144,prsc:2|A-143-OUT,B-2-RGB,C-234-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:150,x:33766,y:32473,ptovrint:False,ptlb:Tint Enable,ptin:_TintEnable,varname:node_706,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2-RGB,B-144-OUT;n:type:ShaderForge.SFN_Multiply,id:192,x:33188,y:32477,varname:node_192,prsc:2|A-58-R,B-108-A;n:type:ShaderForge.SFN_Multiply,id:194,x:33188,y:32603,varname:node_194,prsc:2|A-58-G,B-102-A;n:type:ShaderForge.SFN_Multiply,id:196,x:33188,y:32725,varname:node_196,prsc:2|A-58-B,B-95-A;n:type:ShaderForge.SFN_Add,id:197,x:33339,y:32411,varname:node_197,prsc:2|A-192-OUT,B-194-OUT,C-196-OUT;n:type:ShaderForge.SFN_Lerp,id:198,x:33356,y:32535,varname:node_198,prsc:2|A-197-OUT,B-128-A,T-126-OUT;n:type:ShaderForge.SFN_Multiply,id:217,x:33819,y:32752,varname:node_217,prsc:2|A-198-OUT,B-40-OUT;n:type:ShaderForge.SFN_Tex2d,id:233,x:33188,y:32890,ptovrint:False,ptlb:Height Occ Trans,ptin:_HeightOccTrans,varname:node_4344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa4fa9d366778434487bfe578f342a8c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:234,x:33766,y:32318,varname:node_234,prsc:2|VAL-233-G,EXP-235-OUT;n:type:ShaderForge.SFN_ValueProperty,id:235,x:33577,y:32341,ptovrint:False,ptlb:Occlusion Power,ptin:_OcclusionPower,varname:node_3794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:247,x:33801,y:32635,varname:node_247,prsc:2|A-234-OUT,B-29-OUT;n:type:ShaderForge.SFN_Multiply,id:253,x:33667,y:33027,varname:node_253,prsc:2|A-233-B,B-143-OUT,C-256-OUT,D-262-OUT;n:type:ShaderForge.SFN_ValueProperty,id:256,x:33399,y:33148,ptovrint:False,ptlb:Trans Power,ptin:_TransPower,varname:node_5533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:262,x:33399,y:33007,varname:node_262,prsc:2|IN-198-OUT;n:type:ShaderForge.SFN_AmbientLight,id:295,x:33689,y:33239,varname:node_295,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:296,x:33692,y:33443,ptovrint:False,ptlb:Ambient Power,ptin:_AmbientPower,varname:node_8197,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:297,x:33883,y:33290,varname:node_297,prsc:2|A-295-RGB,B-296-OUT;n:type:ShaderForge.SFN_ValueProperty,id:315,x:33833,y:33103,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_5275,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_LightColor,id:321,x:33202,y:33213,varname:node_321,prsc:2;n:type:ShaderForge.SFN_SwitchProperty,id:327,x:33462,y:33268,ptovrint:False,ptlb:Use Light Color,ptin:_UseLightColor,varname:node_2261,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-329-RGB,B-321-RGB;n:type:ShaderForge.SFN_Color,id:329,x:33214,y:33374,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_5889,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:2-13-29-40-150-58-95-102-108-128-233-235-256-296-315-329-327;pass:END;sub:END;*/

Shader "DLNK/Mobile/CharacterMobile Outline" {
    Properties {
        _MainTex ("Main Tex", 2D) = "white" {}
        _Normalmap ("Normalmap", 2D) = "bump" {}
        _Specular ("Specular", Float ) = 1
        _Shininess ("Shininess", Range(0, 1)) = 0.5
        [MaterialToggle] _TintEnable ("Tint Enable", Float ) = 0
        _TintMask ("Tint Mask", 2D) = "white" {}
        _ColorARGBGlossA ("Color A (RGB) Gloss(A)", Color) = (0.2228401,0.1956099,0.9852941,0.2)
        _ColorBRGBGlossA ("Color B (RGB) Gloss(A)", Color) = (0.4068966,1,0,0.4)
        _ColorCRGBGlossA ("Color C (RGB) Gloss(A)", Color) = (1,0.2352941,0.2352941,0.6)
        _ColorDRGBGlossA ("Color D (RGB) Gloss(A)", Color) = (0.5,0.5,0.5,1)
        _HeightOccTrans ("Height Occ Trans", 2D) = "white" {}
        _OcclusionPower ("Occlusion Power", Float ) = 1
        _TransPower ("Trans Power", Float ) = 1
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float _OutlineWidth;
            uniform fixed _UseLightColor;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightColor = _LightColor0.rgb;
                return fixed4(lerp( _OutlineColor.rgb, _LightColor0.rgb, _UseLightColor ),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _TintMask_var = tex2D(_TintMask,TRANSFORM_TEX(i.uv0, _TintMask));
                float node_126 = (_TintMask_var.r*_TintMask_var.g*_TintMask_var.b);
                float node_198 = lerp(((_TintMask_var.r*_ColorCRGBGlossA.a)+(_TintMask_var.g*_ColorBRGBGlossA.a)+(_TintMask_var.b*_ColorARGBGlossA.a)),_ColorDRGBGlossA.a,node_126);
                float gloss = (node_198*_Shininess);
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _HeightOccTrans_var = tex2D(_HeightOccTrans,TRANSFORM_TEX(i.uv0, _HeightOccTrans));
                float node_234 = pow(_HeightOccTrans_var.g,_OcclusionPower);
                float node_247 = (node_234*_Specular);
                float3 specularColor = float3(node_247,node_247,node_247);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float normTerm = (specPow + 8.0 ) / (8.0 * Pi);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*normTerm*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 node_143 = lerp(((_ColorCRGBGlossA.rgb*_TintMask_var.r)+(_ColorBRGBGlossA.rgb*_TintMask_var.g)+(_ColorARGBGlossA.rgb*_TintMask_var.b)),_ColorDRGBGlossA.rgb,node_126);
                float3 w = (_HeightOccTrans_var.b*node_143*_TransPower*(1.0 - node_198))*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += (UNITY_LIGHTMODEL_AMBIENT.rgb*_AmbientPower); // Diffuse Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = lerp( _MainTex_var.rgb, (node_143*_MainTex_var.rgb*node_234), _TintEnable );
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _TintMask_var = tex2D(_TintMask,TRANSFORM_TEX(i.uv0, _TintMask));
                float node_126 = (_TintMask_var.r*_TintMask_var.g*_TintMask_var.b);
                float node_198 = lerp(((_TintMask_var.r*_ColorCRGBGlossA.a)+(_TintMask_var.g*_ColorBRGBGlossA.a)+(_TintMask_var.b*_ColorARGBGlossA.a)),_ColorDRGBGlossA.a,node_126);
                float gloss = (node_198*_Shininess);
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _HeightOccTrans_var = tex2D(_HeightOccTrans,TRANSFORM_TEX(i.uv0, _HeightOccTrans));
                float node_234 = pow(_HeightOccTrans_var.g,_OcclusionPower);
                float node_247 = (node_234*_Specular);
                float3 specularColor = float3(node_247,node_247,node_247);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float normTerm = (specPow + 8.0 ) / (8.0 * Pi);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*normTerm*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 node_143 = lerp(((_ColorCRGBGlossA.rgb*_TintMask_var.r)+(_ColorBRGBGlossA.rgb*_TintMask_var.g)+(_ColorARGBGlossA.rgb*_TintMask_var.b)),_ColorDRGBGlossA.rgb,node_126);
                float3 w = (_HeightOccTrans_var.b*node_143*_TransPower*(1.0 - node_198))*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight*(0.5-max(w.r,max(w.g,w.b))*0.5) * attenColor;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = lerp( _MainTex_var.rgb, (node_143*_MainTex_var.rgb*node_234), _TintEnable );
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Bumped Specular"
    CustomEditor "ShaderForgeMaterialInspector"
}
