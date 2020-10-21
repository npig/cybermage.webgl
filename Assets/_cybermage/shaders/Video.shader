// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:1,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:8600,x:33080,y:32977,varname:node_8600,prsc:2|emission-1117-RGB;n:type:ShaderForge.SFN_Tex2d,id:1117,x:32734,y:33077,varname:node_1117,prsc:2,tex:55a250364df220c438fc1e969b40eae5,ntxv:0,isnm:False|UVIN-931-OUT,TEX-2405-TEX;n:type:ShaderForge.SFN_Time,id:4323,x:32057,y:32944,varname:node_4323,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8559,x:32279,y:32985,varname:node_8559,prsc:2|A-4323-TSL,B-5462-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2405,x:32734,y:33232,ptovrint:False,ptlb:node_2405,ptin:_node_2405,varname:node_2405,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:55a250364df220c438fc1e969b40eae5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:2891,x:32057,y:33179,varname:node_2891,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:3976,x:32057,y:33352,varname:node_3976,prsc:2,v1:4;n:type:ShaderForge.SFN_Append,id:931,x:32464,y:33199,varname:node_931,prsc:2|A-102-OUT,B-2891-V;n:type:ShaderForge.SFN_ValueProperty,id:5462,x:32057,y:33106,ptovrint:False,ptlb:node_5462,ptin:_node_5462,varname:node_5462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Divide,id:7752,x:32279,y:33106,varname:node_7752,prsc:2|A-2891-U,B-3976-OUT;n:type:ShaderForge.SFN_Add,id:102,x:32464,y:32985,varname:node_102,prsc:2|A-8559-OUT,B-7752-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9651,x:32205,y:32804,ptovrint:False,ptlb:node_9651,ptin:_node_9651,varname:node_9651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:100;n:type:ShaderForge.SFN_Code,id:1212,x:32464,y:32800,varname:node_1212,prsc:2,code:ZgBsAG8AYQB0AA==,output:0,fname:Function_node_1212,width:471,height:157,input:0,input_1_label:time|A-8559-OUT;proporder:2405-5462-9651;pass:END;sub:END;*/

Shader "Xargon/Video" {
    Properties {
        _node_2405 ("node_2405", 2D) = "white" {}
        _node_5462 ("node_5462", Float ) = 0.1
        _node_9651 ("node_9651", Float ) = 100
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_2405; uniform float4 _node_2405_ST;
            uniform float _node_5462;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_4323 = _Time + _TimeEditor;
                float node_8559 = (node_4323.r*_node_5462);
                float2 node_931 = float2((node_8559+(i.uv0.r/4.0)),i.uv0.g);
                float4 node_1117 = tex2D(_node_2405,TRANSFORM_TEX(node_931, _node_2405));
                float3 emissive = node_1117.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
