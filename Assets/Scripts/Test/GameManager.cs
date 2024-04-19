using RiftDefense.Generic.Interface;
using RiftDefense.Player.Container;
using RiftDefense.UI;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UiAsistent _uiAsistent;
    [SerializeField] private SpawnerBeatle _spawnerBeatle;
    [SerializeField] private MainTower _mainTower;
    [SerializeField] private ContainerPolymers _polimers;
    [SerializeField] private SceneLoadManager _sceneLoadManager;

    private const int indexMenu = 0;

    [Inject]
    private IInputMenu _inputMenu;

    private void Awake()
    {
        _polimers.Resetiong();
        _spawnerBeatle.gameObject.SetActive(false);
        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }


    private void OnEnable()
    {
        _spawnerBeatle.AllEnemyDead += Victory;
        _mainTower.Dead += Defeat;
        _uiAsistent.ButtonClickExit += ExitMenu;
        _uiAsistent.EndDialogSystem += StartGeame;

        _inputMenu.clickEscape += OnPause;

        _uiAsistent.ButtonClickContinio += Continio;
    }

    private void OnDisable()
    {
        _spawnerBeatle.AllEnemyDead -= Victory;
        _mainTower.Dead -= Defeat;
        _uiAsistent.ButtonClickExit -= ExitMenu;

        _uiAsistent.EndDialogSystem -= StartGeame;

        _inputMenu.clickEscape -= OnPause;
        _uiAsistent.ButtonClickContinio -= Continio;
    }

    private void Victory()
    {
        _uiAsistent.ShowScreenVictory();
    }

    private void Defeat(IEnemy enemy)
    {
        _uiAsistent.ShowScreenDefeat();
    }

    private void ExitMenu()
    {
        _uiAsistent.ShwoLoadSreen();
        _sceneLoadManager.LoadScene(indexMenu);
    }


    private void StartGeame()
    {
        _uiAsistent.EndDialogSystem -= StartGeame;
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
