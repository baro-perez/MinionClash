namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public abstract class UiBinder<T> : UiBinderBase
    {
        private PropertyBinding<T> binding;

        protected override void Bind()
        {
            if (!Bound)
            {
                binding = ViewModel.GetBinding<T>(PropertyName);
                BindSetValue(binding);
                binding.refreshValue += RefreshValue;
                RefreshValue(binding.getValue());
                Bound = true;
            }
        }

        protected override void Unbind()
        {
            if (Bound)
            {
                UnbindSetValue(binding);
                binding.refreshValue -= RefreshValue;
                binding = null;
                Bound = false;
            }
        }

        protected abstract void RefreshValue(T value);
        protected abstract void BindSetValue(PropertyBinding<T> binding);
        protected abstract void UnbindSetValue(PropertyBinding<T> binding);
    }
}