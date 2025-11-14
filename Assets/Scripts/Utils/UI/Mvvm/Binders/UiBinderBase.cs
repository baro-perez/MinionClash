using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils.Ui.Mvvm.Binders
{
    public abstract class UiBinderBase : MonoBehaviour
    {
        [SerializeField] private ViewModel viewModel;
        [SerializeField] private string propertyName;

        public bool Bound { get; protected set; }
        public ViewModel ViewModel => viewModel;
        public string PropertyName => propertyName;

        private void OnEnable()
        {
            Bind();
        }

        private void OnDisable()
        {
            Unbind();
        }

        protected abstract void Bind();
        protected abstract void Unbind();
    }
}