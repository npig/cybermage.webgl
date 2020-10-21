// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:True,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:1,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5643,x:32783,y:32691,varname:node_5643,prsc:2|diffpow-683-RGB,emission-5844-OUT,clip-8101-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2598,x:31849,y:32818,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_2598,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ba2f22fd10e49884095f9f240096206c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:683,x:32301,y:32728,varname:node_683,prsc:2,tex:ba2f22fd10e49884095f9f240096206c,ntxv:0,isnm:False|UVIN-1023-UVOUT,TEX-2598-TEX;n:type:ShaderForge.SFN_TexCoord,id:1023,x:31838,y:32646,varname:node_1023,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:2652,x:32133,y:33334,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_2652,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6925212dd0dbeaf48b9b4c3b76c9d80d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5703,x:32395,y:33234,varname:node_5703,prsc:2,tex:6925212dd0dbeaf48b9b4c3b76c9d80d,ntxv:0,isnm:False|UVIN-7257-UVOUT,TEX-2652-TEX;n:type:ShaderForge.SFN_TexCoord,id:7257,x:32133,y:33170,varname:node_7257,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8101,x:32559,y:33054,varname:node_8101,prsc:2|A-3556-OUT,B-5703-A;n:type:ShaderForge.SFN_Multiply,id:5844,x:32554,y:32791,varname:node_5844,prsc:2|A-683-RGB,B-8189-OUT;n:type:ShaderForge.SFN_Slider,id:8189,x:32168,y:32903,ptovrint:False,ptlb:power,ptin:_power,varname:node_8189,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.282051,max:2;n:type:ShaderForge.SFN_Slider,id:3556,x:32168,y:33034,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_3556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.5,cur:1.205128,max:1.5;proporder:2598-2652-8189-3556;pass:END;sub:END;*/

Shader "Xargon/LightShafting" {
    Properties {
        _Emission ("Emission", 2D) = "white" {}
        _Opacity ("Opacity", 2D) = "white" {}
        _power ("power", Range(0, 2)) = 1.282051
        _opacity ("opacity", Range(0.5, 1.5)) = 1.205128
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            
            
            AlphaToMask On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform float _power;
            uniform float _opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 node_5703 = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip((_opacity*node_5703.a) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_683 = tex2D(_Emission,TRANSFORM_TEX(i.uv0, _Emission));
                float3 emissive = (node_683.rgb*_power);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,((_opacity*node_5703.a)) * 2.0 - 1.0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform float _opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_5703 = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip((_opacity*node_5703.a) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
