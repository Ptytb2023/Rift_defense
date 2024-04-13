using RiftDefense.Player.Container;
using System;
using System.Collections;
using UnityEngine;

public class MiningSystem : MonoBehaviour
{
    [SerializeField] private int _startingAmountPolymer = 0;
    [SerializeField] private int _extractionSecond = 1;
    [SerializeField] private ContainerPolymers _containerPolymers;
    [SerializeField][Range(1, 3)] private float _rangeTimeMining;

    private int _currentExtractionSecond;

    private const float _miningTime = 1f;
    private float _currentMiningTime;

    private Coroutine _coroutine;

    public void SetExtractionInSecond(int countExtraction)
    {
        if (countExtraction < 0)
            throw new ArgumentOutOfRangeException(nameof(countExtraction));

        _currentExtractionSecond = countExtraction;
    }

    private void OnEnable()
    {
        Reseting();
        _coroutine = StartCoroutine(GetResource());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator GetResource()
    {

        while (enabled)
        {
            var second = UnityEngine.Random.Range(_miningTime, _rangeTimeMining);
            _containerPolymers.AddPolymers(_currentExtractionSecond);
            yield return new WaitForSeconds(second);
        }
    }

    private void Reseting()
    {
        _currentMiningTime = _miningTime;
        _currentExtractionSecond = _extractionSecond;
    }
}
