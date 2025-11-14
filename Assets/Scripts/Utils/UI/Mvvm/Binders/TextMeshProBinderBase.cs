using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public abstract class TextMeshProBinderBase<T> : UiBinder<T>
    {
        [SerializeField] private TMPro.TMP_Text text;

        protected override void BindSetValue(PropertyBinding<T> binding)
        {
        }

        protected override void UnbindSetValue(PropertyBinding<T> binding)
        {
        }

        protected sealed override void RefreshValue(T value)
        {
            text.text = GetTextRepresentation(value);
        }

        protected abstract string GetTextRepresentation(T value);
    }
}