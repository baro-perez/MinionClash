using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class ViewModelModelBinder<ModelT> : UiBinder<ModelT>
    {
        [SerializeField] private ViewModel targetViewModel;

        public ViewModel TargetViewModel => targetViewModel;

        protected override void BindSetValue(PropertyBinding<ModelT> binding)
        {
        }

        protected override void UnbindSetValue(PropertyBinding<ModelT> binding)
        {
        }

        protected override void RefreshValue(ModelT value)
        {
            if (TargetViewModel is ViewModel<ModelT> castedViewModel)
            {
                castedViewModel.Model = value;
            }
            else
            {
                Debug.LogError($"Cannot set value of type {value.GetType().Name} to " +
                    $"{TargetViewModel.GetType().Name}.{nameof(ViewModel<ModelT>.Model)}");
            }
        }

        public void EnsureBound()
        {
            Bind();
        }
    }
}