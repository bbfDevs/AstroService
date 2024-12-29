using System;
using System.ComponentModel;
using System.Reflection;
using astroProject_service.Entities.EnumModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class EnumExtensions
{
    public static string ToDescription(this Enum value)
    {
        // Get the field info for the enum value
        FieldInfo? field = value.GetType().GetField(value.ToString());

        if (field is null)
        {
            return "";
        }

        DescriptionAttribute? descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
    }

    public static void ReflectToDatabase<T, S>(this EntityTypeBuilder<S> entityTypeBuilder)
        where T : Enum
        where S : EnumEntity, new() // Ensure that S is a subclass of EnumEntity with a parameterless constructor
    {
        S[] seeds = Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(enumValue =>
                {
                    var entity = new S
                    {
                        Id = Convert.ToInt32(enumValue),
                        Description = enumValue.ToDescription(),
                    };
                    return entity;
                })
            .ToArray();

        // Seed the entities into the database
        entityTypeBuilder.HasData(seeds);
    }

}
