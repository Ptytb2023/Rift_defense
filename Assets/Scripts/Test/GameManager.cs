using RiftDefense.Generic.Interface;
using RiftDefense.Player.Container;
using RiftDefense.UI;
using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UiAsistent _uiAsistent;
    [SerializeField] private SpawnerBeatle _spawnerBeatle;
    [SerializeField] private MainTower _mainTower;
    [SerializeField] private ContainerPolymers _polimers;
    [SerializeField] private SceneLoadManager _sceneLoadManager;

    [Space]
    [SerializeField] private int _countPolymersForStars;
    [SerializeField] private float _delayForOneChar = 0.2f;

    [TextArea()]
    [SerializeField] private string[] _text;


    private const int indexMenu = 0;


    [Inject]
    private IInputMenu _inputMenu;

    private void Awake()
    {
        Time.timeScale = 1f;
        _polimers.Resetiong();
        _spawnerBeatle.gameObject.SetActive(false);
        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }


    private void OnEnable()
    {
        _spawnerBeatle.AllEnemyDead += Victory;
        _mainTower.Dead += Defeat;
        _uiAsistent.ButtonClickExit += ExitMenu;
        _uiAsistent.EndDialogSystem += StartGame;

        _inputMenu.clickEscape += OnPause;

        _uiAsistent.ButtonClickContinio += Continio;

        if (!_uiAsistent.IsDialog)
            StartGame();
    }

    private void OnDisable()
    {
        _spawnerBeatle.AllEnemyDead -= Victory;
        _mainTower.Dead -= Defeat;
        _uiAsistent.ButtonClickExit -= ExitMenu;

        _uiAsistent.EndDialogSystem -= StartGame;

        _inputMenu.clickEscape -= OnPause;
        _uiAsistent.ButtonClickContinio -= Continio;
    }

    private void Victory()
    {
        Time.timeScale = 0f;

        float CurrentPolymer = _polimers.AmountPolymer;
        float PolymersForStars = _countPolymersForStars;
        double result = 0;

        if (CurrentPolymer > 0)
        {
            result = Math.Floor(CurrentPolymer / PolymersForStars);

            if (result > 0)
                result -= 1;

            if (result > _text.Length)
                result = _text.Length - 1;
        }

        string message = _text[(int)result];

        _uiAsistent.ShowScreenVictory(message, _delayForOneChar);
    }

    private void Defeat(IEnemy enemy)
    {
        Time.timeScale = 0f;
        _uiAsistent.ShowScreenDefeat();
    }

    private void ExitMenu()
    {
        _uiAsistent.ShwoLoadSreen();
        MenuManager.OpenLevels = true;
        _sceneLoadManager.LoadScene(indexMenu);
    }


    private void StartGame()
    {
        _uiAsistent.EndDialogSystem -= StartGame;
        _spawnerBeatle.gameObject.SetActive(true);
        _mainTower.StartMinigSystem();
    }


    private void OnPause()
    {
        _uiAsistent.ShowPause();
        Time.timeScale = 0f;
    }

    private void Continio()
    {
        Time.timeScale = 1f;
    }

}
