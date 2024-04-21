using MushroomMadness.UI.LoadScene;
using RiftDefense.UI.Shopping;
using System;
using UnityEngine;
using Zenject;

public class UiAsistent : MonoBehaviour
{
    [SerializeField] private ScreenPause _screenPause;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private TowerShopScreen _shopScreen;
    [SerializeField] private ScreenLoadGame _loadGame;
    [SerializeField] private ScreenDefeat _screenDefeat;
    [SerializeField] private ScreenVictory _screenVictory;

    [SerializeField] private DialogSystem _dialogSystem;
    [field: SerializeField] public bool IsDialog { get; private set; }

    public Action ButtonClickExit;
    public Action ButtonClickContinio;

    public Action EndDialogSystem;

   

    private void Awake()
    {
        _shopScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (IsDialog)
        {
            _dialogSystem.gameObject.SetActive(true);
            _dialogSystem.EndDialog += StartGame;
        }
        else
            StartGame();


        _screenDefeat.ButtonClickMenu += ExitMenu;

        _screenPause.ButtonClickContinio += ClickContinio;
        _screenPause.ButtonClickExit += ExitMenu;

    }

    public void ShowPause()
    {
        _screenPause.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        if (IsDialog)
            _dialogSystem.EndDialog -= StartGame;

        _timerView.gameObject.SetActive(true);
        _timerView.StartTimer();
        _shopScreen.gameObject.SetActive(true);
        EndDialogSystem?.Invoke();
    }

    private void OnDisable()
    {
        _screenDefeat.ButtonClickMenu -= ExitMenu;
        _screenVictory.ButtonClickMenu -= ExitMenu;

        _screenDefeat.ButtonClickMenu -= ExitMenu;

        _screenPause.ButtonClickContinio -= ClickContinio;
        _screenPause.ButtonClickExit -= ExitMenu;
    }

    public void ShowScreenDefeat()
    {
        _screenDefeat.gameObject.SetActive(true);
    }


    public void ShowScreenVictory(string message, float delayOneChar)
    {
        _screenVictory.gameObject.SetActive(true);
        _screenVictory.SetText(message, delayOneChar);

        _screenVictory.ButtonClickMenu += ExitMenu;
    }

    private void ExitMenu()
    {
        ButtonClickExit?.Invoke();
    }

    private void ClickContinio()
    {
        _screenDefeat.gameObject.SetActive(false);
        ButtonClickContinio?.Invoke();
    }
       

    public void ShwoLoadSreen()
    {
        _loadGame.gameObject.SetActive(true);
    }
}
