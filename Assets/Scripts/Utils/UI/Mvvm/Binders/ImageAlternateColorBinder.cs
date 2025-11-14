using UnityEngine;
using UnityEngine.UI;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class ImageAlternateColorBinder : UiBinder<bool>
    {
        [SerializeField] private Image image;
        [SerializeField] private Color ColorTrue = Color.green;
        [SerializeField] private Color ColorFalse = Color.red;

        protected override void BindSetValue(PropertyBinding<bool> binding)
        {
        }

        protected override void UnbindSetValue(PropertyBinding<bool> binding)
        {
        }

        protected override void RefreshValue(bool value)
        {
            image.color = value ? ColorTrue : ColorFalse;
        }
    }
}