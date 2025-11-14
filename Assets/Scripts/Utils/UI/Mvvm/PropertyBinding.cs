namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm
{
    public sealed class PropertyBinding<T> : IPropertyBinding
    {
        public delegate T GetValueFn();
        public delegate void SetValueFn(T newValue);
        public delegate void RefreshValueFn(T newValue);

        public readonly GetValueFn getValue;
        public readonly SetValueFn setValue;
        public event RefreshValueFn refreshValue;

        public PropertyBinding(GetValueFn getValue, SetValueFn setValue)
        {
            this.getValue = getValue;
            this.setValue = setValue;
        }

        public void Refresh()
        {
            refreshValue?.Invoke(getValue());
        }
    }
}
