namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public class TextMeshProBinder : TextMeshProBinderBase<string>
    {
        protected override string GetTextRepresentation(string value)
        {
            return value;
        }
    }
}