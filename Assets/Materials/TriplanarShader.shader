Shader "Unlit/TriplanarShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _OcclusionMap ("AO Map", 2D) = "white" {}
        _RoughnessMap ("Roughness Map", 2D) = "white" {}
        _MetalnessMap ("Metalness Map", 2D) = "white" {}
        _HeightMap ("Height Map", 2D) = "black" {}
        _Scale ("Texture Scale", Float) = 1
        _HeightScale ("Height Scale", Float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows addshadow

        #include "UnityCG.cginc"

        sampler2D _MainTex;
        sampler2D _NormalMap;
        sampler2D _OcclusionMap;
        sampler2D _RoughnessMap;
        sampler2D _MetalnessMap;
        sampler2D _HeightMap;

        float _Scale;
        float _HeightScale;

        struct Input
        {
            float3 worldPos;
            float3 worldNormal;
            INTERNAL_DATA
        };

        // Función de mapeo triplanar para texturas Albedo, Roughness, Metalness, etc.
        float4 SampleTriplanarTexture(sampler2D tex, float3 worldPos, float3 worldNormal)
        {
            float3 blending = abs(worldNormal);
            blending = normalize(blending);

            float4 xTex = tex2D(tex, worldPos.yz * _Scale);
            float4 yTex = tex2D(tex, worldPos.xz * _Scale);
            float4 zTex = tex2D(tex, worldPos.xy * _Scale);

            return xTex * blending.x + yTex * blending.y + zTex * blending.z;
        }

        // Función de mapeo triplanar para mapas normales
        float3 SampleTriplanarNormal(sampler2D tex, float3 worldPos, float3 worldNormal)
        {
            float3 blending = abs(worldNormal);
            blending = normalize(blending);

            float3 xTex = UnpackNormal(tex2D(tex, worldPos.yz * _Scale));
            float3 yTex = UnpackNormal(tex2D(tex, worldPos.xz * _Scale));
            float3 zTex = UnpackNormal(tex2D(tex, worldPos.xy * _Scale));

            return normalize(xTex * blending.x + yTex * blending.y + zTex * blending.z);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Normal en espacio del mundo
            float3 worldNormal = WorldNormalVector(IN, IN.worldNormal);

            // Albedo: Mapeo triplanar de la textura
            float4 albedo = SampleTriplanarTexture(_MainTex, IN.worldPos, worldNormal);

            // Verificación para evitar que el albedo sea blanco (por defecto) si la textura no se asignó
            if (albedo.r == 1.0 && albedo.g == 1.0 && albedo.b == 1.0)
            {
                // Si el albedo es blanco (sin textura), forzamos un color gris
                o.Albedo = float3(0.5, 0.5, 0.5); // Un color gris
            }
            else
            {
                o.Albedo = albedo.rgb;
            }

            // Normal Map
            o.Normal = SampleTriplanarNormal(_NormalMap, IN.worldPos, worldNormal);

            // Ambient Occlusion (AO)
            float ao = SampleTriplanarTexture(_OcclusionMap, IN.worldPos, worldNormal).r;
            o.Occlusion = ao;

            // Roughness (mapeado a Smoothness en Unity)
            float roughness = SampleTriplanarTexture(_RoughnessMap, IN.worldPos, worldNormal).r;
            o.Smoothness = 1.0 - roughness;

            // Metalness
            o.Metallic = SampleTriplanarTexture(_MetalnessMap, IN.worldPos, worldNormal).r;

            // Parallax Mapping (opcional)
            float height = SampleTriplanarTexture(_HeightMap, IN.worldPos, worldNormal).r * _HeightScale;
            IN.worldPos += worldNormal * height;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
