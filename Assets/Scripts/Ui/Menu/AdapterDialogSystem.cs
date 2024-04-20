using UnityEngine;

public class AdapterDialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject _enabelGameObject;
    [SerializeField] private ContenerInfo contenerInfo;
    [SerializeField] private DialogSystem _dialogSystem;


    private int _listenedDialog;

    private void OnEnable()
    {
        GetSave();

        if (_listenedDialog == 1)
        {
            _enabelGameObject.SetActive(true);
            gameObject.SetActive(false);
            return;
        }

        _dialogSystem.gameObject.SetActive(true);
        _dialogSystem.EndDialog += OnEndDialog;
        contenerInfo.listenedDialog = true;
    }

    private void OnDisable()
    {
        _dialogSystem.EndDialog -= OnEndDialog;
    }

    private void OnEndDialog()
    {
        _enabelGameObject.SetActive(true);

        gameObject.SetActive(false);

        Save();
    }


    private void GetSave()
    {
        _listenedDialog = PlayerPrefs.GetInt(nameof(_listenedDialog), 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(nameof(_listenedDialog), 1);
    }

    private void Reset()
    {
        PlayerPrefs.SetInt(nameof(_listenedDialog), 0);
    }
}
