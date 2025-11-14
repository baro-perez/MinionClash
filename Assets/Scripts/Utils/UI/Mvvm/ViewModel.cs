using AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm
{
    public abstract class ViewModel : MonoBehaviour
    {
        private bool populatedBindings;

        private Dictionary<string, IPropertyBinding> propertyBindings { get; }
            = new Dictionary<string, IPropertyBinding>();


        protected virtual void Awake()
        {
            EnsurePopulateBindings();
        }

        public PropertyBinding<T> GetBinding<T>(string propertyName)
        {
            // Depending on object order of initialization, Awake might not have been called yet for this object
            // (children might get awoken/enabled before parents)
            // => We need to ensure the bindings are available before getting them
            EnsurePopulateBindings();

            if (!propertyBindings.TryGetValue(propertyName, out var propertyBinding) ||
                !(propertyBinding is PropertyBinding<T> castedBinding))
            {
                throw new ArgumentOutOfRangeException(nameof(propertyName),
                    $"Cannot find binding of type {typeof(T).Name} for property {propertyName}");
            }

            return castedBinding;
        }

        protected void RegisterBinding<T>(
            string propertyName,
            PropertyBinding<T>.GetValueFn getValue,
            PropertyBinding<T>.SetValueFn setValue)
        {
            propertyBindings.Add(propertyName, new PropertyBinding<T>(getValue, 
                value =>
                {
                    setValue(value);
                    RefreshBinding(propertyName);
                }));
        }

        protected abstract void PopulateBindings();

        protected virtual void BeforePopulateBindings()
        {
        }

        private void EnsurePopulateBindings()
        {
            if (!populatedBindings)
            {
                BeforePopulateBindings();
                PopulateBindings();
                populatedBindings = true;
            }
        }

        public void RefreshBinding(string propertyName)
        {
            EnsurePopulateBindings();
            propertyBindings[propertyName].Refresh();
        }

        public void RefreshAllBindings()
        {
            foreach (var item in propertyBindings)
            {
                item.Value.Refresh();
            }
        }
    }

    public abstract class ViewModel<T> : ViewModel
    {
        public abstract T Model { get; set; }

        [Tooltip("Assumed to be null or a matching ViewModelModelBinder<T>")]
        [SerializeField] private UiBinderBase viewModelModelBinder;

        protected override void BeforePopulateBindings()
        {
            base.BeforePopulateBindings();
            if (viewModelModelBinder is ViewModelModelBinder<T> castedViewModelModelBinder &&
                castedViewModelModelBinder.TargetViewModel == this)
            {
                castedViewModelModelBinder.EnsureBound();
            }
        }
    }
}
