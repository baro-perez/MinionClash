using AlvaroPerez.MinionClash.Model.Behaviours;
using AlvaroPerez.MinionClash.Model.Units;
using AlvaroPerez.MinionClash.Utils;
using AlvaroPerez.MinionClash.View.Units;
using System.Collections;
using UnityEngine;

namespace AlvaroPerez.MinionClash.Model
{
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private UnitMeshes meshes;

        [Header("Visuals")]
        [SerializeField] private float maxAngularSpeed = 120f;
        [SerializeField] private Transform hudAnchor;

        [Header("Attack jump")]
        [SerializeField] private float attackJumpTime = 0.25f;
        [SerializeField] private float attackJumpHeight = 0.2f;
        [SerializeField] private AnimationCurve attackJumpCurve = AnimationCurve.Constant(0, 1, 0);

        private bool inited = false;
        private Quaternion? rotateTowards;

        public Unit model;
        public Unit Model
        {
            get => model;
            set
            {
                Unsubscribe();
                model = value;
                Subscribe();
            }
        }

        public Team Team => Model.Team;
        public Transform HudAnchor => hudAnchor;

        public bool TickOnUpdate { get; set; } = true;

        private void Update()
        {
            DoRotateTowards();
        }

        private void DoRotateTowards()
        {
            if (rotateTowards.HasValue)
            {
                // Rotate gradually
                meshes.Pivot.rotation = Quaternion.RotateTowards(
                    meshes.Pivot.rotation, rotateTowards.Value, Time.deltaTime * maxAngularSpeed);
            }
        }

        private void Subscribe()
        {
            this.Model.OnPositionChange += OnPositionChange;
            this.Model.OnAttack += OnAttack;
            inited = true;
        }

        public void InitVisuals(
            Team team,
            UnitClass unitClass)
        {
            this.meshes.Init(team, unitClass);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (inited)
            {
                this.Model.OnPositionChange -= OnPositionChange;
                this.Model.OnAttack -= OnAttack;
                inited = false;
            }
        }

        private void OnAttack(object caller, UnitEvents.AttackEventData data)
        {
            if (data.target != null)
            {
                // Rotate automatically
                var forward = data.target.Position - Model.Position;
                this.meshes.Pivot.rotation = Quaternion.LookRotation(forward.ToVectorXZ());
                StartCoroutine(DoJump());
            }
        }

        private IEnumerator DoJump()
        {
            this.meshes.Pivot.localPosition = Vector3.zero;

            for(float f = 0f; f < attackJumpTime; f += Time.deltaTime)
            {
                var h = attackJumpHeight * attackJumpCurve.Evaluate(f / attackJumpTime);
                this.meshes.Pivot.localPosition = new Vector3(0, h, 0);
                yield return null;
            }

            this.meshes.Pivot.localPosition = Vector3.zero;
        }

        private void OnPositionChange(object caller, UnitEvents.PositionChangeEventData data)
        {
            transform.position = data.position.ToVectorXZ();
            var diff = data.position - data.prevPosition;
            if (diff.sqrMagnitude > 1e-6f)
            {
                rotateTowards = Quaternion.LookRotation(diff.ToVectorXZ());
            }
            else
            {
                rotateTowards = null;
            }
        }
    }
}
