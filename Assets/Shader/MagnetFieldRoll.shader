Shader "Hidden/MagnetFieldRoll"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("磁场颜色", Color) = (1, 1, 1, 1)
//        _Color ("Tint", Color) = (0, 0, 0, 1)
//        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _Color;
            // float4 _RendererColor;

            fixed4 frag (v2f i) : SV_Target
            {
                // in fragment shader
                float2 newUV = i.uv;
                newUV.y = frac(newUV.y - _Time.y);
                fixed4 col = tex2D(_MainTex, newUV);
                // col *= _RendererColor;
                // col *= _Color;
                // col *= float4(1,0,0,1);
                return col;
            }
            ENDCG
        }
    }
}
