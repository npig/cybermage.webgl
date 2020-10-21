// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33552,y:31867,varname:node_4795,prsc:2|emission-2393-OUT,clip-7190-OUT,refract-361-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:33220,y:32143,varname:node_2393,prsc:2|A-7190-OUT,B-2053-RGB,C-797-RGB;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32982,y:32108,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32982,y:32266,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0.972414,c4:0.5;n:type:ShaderForge.SFN_Time,id:5327,x:31627,y:32375,varname:node_5327,prsc:2;n:type:ShaderForge.SFN_Append,id:8589,x:31627,y:32227,varname:node_8589,prsc:2|A-94-OUT,B-9548-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9548,x:31427,y:32327,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_9548,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:94,x:31427,y:32252,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_94,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:1815,x:31799,y:32365,varname:node_1815,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:5669,x:31799,y:32227,varname:node_5669,prsc:2|A-8589-OUT,B-5327-T;n:type:ShaderForge.SFN_Tex2d,id:3176,x:32194,y:32225,varname:node_3176,prsc:2,tex:f5ddbfd1a96dd7e47b02583747db860f,ntxv:0,isnm:False|UVIN-6765-OUT,TEX-1754-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1754,x:31999,y:32377,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_1754,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f5ddbfd1a96dd7e47b02583747db860f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6765,x:31999,y:32225,varname:node_6765,prsc:2|A-5669-OUT,B-1815-UVOUT;n:type:ShaderForge.SFN_Time,id:6811,x:31626,y:32761,varname:node_6811,prsc:2;n:type:ShaderForge.SFN_Append,id:9724,x:31626,y:32616,varname:node_9724,prsc:2|A-9233-OUT,B-9588-OUT;n:type:ShaderForge.SFN_TexCoord,id:4899,x:31799,y:32735,varname:node_4899,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7037,x:31799,y:32616,varname:node_7037,prsc:2|A-9724-OUT,B-6811-T;n:type:ShaderForge.SFN_ValueProperty,id:9588,x:31423,y:32708,ptovrint:False,ptlb:nV Speed,ptin:_nVSpeed,varname:node_9588,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:9233,x:31423,y:32636,ptovrint:False,ptlb:nU Speed,ptin:_nUSpeed,varname:node_9233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.1;n:type:ShaderForge.SFN_Add,id:9455,x:31999,y:32616,varname:node_9455,prsc:2|A-7037-OUT,B-4899-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3273,x:32203,y:32616,varname:node_3273,prsc:2,tex:1e5a7186d6f4ecc479f8b7fe755afaa4,ntxv:0,isnm:False|UVIN-9455-OUT,TEX-3721-TEX;n:type:ShaderForge.SFN_Slider,id:5053,x:31466,y:31988,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:node_5053,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2433513,max:1;n:type:ShaderForge.SFN_OneMinus,id:8588,x:31842,y:31975,varname:node_8588,prsc:2|IN-5053-OUT;n:type:ShaderForge.SFN_RemapRange,id:1479,x:32035,y:31975,varname:node_1479,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.6|IN-8588-OUT;n:type:ShaderForge.SFN_Add,id:4813,x:32397,y:31977,varname:node_4813,prsc:2|A-1479-OUT,B-3176-R;n:type:ShaderForge.SFN_Multiply,id:3875,x:32595,y:31977,varname:node_3875,prsc:2|A-4813-OUT,B-5113-OUT;n:type:ShaderForge.SFN_Add,id:5113,x:32397,y:32149,varname:node_5113,prsc:2|A-1479-OUT,B-3273-R;n:type:ShaderForge.SFN_RemapRange,id:9913,x:32789,y:31977,varname:node_9913,prsc:2,frmn:0,frmx:1,tomn:-3,tomx:3|IN-3875-OUT;n:type:ShaderForge.SFN_Clamp01,id:7190,x:32982,y:31977,varname:node_7190,prsc:2|IN-9913-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6300,x:32982,y:32441,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6300,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Tex2dAsset,id:3721,x:31999,y:32796,ptovrint:False,ptlb:NegNoise,ptin:_NegNoise,varname:node_3721,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1e5a7186d6f4ecc479f8b7fe755afaa4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:1272,x:32902,y:32562,varname:node_1272,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-6677-OUT;n:type:ShaderForge.SFN_Multiply,id:361,x:33171,y:32701,varname:node_361,prsc:2|A-1272-OUT,B-1786-OUT;n:type:ShaderForge.SFN_Slider,id:1786,x:32792,y:32775,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_1786,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Multiply,id:6677,x:32614,y:32561,varname:node_6677,prsc:2|A-3176-RGB,B-3273-RGB;proporder:797-1754-3721-5053-9548-94-9588-9233-6300-1786;pass:END;sub:END;*/

Shader "Xargon/MeshOverlay" {
    Properties {
        _TintColor ("Color", Color) = (1,0,0.972414,0.5)
        _Noise ("Noise", 2D) = "white" {}
        _NegNoise ("NegNoise", 2D) = "white" {}
        _Dissolve ("Dissolve", Range(0, 1)) = 0.2433513
        _VSpeed ("V Speed", Float ) = 0.1
        _USpeed ("U Speed", Float ) = 0.1
        _nVSpeed ("nV Speed", Float ) = 0.1
        _nUSpeed ("nU Speed", Float ) = -0.1
        _Opacity ("Opacity", Float ) = 2
        _Refraction ("Refraction", Range(0, 2)) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform float _VSpeed;
            uniform float _USpeed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _nVSpeed;
            uniform float _nUSpeed;
            uniform float _Dissolve;
            uniform sampler2D _NegNoise; uniform float4 _NegNoise_ST;
            uniform float _Refraction;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 node_5327 = _Time + _TimeEditor;
                float2 node_6765 = ((float2(_USpeed,_VSpeed)*node_5327.g)+i.uv0);
                float4 node_3176 = tex2D(_Noise,TRANSFORM_TEX(node_6765, _Noise));
                float4 node_6811 = _Time + _TimeEditor;
                float2 node_9455 = ((float2(_nUSpeed,_nVSpeed)*node_6811.g)+i.uv0);
                float4 node_3273 = tex2D(_NegNoise,TRANSFORM_TEX(node_9455, _NegNoise));
                float node_361 = ((node_3176.rgb*node_3273.rgb).b*_Refraction);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + float2(node_361,node_361);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float node_1479 = ((1.0 - _Dissolve)*1.2+-0.6);
                float node_7190 = saturate((((node_1479+node_3176.r)*(node_1479+node_3273.r))*6.0+-3.0));
                clip(node_7190 - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (node_7190*i.vertexColor.rgb*_TintColor.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,1),1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
