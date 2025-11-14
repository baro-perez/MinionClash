using UnityEngine;
using UnityEngine.UI;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class SliderBinder : UiBinder<float>
    {
        [SerializeField] private Slider slider;

        protected override void BindSetValue(PropertyBinding<float> binding)
        {
            slider.onValueChanged.AddListener(value => binding.setValue(value));
        }

        protected override void UnbindSetValue(PropertyBinding<float> binding)
        {
            slider.onValueChanged.RemoveListener(v => binding.setValue(v));
        }

        protected override void RefreshValue(float value)
        {
            slider.value = value;
        }
    }
}