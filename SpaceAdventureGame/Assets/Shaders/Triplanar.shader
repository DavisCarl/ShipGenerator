// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33991,y:32657,varname:node_4013,prsc:2|diff-90-OUT;n:type:ShaderForge.SFN_VertexColor,id:1460,x:31452,y:32611,varname:node_1460,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:8585,x:31452,y:32745,prsc:2,pt:False;n:type:ShaderForge.SFN_Abs,id:5638,x:31633,y:32745,varname:node_5638,prsc:2|IN-8585-OUT;n:type:ShaderForge.SFN_Tex2d,id:5190,x:33628,y:32089,varname:_XTex,prsc:2,tex:800307f981d3ab2409dcf61111a86d0c,ntxv:0,isnm:False|UVIN-3169-UVOUT,TEX-2972-TEX;n:type:ShaderForge.SFN_ComponentMask,id:3345,x:31816,y:32745,varname:node_3345,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-5638-OUT;n:type:ShaderForge.SFN_Tex2d,id:7292,x:33628,y:32308,ptovrint:False,ptlb:FloorTex,ptin:_FloorTex,varname:_FloorTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d7cd5c6cbed40d840a22536fdebbc9fa,ntxv:0,isnm:False|UVIN-6036-UVOUT;n:type:ShaderForge.SFN_Append,id:6158,x:32569,y:33226,varname:node_6158,prsc:2|A-2324-OUT,B-9034-OUT;n:type:ShaderForge.SFN_UVTile,id:6036,x:33400,y:32308,varname:node_6036,prsc:2|UVIN-4274-OUT,WDT-6612-OUT,HGT-5984-OUT,TILE-2961-OUT;n:type:ShaderForge.SFN_Vector1,id:6612,x:31451,y:32270,varname:node_6612,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:5499,x:32003,y:31980,varname:node_5499,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:5984,x:31630,y:32490,ptovrint:False,ptlb:Height,ptin:_Height,varname:_Height,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_UVTile,id:3169,x:33400,y:32089,varname:node_3169,prsc:2|UVIN-6158-OUT,WDT-6612-OUT,HGT-5984-OUT,TILE-2961-OUT;n:type:ShaderForge.SFN_Lerp,id:90,x:33477,y:32651,varname:node_90,prsc:2|A-2660-OUT,B-7292-RGB,T-3345-G;n:type:ShaderForge.SFN_ValueProperty,id:7532,x:32121,y:32665,ptovrint:False,ptlb:node_7532,ptin:_node_7532,varname:_node_7532,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_FragmentPosition,id:499,x:31534,y:33213,varname:node_499,prsc:2;n:type:ShaderForge.SFN_Frac,id:9034,x:31783,y:33322,varname:node_9034,prsc:2|IN-499-Y;n:type:ShaderForge.SFN_Frac,id:2324,x:31783,y:33213,varname:node_2324,prsc:2|IN-499-X;n:type:ShaderForge.SFN_Frac,id:9515,x:31783,y:33437,varname:node_9515,prsc:2|IN-499-Z;n:type:ShaderForge.SFN_Add,id:2135,x:32399,y:33386,varname:node_2135,prsc:2|A-2324-OUT,B-9515-OUT;n:type:ShaderForge.SFN_Append,id:4274,x:32569,y:33386,varname:node_4274,prsc:2|A-2324-OUT,B-9515-OUT;n:type:ShaderForge.SFN_Vector1,id:7070,x:31733,y:32326,varname:node_7070,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8483,x:32003,y:32143,varname:node_8483,prsc:2,v1:2;n:type:ShaderForge.SFN_If,id:9119,x:32235,y:31980,varname:node_9119,prsc:2|A-1460-G,B-5499-OUT,GT-7070-OUT,EQ-5499-OUT,LT-5499-OUT;n:type:ShaderForge.SFN_If,id:7797,x:32235,y:32143,varname:node_7797,prsc:2|A-1460-B,B-5499-OUT,GT-8483-OUT,EQ-5499-OUT,LT-5499-OUT;n:type:ShaderForge.SFN_Add,id:3610,x:32437,y:31980,varname:node_3610,prsc:2|A-9119-OUT,B-7797-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:7897,x:32606,y:31980,varname:node_7897,prsc:2,min:0,max:2|IN-3610-OUT;n:type:ShaderForge.SFN_Vector1,id:3654,x:31816,y:32659,varname:node_3654,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:1471,x:31992,y:32491,varname:node_1471,prsc:2|A-1460-A,B-3654-OUT;n:type:ShaderForge.SFN_Multiply,id:2937,x:32532,y:32302,varname:node_2937,prsc:2|A-1489-OUT,B-6612-OUT;n:type:ShaderForge.SFN_Subtract,id:3614,x:32003,y:32302,varname:node_3614,prsc:2|A-5984-OUT,B-7070-OUT;n:type:ShaderForge.SFN_Vector1,id:2742,x:31461,y:32036,varname:node_2742,prsc:2,v1:255;n:type:ShaderForge.SFN_Round,id:1489,x:32363,y:32302,varname:node_1489,prsc:2|IN-8307-OUT;n:type:ShaderForge.SFN_Multiply,id:8307,x:32197,y:32302,varname:node_8307,prsc:2|A-3614-OUT,B-1471-OUT;n:type:ShaderForge.SFN_Add,id:2961,x:32669,y:32183,varname:node_2961,prsc:2|A-7897-OUT,B-2937-OUT;n:type:ShaderForge.SFN_Append,id:9409,x:32557,y:33567,varname:node_9409,prsc:2|A-9515-OUT,B-9034-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2972,x:33150,y:31756,ptovrint:False,ptlb:WallTex,ptin:_WallTex,varname:_WallTex,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:800307f981d3ab2409dcf61111a86d0c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6961,x:33628,y:31855,varname:_ZTex,prsc:2,tex:800307f981d3ab2409dcf61111a86d0c,ntxv:0,isnm:False|UVIN-50-UVOUT,TEX-2972-TEX;n:type:ShaderForge.SFN_Add,id:2660,x:33832,y:31995,varname:node_2660,prsc:2|A-6961-RGB,B-5190-RGB;n:type:ShaderForge.SFN_UVTile,id:50,x:33400,y:31917,varname:node_50,prsc:2|UVIN-9409-OUT,WDT-6612-OUT,HGT-5984-OUT,TILE-2961-OUT;n:type:ShaderForge.SFN_Slider,id:6026,x:31359,y:32382,ptovrint:False,ptlb:node_6026,ptin:_node_6026,varname:_node_6026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:255,max:255;proporder:5984-7532-7292-2972-6026;pass:END;sub:END;*/

Shader "Shader Forge/Triplanar2" {
    Properties {
        _Height ("Height", Float ) = 2
        _node_7532 ("node_7532", Float ) = 0
        _FloorTex ("FloorTex", 2D) = "white" {}
        _WallTex ("WallTex", 2D) = "white" {}
        _node_6026 ("node_6026", Range(0, 255)) = 255
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _FloorTex; uniform float4 _FloorTex_ST;
            uniform float _Height;
            uniform sampler2D _WallTex; uniform float4 _WallTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_6612 = 3.0;
                float node_5499 = 0.0;
                float node_9119_if_leA = step(i.vertexColor.g,node_5499);
                float node_9119_if_leB = step(node_5499,i.vertexColor.g);
                float node_7070 = 1.0;
                float node_7797_if_leA = step(i.vertexColor.b,node_5499);
                float node_7797_if_leB = step(node_5499,i.vertexColor.b);
                float node_2961 = (clamp((lerp((node_9119_if_leA*node_5499)+(node_9119_if_leB*node_7070),node_5499,node_9119_if_leA*node_9119_if_leB)+lerp((node_7797_if_leA*node_5499)+(node_7797_if_leB*2.0),node_5499,node_7797_if_leA*node_7797_if_leB)),0,2)+(round(((_Height-node_7070)*(i.vertexColor.a/1.0)))*node_6612));
                float2 node_50_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_50_ty = floor(node_2961 * node_50_tc_rcp.x);
                float node_50_tx = node_2961 - node_6612 * node_50_ty;
                float node_9515 = frac(i.posWorld.b);
                float node_9034 = frac(i.posWorld.g);
                float2 node_50 = (float2(node_9515,node_9034) + float2(node_50_tx, node_50_ty)) * node_50_tc_rcp;
                float4 _ZTex = tex2D(_WallTex,TRANSFORM_TEX(node_50, _WallTex));
                float2 node_3169_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_3169_ty = floor(node_2961 * node_3169_tc_rcp.x);
                float node_3169_tx = node_2961 - node_6612 * node_3169_ty;
                float node_2324 = frac(i.posWorld.r);
                float2 node_3169 = (float2(node_2324,node_9034) + float2(node_3169_tx, node_3169_ty)) * node_3169_tc_rcp;
                float4 _XTex = tex2D(_WallTex,TRANSFORM_TEX(node_3169, _WallTex));
                float2 node_6036_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_6036_ty = floor(node_2961 * node_6036_tc_rcp.x);
                float node_6036_tx = node_2961 - node_6612 * node_6036_ty;
                float2 node_6036 = (float2(node_2324,node_9515) + float2(node_6036_tx, node_6036_ty)) * node_6036_tc_rcp;
                float4 _FloorTex_var = tex2D(_FloorTex,TRANSFORM_TEX(node_6036, _FloorTex));
                float3 diffuseColor = lerp((_ZTex.rgb+_XTex.rgb),_FloorTex_var.rgb,abs(i.normalDir).rgb.g);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _FloorTex; uniform float4 _FloorTex_ST;
            uniform float _Height;
            uniform sampler2D _WallTex; uniform float4 _WallTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_6612 = 3.0;
                float node_5499 = 0.0;
                float node_9119_if_leA = step(i.vertexColor.g,node_5499);
                float node_9119_if_leB = step(node_5499,i.vertexColor.g);
                float node_7070 = 1.0;
                float node_7797_if_leA = step(i.vertexColor.b,node_5499);
                float node_7797_if_leB = step(node_5499,i.vertexColor.b);
                float node_2961 = (clamp((lerp((node_9119_if_leA*node_5499)+(node_9119_if_leB*node_7070),node_5499,node_9119_if_leA*node_9119_if_leB)+lerp((node_7797_if_leA*node_5499)+(node_7797_if_leB*2.0),node_5499,node_7797_if_leA*node_7797_if_leB)),0,2)+(round(((_Height-node_7070)*(i.vertexColor.a/1.0)))*node_6612));
                float2 node_50_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_50_ty = floor(node_2961 * node_50_tc_rcp.x);
                float node_50_tx = node_2961 - node_6612 * node_50_ty;
                float node_9515 = frac(i.posWorld.b);
                float node_9034 = frac(i.posWorld.g);
                float2 node_50 = (float2(node_9515,node_9034) + float2(node_50_tx, node_50_ty)) * node_50_tc_rcp;
                float4 _ZTex = tex2D(_WallTex,TRANSFORM_TEX(node_50, _WallTex));
                float2 node_3169_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_3169_ty = floor(node_2961 * node_3169_tc_rcp.x);
                float node_3169_tx = node_2961 - node_6612 * node_3169_ty;
                float node_2324 = frac(i.posWorld.r);
                float2 node_3169 = (float2(node_2324,node_9034) + float2(node_3169_tx, node_3169_ty)) * node_3169_tc_rcp;
                float4 _XTex = tex2D(_WallTex,TRANSFORM_TEX(node_3169, _WallTex));
                float2 node_6036_tc_rcp = float2(1.0,1.0)/float2( node_6612, _Height );
                float node_6036_ty = floor(node_2961 * node_6036_tc_rcp.x);
                float node_6036_tx = node_2961 - node_6612 * node_6036_ty;
                float2 node_6036 = (float2(node_2324,node_9515) + float2(node_6036_tx, node_6036_ty)) * node_6036_tc_rcp;
                float4 _FloorTex_var = tex2D(_FloorTex,TRANSFORM_TEX(node_6036, _FloorTex));
                float3 diffuseColor = lerp((_ZTex.rgb+_XTex.rgb),_FloorTex_var.rgb,abs(i.normalDir).rgb.g);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
