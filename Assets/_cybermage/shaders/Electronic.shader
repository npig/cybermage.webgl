// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33620,y:31976,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:33160,y:32219,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3e83c1d72a2aefa44979168f4e1c79eb,ntxv:0,isnm:False|UVIN-196-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:33387,y:32236,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-6300-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:33160,y:32390,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:33160,y:32548,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0.972414,c4:1;n:type:ShaderForge.SFN_Time,id:5327,x:31179,y:32470,varname:node_5327,prsc:2;n:type:ShaderForge.SFN_Append,id:8589,x:31179,y:32322,varname:node_8589,prsc:2|A-94-OUT,B-9548-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9548,x:30979,y:32422,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_9548,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:94,x:30979,y:32347,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_94,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:1815,x:31351,y:32460,varname:node_1815,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:5669,x:31351,y:32322,varname:node_5669,prsc:2|A-8589-OUT,B-5327-T;n:type:ShaderForge.SFN_Tex2d,id:3176,x:31746,y:32320,varname:node_3176,prsc:2,tex:3e83c1d72a2aefa44979168f4e1c79eb,ntxv:0,isnm:False|UVIN-6765-OUT,TEX-1754-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1754,x:31551,y:32472,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_1754,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3e83c1d72a2aefa44979168f4e1c79eb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6765,x:31551,y:32320,varname:node_6765,prsc:2|A-5669-OUT,B-1815-UVOUT;n:type:ShaderForge.SFN_Time,id:6811,x:31178,y:32856,varname:node_6811,prsc:2;n:type:ShaderForge.SFN_Append,id:9724,x:31178,y:32711,varname:node_9724,prsc:2|A-9233-OUT,B-9588-OUT;n:type:ShaderForge.SFN_TexCoord,id:4899,x:31351,y:32830,varname:node_4899,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7037,x:31351,y:32711,varname:node_7037,prsc:2|A-9724-OUT,B-6811-T;n:type:ShaderForge.SFN_ValueProperty,id:9588,x:30975,y:32803,ptovrint:False,ptlb:nV Speed,ptin:_nVSpeed,varname:node_9588,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:9233,x:30975,y:32731,ptovrint:False,ptlb:nU Speed,ptin:_nUSpeed,varname:node_9233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.1;n:type:ShaderForge.SFN_Add,id:9455,x:31551,y:32711,varname:node_9455,prsc:2|A-7037-OUT,B-4899-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3273,x:31755,y:32711,varname:node_3273,prsc:2,tex:3e83c1d72a2aefa44979168f4e1c79eb,ntxv:0,isnm:False|UVIN-9455-OUT,TEX-1754-TEX;n:type:ShaderForge.SFN_Slider,id:5053,x:31018,y:32083,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:node_5053,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1655558,max:1;n:type:ShaderForge.SFN_OneMinus,id:8588,x:31394,y:32070,varname:node_8588,prsc:2|IN-5053-OUT;n:type:ShaderForge.SFN_RemapRange,id:1479,x:31587,y:32070,varname:node_1479,prsc:2,frmn:0,frmx:1,tomn:-0.6,tomx:0.6|IN-8588-OUT;n:type:ShaderForge.SFN_Add,id:4813,x:31949,y:32072,varname:node_4813,prsc:2|A-1479-OUT,B-3176-R;n:type:ShaderForge.SFN_Multiply,id:3875,x:32147,y:32072,varname:node_3875,prsc:2|A-4813-OUT,B-5113-OUT;n:type:ShaderForge.SFN_Add,id:5113,x:31949,y:32244,varname:node_5113,prsc:2|A-1479-OUT,B-3273-R;n:type:ShaderForge.SFN_RemapRange,id:9913,x:32341,y:32072,varname:node_9913,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-3875-OUT;n:type:ShaderForge.SFN_Clamp01,id:7190,x:32539,y:32072,varname:node_7190,prsc:2|IN-9913-OUT;n:type:ShaderForge.SFN_OneMinus,id:1157,x:32758,y:32072,varname:node_1157,prsc:2|IN-7190-OUT;n:type:ShaderForge.SFN_Append,id:196,x:32971,y:32072,varname:node_196,prsc:2|A-1157-OUT,B-2543-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2543,x:32758,y:32276,ptovrint:False,ptlb:AppendValue,ptin:_AppendValue,varname:node_2543,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6300,x:33160,y:32742,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6300,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:8105,x:33344,y:32092,varname:node_8105,prsc:2|A-8114-OUT,B-6074-R;n:type:ShaderForge.SFN_ValueProperty,id:8114,x:33160,y:32106,ptovrint:False,ptlb:Strench,ptin:_Strench,varname:node_8114,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;proporder:6074-797-9548-94-1754-5053-9588-9233-2543-6300-8114;pass:END;sub:END;*/

Shader "Xargon/Electronic" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (1,0,0.972414,1)
        _VSpeed ("V Speed", Float ) = 0.1
        _USpeed ("U Speed", Float ) = 0.1
        _Noise ("Noise", 2D) = "white" {}
        _Dissolve ("Dissolve", Range(0, 1)) = 0.1655558
        _nVSpeed ("nV Speed", Float ) = 0.1
        _nUSpeed ("nU Speed", Float ) = -0.1
        _AppendValue ("AppendValue", Float ) = 0
        _Opacity ("Opacity", Float ) = 2
        _Strench ("Strench", Float ) = 3
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
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
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _VSpeed;
            uniform float _USpeed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _nVSpeed;
            uniform float _nUSpeed;
            uniform float _Dissolve;
            uniform float _AppendValue;
            uniform float _Opacity;
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
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_1479 = ((1.0 - _Dissolve)*1.2+-0.6);
                float4 node_5327 = _Time + _TimeEditor;
                float2 node_6765 = ((float2(_USpeed,_VSpeed)*node_5327.g)+i.uv0);
                float4 node_3176 = tex2D(_Noise,TRANSFORM_TEX(node_6765, _Noise));
                float4 node_6811 = _Time + _TimeEditor;
                float2 node_9455 = ((float2(_nUSpeed,_nVSpeed)*node_6811.g)+i.uv0);
                float4 node_3273 = tex2D(_Noise,TRANSFORM_TEX(node_9455, _Noise));
                float2 node_196 = float2((1.0 - saturate((((node_1479+node_3176.r)*(node_1479+node_3273.r))*20.0+-10.0))),_AppendValue);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_196, _MainTex));
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*_Opacity);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
