// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:1,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4641,x:33252,y:32531,varname:node_4641,prsc:2|emission-1547-OUT,voffset-7901-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4052,x:30819,y:32891,ptovrint:False,ptlb:Mix,ptin:_Mix,varname:node_4052,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9bc292283f1e9934fb7a2125f3e3441e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5988,x:31812,y:33252,varname:node_5988,prsc:2,tex:9bc292283f1e9934fb7a2125f3e3441e,ntxv:0,isnm:False|UVIN-4183-OUT,TEX-4052-TEX;n:type:ShaderForge.SFN_Multiply,id:6977,x:32328,y:32908,varname:node_6977,prsc:2|A-5988-R,B-9213-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9213,x:32328,y:33081,ptovrint:False,ptlb:MorphAmount,ptin:_MorphAmount,varname:node_9213,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:7901,x:32552,y:32893,varname:node_7901,prsc:2|A-2177-OUT,B-4014-OUT,C-6977-OUT;n:type:ShaderForge.SFN_Vector1,id:2177,x:32328,y:32776,varname:node_2177,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4014,x:32328,y:32838,varname:node_4014,prsc:2,v1:0;n:type:ShaderForge.SFN_TexCoord,id:3563,x:30831,y:32587,varname:node_3563,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:1066,x:30949,y:33287,ptovrint:False,ptlb:MorphVSpeed,ptin:_MorphVSpeed,varname:node_1066,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8221,x:30949,y:33194,ptovrint:False,ptlb:MorphUSpeed,ptin:_MorphUSpeed,varname:node_8221,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:8942,x:31207,y:33252,varname:node_8942,prsc:2|A-8221-OUT,B-1066-OUT;n:type:ShaderForge.SFN_Time,id:6974,x:30831,y:32736,varname:node_6974,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4085,x:31405,y:33252,varname:node_4085,prsc:2|A-8942-OUT,B-6974-T;n:type:ShaderForge.SFN_Add,id:4183,x:31627,y:33252,varname:node_4183,prsc:2|A-4085-OUT,B-3563-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7556,x:31835,y:32706,varname:node_7556,prsc:2,tex:9bc292283f1e9934fb7a2125f3e3441e,ntxv:0,isnm:False|TEX-4052-TEX;n:type:ShaderForge.SFN_ValueProperty,id:8128,x:30939,y:32333,ptovrint:False,ptlb:1stLayerVSpeed,ptin:_1stLayerVSpeed,varname:_VSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:246,x:30939,y:32251,ptovrint:False,ptlb:1stLayerUSpeed,ptin:_1stLayerUSpeed,varname:_USpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_Append,id:3373,x:31161,y:32251,varname:node_3373,prsc:2|A-246-OUT,B-8128-OUT;n:type:ShaderForge.SFN_Multiply,id:1217,x:31369,y:32336,varname:node_1217,prsc:2|A-3373-OUT,B-6974-T;n:type:ShaderForge.SFN_Add,id:4626,x:31591,y:32336,varname:node_4626,prsc:2|A-1217-OUT,B-3563-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7378,x:31835,y:32578,varname:node_7378,prsc:2,tex:9bc292283f1e9934fb7a2125f3e3441e,ntxv:0,isnm:False|UVIN-4626-OUT,TEX-4052-TEX;n:type:ShaderForge.SFN_Add,id:3951,x:32094,y:32472,varname:node_3951,prsc:2|A-7164-OUT,B-7378-B;n:type:ShaderForge.SFN_Multiply,id:2750,x:32700,y:32641,varname:node_2750,prsc:2|A-9196-OUT,B-7556-G,C-2285-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7164,x:32094,y:32414,ptovrint:False,ptlb:1stLayerPower,ptin:_1stLayerPower,varname:node_7164,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:2285,x:32700,y:32789,ptovrint:False,ptlb:1stLayerBoost,ptin:_1stLayerBoost,varname:node_2285,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:5862,x:30939,y:32105,ptovrint:False,ptlb:2ndLayerVSpeed,ptin:_2ndLayerVSpeed,varname:_TVSpeedB_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:9778,x:30939,y:32023,ptovrint:False,ptlb:2ndLayerUSpeed,ptin:_2ndLayerUSpeed,varname:_TUSpeedB_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_Append,id:8110,x:31161,y:32023,varname:node_8110,prsc:2|A-9778-OUT,B-5862-OUT;n:type:ShaderForge.SFN_Multiply,id:8977,x:31369,y:32108,varname:node_8977,prsc:2|A-8110-OUT,B-6974-T;n:type:ShaderForge.SFN_Add,id:4137,x:31591,y:32108,varname:node_4137,prsc:2|A-8977-OUT,B-3563-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3424,x:31834,y:32108,varname:node_3424,prsc:2,tex:2f1a0b4f0b3654843ab90428f2d15a80,ntxv:0,isnm:False|UVIN-7171-OUT,TEX-3668-TEX;n:type:ShaderForge.SFN_Multiply,id:1527,x:32094,y:32261,varname:node_1527,prsc:2|A-2137-OUT,B-3424-R;n:type:ShaderForge.SFN_ValueProperty,id:2137,x:32094,y:32177,ptovrint:False,ptlb:2ndLayerOverlay,ptin:_2ndLayerOverlay,varname:node_2137,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2dAsset,id:3668,x:31591,y:31939,ptovrint:False,ptlb:Overlay,ptin:_Overlay,varname:node_3668,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2f1a0b4f0b3654843ab90428f2d15a80,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:9196,x:32328,y:32458,varname:node_9196,prsc:2|A-1527-OUT,B-3951-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2154,x:31591,y:31768,ptovrint:False,ptlb:TileAU,ptin:_TileAU,varname:node_2154,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:7794,x:31591,y:31850,ptovrint:False,ptlb:TileAV,ptin:_TileAV,varname:node_7794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:8957,x:31834,y:31787,varname:node_8957,prsc:2|A-2154-OUT,B-7794-OUT;n:type:ShaderForge.SFN_Multiply,id:7171,x:31834,y:31956,varname:node_7171,prsc:2|A-8957-OUT,B-4137-OUT;n:type:ShaderForge.SFN_Lerp,id:1538,x:32836,y:32310,varname:node_1538,prsc:2|A-9848-RGB,B-9566-RGB,T-4327-OUT;n:type:ShaderForge.SFN_Slider,id:3944,x:32300,y:32221,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3944,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_Multiply,id:4327,x:32635,y:32310,varname:node_4327,prsc:2|A-3944-OUT,B-2750-OUT;n:type:ShaderForge.SFN_Color,id:9848,x:32625,y:31970,ptovrint:False,ptlb:node_9848,ptin:_node_9848,varname:node_9848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05882353,c2:0.2989861,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:9566,x:32611,y:32143,ptovrint:False,ptlb:node_9566,ptin:_node_9566,varname:node_9566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5577077,c2:0.3455882,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:1547,x:33026,y:32598,varname:node_1547,prsc:2|A-1538-OUT,B-2750-OUT,C-4702-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4702,x:32974,y:32804,ptovrint:False,ptlb:node_4702,ptin:_node_4702,varname:node_4702,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;proporder:4052-3668-9213-1066-8221-246-8128-9778-5862-7164-2285-2137-2154-7794-3944-9848-9566-4702;pass:END;sub:END;*/

Shader "Xargon/DataShaft" {
    Properties {
        _Mix ("Mix", 2D) = "white" {}
        _Overlay ("Overlay", 2D) = "white" {}
        _MorphAmount ("MorphAmount", Float ) = 1
        _MorphVSpeed ("MorphVSpeed", Float ) = 0
        _MorphUSpeed ("MorphUSpeed", Float ) = 0.1
        _1stLayerUSpeed ("1stLayerUSpeed", Float ) = 0.3
        _1stLayerVSpeed ("1stLayerVSpeed", Float ) = 0
        _2ndLayerUSpeed ("2ndLayerUSpeed", Float ) = 0.3
        _2ndLayerVSpeed ("2ndLayerVSpeed", Float ) = 0
        _1stLayerPower ("1stLayerPower", Float ) = 0.1
        _1stLayerBoost ("1stLayerBoost", Float ) = 2
        _2ndLayerOverlay ("2ndLayerOverlay", Float ) = 1
        _TileAU ("TileAU", Float ) = 2
        _TileAV ("TileAV", Float ) = 1
        _Color ("Color", Range(0, 2)) = 1
        _node_9848 ("node_9848", Color) = (0.05882353,0.2989861,1,1)
        _node_9566 ("node_9566", Color) = (0.5577077,0.3455882,1,1)
        _node_4702 ("node_4702", Float ) = 4
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
            uniform sampler2D _Mix; uniform float4 _Mix_ST;
            uniform float _MorphAmount;
            uniform float _MorphVSpeed;
            uniform float _MorphUSpeed;
            uniform float _1stLayerVSpeed;
            uniform float _1stLayerUSpeed;
            uniform float _1stLayerPower;
            uniform float _1stLayerBoost;
            uniform float _2ndLayerVSpeed;
            uniform float _2ndLayerUSpeed;
            uniform float _2ndLayerOverlay;
            uniform sampler2D _Overlay; uniform float4 _Overlay_ST;
            uniform float _TileAU;
            uniform float _TileAV;
            uniform float _Color;
            uniform float4 _node_9848;
            uniform float4 _node_9566;
            uniform float _node_4702;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_6974 = _Time + _TimeEditor;
                float2 node_4183 = ((float2(_MorphUSpeed,_MorphVSpeed)*node_6974.g)+o.uv0);
                float4 node_5988 = tex2Dlod(_Mix,float4(TRANSFORM_TEX(node_4183, _Mix),0.0,0));
                v.vertex.xyz += float3(0.0,0.0,(node_5988.r*_MorphAmount));
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_6974 = _Time + _TimeEditor;
                float2 node_7171 = (float2(_TileAU,_TileAV)*((float2(_2ndLayerUSpeed,_2ndLayerVSpeed)*node_6974.g)+i.uv0));
                float4 node_3424 = tex2D(_Overlay,TRANSFORM_TEX(node_7171, _Overlay));
                float2 node_4626 = ((float2(_1stLayerUSpeed,_1stLayerVSpeed)*node_6974.g)+i.uv0);
                float4 node_7378 = tex2D(_Mix,TRANSFORM_TEX(node_4626, _Mix));
                float4 node_7556 = tex2D(_Mix,TRANSFORM_TEX(i.uv0, _Mix));
                float node_2750 = (((_2ndLayerOverlay*node_3424.r)+(_1stLayerPower+node_7378.b))*node_7556.g*_1stLayerBoost);
                float3 emissive = (lerp(_node_9848.rgb,_node_9566.rgb,(_Color*node_2750))*node_2750*_node_4702);
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Mix; uniform float4 _Mix_ST;
            uniform float _MorphAmount;
            uniform float _MorphVSpeed;
            uniform float _MorphUSpeed;
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
                float4 node_6974 = _Time + _TimeEditor;
                float2 node_4183 = ((float2(_MorphUSpeed,_MorphVSpeed)*node_6974.g)+o.uv0);
                float4 node_5988 = tex2Dlod(_Mix,float4(TRANSFORM_TEX(node_4183, _Mix),0.0,0));
                v.vertex.xyz += float3(0.0,0.0,(node_5988.r*_MorphAmount));
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
