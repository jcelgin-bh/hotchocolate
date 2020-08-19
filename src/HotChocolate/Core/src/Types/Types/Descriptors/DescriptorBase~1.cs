using System;
using HotChocolate.Types.Descriptors.Definitions;
using System.Collections.Generic;
using HotChocolate.Configuration;

#nullable enable

namespace HotChocolate.Types.Descriptors
{
    public abstract class DescriptorBase<T>
        : IDescriptor<T>
        , IDescriptorExtension<T>
        , IDescriptorExtension
        , IDefinitionFactory<T>
        , IHasDescriptorContext
        where T : DefinitionBase
    {
        private readonly List<Action<T>> _modifiers = new List<Action<T>>();

        protected DescriptorBase(IDescriptorContext context)
        {
            Context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        protected internal IDescriptorContext Context { get; }

        IDescriptorContext IHasDescriptorContext.Context => Context;

        protected internal abstract T Definition { get; protected set; }

        public IDescriptorExtension<T> Extend()
        {
            return this;
        }

        public T CreateDefinition()
        {
            OnCreateDefinition(Definition);

            foreach (Action<T> modifier in _modifiers)
            {
                modifier.Invoke(Definition);
            }

            return Definition;
        }

        protected virtual void OnCreateDefinition(T definition)
        {
        }

        DefinitionBase IDefinitionFactory.CreateDefinition() =>
            CreateDefinition();

        void IDescriptorExtension<T>.OnBeforeCreate(Action<T> configure) =>
            OnBeforeCreate(configure);

        void IDescriptorExtension.OnBeforeCreate(Action<DefinitionBase> configure) =>
            OnBeforeCreate(configure);

        private void OnBeforeCreate(Action<T> configure)
        {
            if (configure is null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            _modifiers.Add(configure);
        }

        INamedDependencyDescriptor IDescriptorExtension<T>.OnBeforeNaming(
            Action<ITypeCompletionContext, T> configure) =>
            OnBeforeNaming(configure);

        INamedDependencyDescriptor IDescriptorExtension.OnBeforeNaming(
            Action<ITypeCompletionContext, DefinitionBase> configure) =>
            OnBeforeNaming(configure);

        private INamedDependencyDescriptor OnBeforeNaming(
           Action<ITypeCompletionContext, T> configure)
        {
            if (configure is null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var configuration = new TypeConfiguration<T>
            {
                Definition = Definition,
                On = ApplyConfigurationOn.Naming,
                Configure = configure
            };
            Definition.Configurations.Add(configuration);

            return new NamedDependencyDescriptor<T>(configuration);
        }

        ICompletedDependencyDescriptor IDescriptorExtension<T>.OnBeforeCompletion(
            Action<ITypeCompletionContext, T> configure) =>
            OnBeforeCompletion(configure);

        ICompletedDependencyDescriptor IDescriptorExtension.OnBeforeCompletion(
            Action<ITypeCompletionContext, DefinitionBase> configure) =>
            OnBeforeCompletion(configure);

        private ICompletedDependencyDescriptor OnBeforeCompletion(
            Action<ITypeCompletionContext, T> configure)
        {
            var configuration = new TypeConfiguration<T>
            {
                Definition = Definition,
                On = ApplyConfigurationOn.Completion,
                Configure = configure
            };
            Definition.Configurations.Add(configuration);

            return new CompletedDependencyDescriptor<T>(configuration);
        }
    }
}
