using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Generic.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerBeatle : MonoBehaviour
{
    [SerializeField] private MainTower _mainTower;
    [SerializeField] private List<Transform> _poitnSpawns;
    [SerializeField] private float _delayStartSpawn;
    [SerializeField] private List<Wave> _waves;
    [SerializeField][Range(10f, 100f)] private float _percentMaxTimeRandom;
    [SerializeField][Range(10f, 100f)] private float _percentMaxCoutBeatle;

    private int _currentIndexWave;
    private Wave _currentWave;

    private int _currentCoutSpawn;
    private WaitForSeconds _sleep;

    public Action AllEnemyDead;

    private void Start()
    {
        _sleep = new WaitForSeconds(10f);
        StarSpawner();
    }

    public void StarSpawner()
    {
        StartCoroutine(Spaw());
    }

    private IEnumerator Spaw()
    {
        yield return new WaitForSeconds(_delayStartSpawn);

        SetWave();

        while (_currentWave != null)
        {
            yield return new WaitForSeconds(_currentWave.DelayStartSpawn);
            Debug.Log(_currentWave.DelayStartSpawn);

            var time = _currentWave.TimeSpawn;
            var coutEnemy = _currentWave.CoutBeatle;

            while (time > 0)
            {
                float DelayToSpawn = time;
                int coutSpawn = coutEnemy;

                if (time > 1f)
                {
                    var maxDeleay = (time * _percentMaxTimeRandom) / 100f;
                    var minDelay = maxDeleay / 3f;
                    DelayToSpawn = UnityEngine.Random.Range(minDelay, maxDeleay);
                }

                if (coutEnemy > 1 && time > 1f)
                {
                    int maxSpawn = (int)((coutEnemy * _percentMaxCoutBeatle) / 100f);
                    coutSpawn = UnityEngine.Random.Range(1, maxSpawn++);
                }

                yield return new WaitForSeconds(DelayToSpawn);

                if (coutEnemy > 0)
                    SpawnBeatle(_currentWave, coutSpawn);

                time -= DelayToSpawn;
                coutEnemy -= coutSpawn;

                if (time <= 0)
                    SetWave();
            }
        }

       // StartCoroutine(EndGame());
    }

    private void SpawnBeatle(Wave wave, int coutSpawn)
    {
        for (int i = 0; i < coutSpawn; i++)
        {
            var randomIndexBeatle = Random.Range(0, wave.Beatles.Count);

            var beatle = wave.Beatles[randomIndexBeatle];

            var enemy = LeanPool.Spawn(beatle, GetPoint(), Quaternion.identity);

            enemy.Dead += OnEnemyDead;
            _currentCoutSpawn++;
        }
    }

    private IEnumerator EndGame()
    {
        while (_currentCoutSpawn > 0)
        {
            yield return _sleep;
        }

        AllEnemyDead?.Invoke();
    }

    private Vector3 GetPoint()
    {
        int randomPointIndex = UnityEngine.Random.Range(0, _poitnSpawns.Count);
        return _poitnSpawns[randomPointIndex].position;
    }

    private void SetWave()
    {
        if (_waves.Count > 0 && _currentIndexWave < _waves.Count)
        {
            _currentWave = _waves[_currentIndexWave];
            _currentIndexWave++;
            return;
        }
        _currentWave = null;
    }


    private void OnEnemyDead(IEnemy enemy)
    {
        enemy.Dead -= OnEnemyDead;
        _currentCoutSpawn--;

        if (_currentCoutSpawn <= 0 && _currentIndexWave >= _waves.Count)
            AllEnemyDead?.Invoke();
    }

}

[Serializable]
public class Wave
{
    [field: SerializeField] public float DelayStartSpawn { get; private set; }
    [field: SerializeField] public List<BaseBeatleView> Beatles { get; private set; }
    [field: SerializeField] public int CoutBeatle { get; private set; }
    [field: SerializeField] public float TimeSpawn { get; private set; }

}
