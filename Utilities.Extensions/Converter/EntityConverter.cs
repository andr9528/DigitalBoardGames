using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Repository.Core;

namespace Utilities.Extensions.Converter
{
    public static class EntityConverter
    {
        //https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
        public static TTarget Convert<TTarget>(IEntity fromEntity) where TTarget : class, IEntity
        {
            var fromType = fromEntity.GetType();
            var targetType = typeof(TTarget);

            if (fromType.Name != targetType.Name)
                throw new ArgumentException("Name of targeted and imputed Class do not match", nameof(fromEntity));
            if (fromType.FullName == targetType.FullName)
                throw new ArgumentException("Namespace and Name of targeted and imputed Class match. No reason to convert between the exactly same types", nameof(fromEntity));

            var outputInstance = Activator.CreateInstance(targetType, false);

            var fromInfos = from source in fromType.GetMembers().ToList()
                where source.MemberType == MemberTypes.Property
                select source;

            var targetInfos = from source in targetType.GetMembers().ToList()
                where source.MemberType == MemberTypes.Property
                select source;

            var members = fromInfos.Where(memberInfo => targetInfos.Select(x => x.Name).ToList().Contains(memberInfo.Name)).ToList();

            foreach (var memberInfo in members)
            {
                var propertyInfo = targetType.GetProperty(memberInfo.Name);
                var value = fromType.GetProperty(memberInfo.Name)?.GetValue(fromEntity, null);

                if (propertyInfo != null) propertyInfo.SetValue(outputInstance, value, null);
            }

            return outputInstance as TTarget;
        }
    }
}