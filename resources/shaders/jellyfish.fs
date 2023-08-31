#version 330 core

in vec3 FragPos;

layout (location = 0) out vec4 FragColor;
layout (location = 1) out vec4 BrightColor;

void main() {
    vec3 color = vec3(100.0f, 100.0f, 100.0f);
    FragColor = vec4(color, 1.0f);
    float brightness = dot(color, vec3(0.2126, 0.7152, 0.0722));
    if (brightness > 1.0) {
        BrightColor = vec4(color, 1.0f);
    } else {
        BrightColor = vec4(0.0, 0.0, 0.0, 1.0f);
    }
}


// #version 330 core
// out vec4 FragColor;
//
// struct PointLight {
//     vec3 position;
//
//     vec3 specular;
//     vec3 diffuse;
//     vec3 ambient;
//
//     float constant;
//     float linear;
//     float quadratic;
// };
//
// struct DirLight {
//     vec3 direction;
//
//     vec3 specular;
//     vec3 diffuse;
//     vec3 ambient;
// };
//
// struct Material {
//     sampler2D texture_diffuse1;
//     sampler2D texture_specular1;
//
//     float shininess;
// };
// in vec2 TexCoords;
// in vec3 Normal;
// in vec3 FragPos;
//
// uniform PointLight pointLight;
// uniform Material material;
//
// uniform DirLight dirLight;
//
// uniform vec3 viewPosition;
//
// // calculates the color when using a point light.
// vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir)
// {
//     vec3 lightDir = normalize(light.position - fragPos);
//     // diffuse shading
//     float diff = max(dot(normal, lightDir), 0.0);
//     // specular shading
//     vec3 reflectDir = reflect(-lightDir, normal);
//     float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
//     // attenuation
//     float distance = length(light.position - fragPos);
//     float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));
//     // combine results
//     vec3 ambient = 2 * light.ambient * vec3(texture(material.texture_diffuse1, TexCoords));
//     vec3 diffuse = light.diffuse * diff * vec3(texture(material.texture_diffuse1, TexCoords));
//     vec3 specular = 2 * light.specular * spec * vec3(texture(material.texture_specular1, TexCoords).xyz);
//     ambient *= attenuation;
//     diffuse *= attenuation;
//     specular *= attenuation;
//     return (ambient + diffuse + specular);
// }
//
// vec3 CalcDirLight(DirLight light, vec3 normal, vec3 viewDir)
// {
//     vec3 lightDir = normalize(-light.direction);
//     // diffuse shading
//     float diff = max(dot(normal, lightDir), 0.0);
//     // specular shading
//     vec3 reflectDir = reflect(-lightDir, normal);
//     float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
//     // combine results
//     vec3 ambient = 2 * light.ambient * vec3(texture(material.texture_diffuse1, TexCoords));
//     vec3 diffuse = light.diffuse * diff * vec3(texture(material.texture_diffuse1, TexCoords));
//     vec3 specular = 2 * light.specular * spec * vec3(texture(material.texture_specular1, TexCoords));
//     return (ambient + diffuse + specular);
// }
//
// void main()
// {
//     vec3 normal = normalize(Normal);
//     vec3 viewDir = normalize(viewPosition - FragPos);
//     vec3 result = CalcPointLight(pointLight, normal, FragPos, viewDir);
//
//     result += CalcDirLight(dirLight, normal, viewDir);
//
//     FragColor = vec4(result, 1.0);
// }