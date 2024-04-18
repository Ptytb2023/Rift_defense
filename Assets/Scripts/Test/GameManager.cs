using RiftDefense.Generic.Interface;
using RiftDefense.Player.Container;
using RiftDefense.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UiAsistent _uiAsistent;
    [SerializeField] private SpawnerBeatle _spawnerBeatle;
    [SerializeField] private MainTower _mainTower;
    [SerializeField] private ContainerPolymers _polimers;
    [SerializeField] private SceneLoadManager _sceneLoadManager;


    private const int indexMenu = 0;

    private void Awake()
    {
        _polimers.Resetiong();
        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }


    private void OnEnable()
    {
        _spawnerBeatle.AllEnemyDead += Victory;
        _mainTower.Dead += Defeat;
        _uiAsistent.ButtonClickExit += ExitMenu;
    }

    private void OnDisable()
    {
        _spawnerBeatle.AllEnemyDead -= Victory;
        _mainTower.Dead -= Defeat;
        _uiAsistent.ButtonClickExit -= ExitMenu;
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
}
