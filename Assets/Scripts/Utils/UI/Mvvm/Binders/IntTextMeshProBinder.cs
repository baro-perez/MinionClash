using System.Globalization;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class IntTextMeshProBinder : TextMeshProBinderBase<int>
    {
        [SerializeField] private string format;
        [SerializeField] private string intFormat;

        protected override string GetTextRepresentation(int value)
        {
            var numberRepresentation = string.IsNullOrWhiteSpace(intFormat) ?
                value.ToString(CultureInfo.InvariantCulture) :
                value.ToString(intFormat, CultureInfo.InvariantCulture);

            return string.IsNullOrWhiteSpace(format) ? numberRepresentation :
                string.Format(format, numberRepresentation);
        }
    }
}