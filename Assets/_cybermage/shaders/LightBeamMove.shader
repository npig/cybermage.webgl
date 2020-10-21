// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:1,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:6012,x:33199,y:32879,varname:node_6012,prsc:2|emission-4182-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:61,x:32001,y:32795,ptovrint:False,ptlb:1,ptin:_1,varname:node_61,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:06a1104e2ce98934b9aa5721d9064794,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:1946,x:32001,y:33145,ptovrint:False,ptlb:2,ptin:_2,varname:node_1946,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f6c5e098785ef7f458fe66fc29c2bffc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3371,x:32214,y:32681,varname:node_3371,prsc:2,tex:06a1104e2ce98934b9aa5721d9064794,ntxv:0,isnm:False|UVIN-6880-OUT,TEX-61-TEX;n:type:ShaderForge.SFN_Tex2d,id:3209,x:32221,y:33066,varname:node_3209,prsc:2,tex:f6c5e098785ef7f458fe66fc29c2bffc,ntxv:0,isnm:False|UVIN-2627-OUT,TEX-1946-TEX;n:type:ShaderForge.SFN_Multiply,id:7725,x:32445,y:33066,varname:node_7725,prsc:2|A-3209-R,B-3411-OUT;n:type:ShaderForge.SFN_Multiply,id:7230,x:32424,y:32681,varname:node_7230,prsc:2|A-3371-R,B-9989-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3411,x:32221,y:33212,ptovrint:False,ptlb:2Power,ptin:_2Power,varname:node_3411,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:9989,x:32214,y:32828,ptovrint:False,ptlb:1Power,ptin:_1Power,varname:node_9989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8422,x:32662,y:32867,varname:node_8422,prsc:2|A-7230-OUT,B-7725-OUT,C-8252-OUT;n:type:ShaderForge.SFN_VertexColor,id:336,x:32908,y:32994,varname:node_336,prsc:2;n:type:ShaderForge.SFN_Color,id:7198,x:32908,y:33137,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7198,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9705882,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:9863,x:32908,y:33300,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_9863,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4182,x:32908,y:32866,varname:node_4182,prsc:2|A-8422-OUT,B-336-RGB,C-7198-RGB,D-9863-OUT;n:type:ShaderForge.SFN_Time,id:4223,x:31576,y:32527,varname:node_4223,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5160,x:31542,y:32413,ptovrint:False,ptlb:1Speed,ptin:_1Speed,varname:node_94,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:9202,x:31748,y:32507,varname:node_9202,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8208,x:31748,y:32379,varname:node_8208,prsc:2|A-5160-OUT,B-4223-T;n:type:ShaderForge.SFN_Add,id:4083,x:31946,y:32379,varname:node_4083,prsc:2|A-8208-OUT,B-9202-U;n:type:ShaderForge.SFN_Append,id:6880,x:32023,y:32562,varname:node_6880,prsc:2|A-4083-OUT,B-9202-V;n:type:ShaderForge.SFN_Time,id:8444,x:31315,y:33041,varname:node_8444,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7433,x:31281,y:32927,ptovrint:False,ptlb:2Speed,ptin:_2Speed,varname:_USpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:3197,x:31487,y:33021,varname:node_3197,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3972,x:31487,y:32893,varname:node_3972,prsc:2|A-7433-OUT,B-8444-T;n:type:ShaderForge.SFN_Add,id:9521,x:31685,y:32893,varname:node_9521,prsc:2|A-3972-OUT,B-3197-V;n:type:ShaderForge.SFN_Append,id:2627,x:31762,y:33076,varname:node_2627,prsc:2|A-9521-OUT,B-3197-U;n:type:ShaderForge.SFN_Tex2dAsset,id:9154,x:32069,y:33582,ptovrint:False,ptlb:OverallFade,ptin:_OverallFade,varname:node_9154,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3451,x:32274,y:33519,varname:node_3451,prsc:2,ntxv:0,isnm:False|UVIN-5543-UVOUT,TEX-9154-TEX;n:type:ShaderForge.SFN_TexCoord,id:5543,x:32069,y:33405,varname:node_5543,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8252,x:32548,y:33429,varname:node_8252,prsc:2|A-3451-RGB,B-6825-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6825,x:32305,y:33769,ptovrint:False,ptlb:OverallFadePower,ptin:_OverallFadePower,varname:node_6825,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7198-61-1946-9863-3411-9989-5160-7433-9154-6825;pass:END;sub:END;*/

Shader "Xargon/LightBeamMoves" {
    Properties {
        _Color ("Color", Color) = (0.9705882,0,0,1)
        _1 ("1", 2D) = "white" {}
        _2 ("2", 2D) = "white" {}
        _Power ("Power", Float ) = 1
        _2Power ("2Power", Float ) = 1
        _1Power ("1Power", Float ) = 1
        _1Speed ("1Speed", Float ) = 0.1
        _2Speed ("2Speed", Float ) = 0.1
        _OverallFade ("OverallFade", 2D) = "white" {}
        _OverallFadePower ("OverallFadePower", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _1; uniform float4 _1_ST;
            uniform sampler2D _2; uniform float4 _2_ST;
            uniform float _2Power;
            uniform float _1Power;
            uniform float4 _Color;
            uniform float _Power;
            uniform float _1Speed;
            uniform float _2Speed;
            uniform sampler2D _OverallFade; uniform float4 _OverallFade_ST;
            uniform float _OverallFadePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_4223 = _Time + _TimeEditor;
                float2 node_6880 = float2(((_1Speed*node_4223.g)+i.uv0.r),i.uv0.g);
                float4 node_3371 = tex2D(_1,TRANSFORM_TEX(node_6880, _1));
                float4 node_8444 = _Time + _TimeEditor;
                float2 node_2627 = float2(((_2Speed*node_8444.g)+i.uv0.g),i.uv0.r);
                float4 node_3209 = tex2D(_2,TRANSFORM_TEX(node_2627, _2));
                float4 node_3451 = tex2D(_OverallFade,TRANSFORM_TEX(i.uv0, _OverallFade));
                float3 emissive = (((node_3371.r*_1Power)*(node_3209.r*_2Power)*(node_3451.rgb*_OverallFadePower))*i.vertexColor.rgb*_Color.rgb*_Power);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
