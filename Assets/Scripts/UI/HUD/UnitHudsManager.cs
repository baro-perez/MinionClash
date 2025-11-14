using AlvaroPerez.MinionClash.Main;
using AlvaroPerez.MinionClash.Model;
using AlvaroPerez.MinionClash.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Ui.Hud
{
    public class UnitHudsManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Camera gameCamera;
        [SerializeField] private Camera uiCamera;
        [Space]
        [SerializeField] private UnitViewModel unitHudPrefab;
        [SerializeField] private Transform unitHudsParent;

        public Transform UnitHudsParent => unitHudsParent == null ? transform : unitHudsParent;

        private Dictionary<UnitView, UnitViewModel> unitHuds = new Dictionary<UnitView, UnitViewModel>();

        private void Start()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            gameManager.UnitViewManager.OnUnitViewAdded += OnUnitViewAdded;
            gameManager.UnitViewManager.OnUnitViewRemoved += OnUnitRemoved;
        }

        private void Unsubscribe()
        {
            gameManager.UnitViewManager.OnUnitViewAdded -= OnUnitViewAdded;
            gameManager.UnitViewManager.OnUnitViewRemoved -= OnUnitRemoved;
        }

        private void OnUnitViewAdded(object caller, UnitViewManagerEvents.UnitViewAddedEventData data)
        {
            var unitHud = InstantiateUnitHud(data.unitView);
            unitHuds.Add(data.unitView, unitHud);
        }

        private UnitViewModel InstantiateUnitHud(UnitView unit)
        {
            var instanceGO = Object.Instantiate(unitHudPrefab.gameObject);
            instanceGO.transform.SetParent(UnitHudsParent, false);

            // Setup UnitViewModel
            var unitHud = instanceGO.GetComponent<UnitViewModel>();
            unitHud.Model = unit;

            // Setup WorldSpaceToOverlayUi
            var worldSpaceToUi = instanceGO.GetComponent<WorldSpaceToOverlayUi>();
            worldSpaceToUi.WorldCamera = gameCamera;
            worldSpaceToUi.UiCamera = uiCamera;
            worldSpaceToUi.TrackTransform = unit.HudAnchor;
            worldSpaceToUi.UpdatePosition();
            return unitHud;
        }

        private void OnUnitRemoved(object caller, UnitViewManagerEvents.UnitViewRemovedEventData data)
        {
            if (!unitHuds.TryGetValue(data.unitView, out var unithud))
            {
                Debug.LogError($"No HUD found for unit {data.unitView}");
                return;
            }
            UnityEngine.Object.Destroy(unithud.gameObject);
            unitHuds.Remove(data.unitView);
        }
    }
}