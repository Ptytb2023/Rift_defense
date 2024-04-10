using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic;
using RiftDefense.Beatle;
using UnityEngine;
using RiftDefense.Generic.Interface;

namespace RiftDefense.Edifice.Tower
{
    [RequireComponent(typeof(HandlerZoneTriger))]
    public class ClassicTowerView : BaseTowerView
    {
        [SerializeField] private Transform _head;

        private ClassiTower _classicCannonTower;

        private HandlerZoneTriger _hadlerSeatch;

        private SearchEnemyFromCollider<IBeatle> _searchBeatle;
        private TargetSystem<IBeatle> _targetSystem;
        private AttackSystemClassic _attackSystem;

        private DataEnemyTower _dataEnemu;

        private void Start()
        {
            Initialization();
        }


        private void Initialization()
        {
            _hadlerSeatch = GetComponent<HandlerZoneTriger>();
            _hadlerSeatch.Init(DataAtack.RadiusAtack);

            _searchBeatle = new SearchEnemyFromCollider<IBeatle>(_hadlerSeatch);
            _dataEnemu = new DataEnemyTower();
            _targetSystem = new TargetSystem<IBeatle>(_dataEnemu, _searchBeatle, transform);
            _attackSystem = new AttackSystemClassic(DataAtack);

            // HACK update
           // _classicCannonTower = new ClassiCannonTower(this, _targetSystem, _attackSystem, _head);
        }

        protected override void UpdateView()
        {
            throw new System.NotImplementedException();
        }


        public override void PreviewAtack(IEnemy enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}
