using System;
using System.Reflection;
using HotChocolate.Types.Descriptors;

#nullable enable

namespace HotChocolate.Types
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Interface,
        Inherited = true,
        AllowMultiple = true)]
    public abstract class InputUnionTypeDescriptorAttribute
        : DescriptorAttribute
    {
        internal protected sealed override void TryConfigure(
            IDescriptorContext context,
            IDescriptor descriptor,
            ICustomAttributeProvider element)
        {
            if (descriptor is IInputUnionTypeDescriptor d
                && element is Type t)
            {
                OnConfigure(context, d, t);
            }
        }

        public abstract void OnConfigure(
            IDescriptorContext context,
            IInputUnionTypeDescriptor descriptor,
            Type type);
    }
}