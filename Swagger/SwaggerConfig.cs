using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;


namespace store.Swagger;

public class SwaggerConfig : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var excludedTypes = new HashSet<string>
            {
                "AggregateException",
                "Assembly",
                "Exception",                                                
                "BaseResponseMessageTask",
                "CallingConventions",
                "ConstructorInfo",
                "CustomAttributeData",
                "CustomAttributeNamedArgument",
                "CustomAttributeTypedArgument",
                "EventAttributes",
                "EventInfo",
                "FieldAttributes",
                "FieldInfo",
                "GenericParameterAttributes",
                "ICustomAttributeProvider",
                "IntPtr",
                "LayoutKind",
                "MemberInfo",
                "MemberTypes",
                "MethodAttributes",
                "MethodBase",
                "MethodImplAttributes",
                "MethodInfo",
                "Module",
                "ModuleHandle",
                "ParameterAttributes",
                "ParameterInfo",
                "PropertyAttributes",
                "PropertyInfo",                                
                "RuntimeFieldHandle",
                "RuntimeMethodHandle",
                "RuntimeTypeHandle",
                "SecurityRuleSet",
                "StructLayoutAttribute",
                "TaskCreationOptions",
                "TaskStatus",
                "Type",
                "TypeAttributes",
                "TypeInfo"
            };


        foreach (var type in excludedTypes)
        {
            if (swaggerDoc.Components.Schemas.ContainsKey(type))
                swaggerDoc.Components.Schemas.Remove(type);
        }
    }
}
