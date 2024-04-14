using Lean.Pool;
using RiftDefense.Beatle;
using System;
using System.Collections;
using System.Collections.Generic;
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

    private const float _precentMaxTimeRandom = 1f;
    private int _currentIntWave;

    private void Start()
    {
        StarSpawner();
    }

    public void StarSpawner()
    {
        _currentIntWave = 0;
        StartCoroutine(Spaw());
    }

    private IEnumerator Spaw()
    {
        yield return new WaitForSeconds(_delayStartSpawn);

        while (TryGetWave(out Wave wave))
        {
            yield return new WaitForSeconds(wave.DelayStartSpawn);
            Debug.Log(wave.DelayStartSpawn);

            var time = wave.TimeSpawn;
            var coutEnemy = wave.CoutBeatle;

            while (time > 0)
            {
                float DelayToSpawn = time;
                int coutSpawn = coutEnemy;

                //if (time > 1f)
                //{
                    var maxDeleay = (time * _percentMaxTimeRandom) / 100f;
                    var minDelay = maxDeleay / 3f;
                    DelayToSpawn = UnityEngine.Random.Range(minDelay, maxDeleay);
                //}

                //if (coutEnemy > 1 && time > 1f)
                //{
                    int maxSpawn = (int)((coutEnemy * _percentMaxCoutBeatle) / 100f);
                    coutSpawn = UnityEngine.Random.Range(1, maxSpawn++);
                //}

                yield return new WaitForSeconds(DelayToSpawn);

                if (coutEnemy > 0)
                    SpawnBeatle(wave, coutSpawn);

                time -= DelayToSpawn;
                coutEnemy -= coutSpawn;
            }
        }
    }

    private void SpawnBeatle(Wave wave, int coutSpawn)
    {
        for (int i = 0; i < coutSpawn; i++)
        {
            var randomIndexBeatle = Random.Range(0, wave.Beatles.Count);

            var beatle = wave.Beatles[randomIndexBeatle];

            LeanPool.Spawn(beatle, GetPoint(), Quaternion.identity);
        }
    }

    private Vector3 GetPoint()
    {
        int randomPointIndex = UnityEngine.Random.Range(0, _poitnSpawns.Count);
        return _poitnSpawns[randomPointIndex].position;
    }

    private bool TryGetWave(out Wave wave)
    {
        wave = null;

        if (_waves.Count > 0)
        {
            wave = _waves[0];
            _waves.RemoveAt(0);
            return true;
        }

        return false;
    }


}

[Serializable]
public class Wave
{
    [field: SerializeField] public float DelayStartSpawn { get; private set; }
    [field: SerializeField] public List<BaseBeatle> Beatles { get; private set; }
    [field: SerializeField] public int CoutBeatle { get; private set; }
    [field: SerializeField] public float TimeSpawn { get; private set; }

}
