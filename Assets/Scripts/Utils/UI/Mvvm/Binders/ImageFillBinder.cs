using UnityEngine;
using UnityEngine.UI;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class ImageFillBinder : UiBinder<float>
    {
        [SerializeField] private Image image;

        protected override void BindSetValue(PropertyBinding<float> binding)
        {
        }

        protected override void UnbindSetValue(PropertyBinding<float> binding)
        {
        }

        protected override void RefreshValue(float value)
        {
            image.fillAmount = value;
        }
    }
}