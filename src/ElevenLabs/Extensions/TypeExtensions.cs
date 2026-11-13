using System.Collections;
using System.Reflection;
#if !NET5_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
#endif

namespace ElevenLabs.Extensions;

/// <summary>
/// Extension methods for Type and PropertyInfo to query type characteristics.
/// Used internally for reflection-based serialization and validation logic.
/// </summary>
internal static class TypeExtensions
{
#if NET5_0_OR_GREATER
    private static readonly NullabilityInfoContext NullabilityInfoContext = new();

    /// <summary>
    /// Determines if a property is nullable based on C# nullable reference type annotations.
    /// Uses NullabilityInfoContext to inspect compile-time nullability metadata.
    /// </summary>
    /// <param name="property">The property to check.</param>
    /// <returns>True if the property is marked as nullable, false otherwise.</returns>
    internal static bool IsNullable(this PropertyInfo property)
    {
        var nullabilityInfo = NullabilityInfoContext.Create(property);
        return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }
#else
    /// <summary>
    /// Determines if a property is nullable based on C# nullable reference type annotations.
    /// NullabilityInfoContext is net5.0+, so on net462/netstandard2.0 this reads the
    /// compiler-emitted nullable-reference-type metadata directly: a NullableAttribute with a
    /// first flag of 2 (nullable), falling back to the declaring type's NullableContextAttribute.
    /// </summary>
    /// <param name="property">The property to check.</param>
    /// <returns>True if the property is marked as nullable, false otherwise.</returns>
    internal static bool IsNullable(this PropertyInfo property)
    {
        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
        {
            return true;
        }
        if (property.PropertyType.IsValueType)
        {
            return false;
        }

        var nullableAttribute = property
            .GetCustomAttributesData()
            .FirstOrDefault(attribute =>
                attribute.AttributeType.FullName
                == "System.Runtime.CompilerServices.NullableAttribute"
            );
        if (nullableAttribute != null && nullableAttribute.ConstructorArguments.Count == 1)
        {
            var argument = nullableAttribute.ConstructorArguments[0];
            if (argument.Value is byte flag)
            {
                return flag == 2;
            }
            if (
                argument.Value is IReadOnlyList<CustomAttributeTypedArgument> flags
                && flags.Count > 0
                && flags[0].Value is byte firstFlag
            )
            {
                return firstFlag == 2;
            }
        }

        var contextAttribute = (
            property.DeclaringType?.GetCustomAttributesData() ?? new List<CustomAttributeData>()
        ).FirstOrDefault(attribute =>
            attribute.AttributeType.FullName
            == "System.Runtime.CompilerServices.NullableContextAttribute"
        );
        if (
            contextAttribute != null
            && contextAttribute.ConstructorArguments.Count == 1
            && contextAttribute.ConstructorArguments[0].Value is byte contextFlag
        )
        {
            return contextFlag == 2;
        }

        return false;
    }
#endif

    /// <summary>
    /// Determines if a type represents a collection (implements IEnumerable).
    /// Excludes string, which implements IEnumerable but is treated as a primitive.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns>True if the type is a collection (but not string), false otherwise.</returns>
    internal static bool IsCollectionType(this global::System.Type type)
    {
        return type != typeof(string) && type.GetInterface(nameof(IEnumerable)) != null;
    }
}
