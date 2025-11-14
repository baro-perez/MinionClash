using System.Globalization;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class FloatTextMeshProBinder : TextMeshProBinderBase<float>
    {
        [SerializeField] private string format;
        [SerializeField] private string floatFormat;

        protected override string GetTextRepresentation(float value)
        {
            var numberRepresentation = string.IsNullOrWhiteSpace(floatFormat) ?
                value.ToString(CultureInfo.InvariantCulture) :
                value.ToString(floatFormat, CultureInfo.InvariantCulture);

            return string.IsNullOrWhiteSpace(format) ? numberRepresentation :
                string.Format(format, numberRepresentation);
        }
    }
}