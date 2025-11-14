using UnityEngine;
using UnityEngine.UI;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class IntSliderBinder : UiBinder<int>
    {
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.wholeNumbers = true;
        }

        protected override void BindSetValue(PropertyBinding<int> binding)
        {
            slider.onValueChanged.AddListener(value => binding.setValue((int)value));
        }

        protected override void UnbindSetValue(PropertyBinding<int> binding)
        {
            slider.onValueChanged.RemoveListener(v => binding.setValue((int)v));
        }

        protected override void RefreshValue(int value)
        {
            slider.value = value;
        }
    }
}