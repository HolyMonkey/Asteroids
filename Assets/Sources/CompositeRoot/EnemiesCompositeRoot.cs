using Asteroids.Input;
using Asteroids.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CompositeRoot
{
    public class EnemiesCompositeRoot : CompositeRoot
    {
        [SerializeField] private EnemiesViewFactory _viewFactory;
        [SerializeField] private ShipCompositeRoot _ship;

        private EnemiesSimulation _simulation;
        private EnemiesSpawner _spawner;

        public EnemiesSimulation Simulation => _simulation;

        public override void Compose()
        {
            _simulation = new EnemiesSimulation();
            _spawner = new EnemiesSpawner(_simulation, _ship.Model);
            _spawner.FillTestQueue();
        }

        private void OnEnable()
        {
            _simulation.Start += _viewFactory.Create;
            _simulation.End += _viewFactory.Destroy;
        }

        private void OnDisable()
        {
            _simulation.Start -= _viewFactory.Create;
            _simulation.End -= _viewFactory.Destroy;
        }

        private void Update()
        {
            _simulation.Update(Time.deltaTime);
            _spawner.Update(Time.deltaTime);
        }
    }
}
