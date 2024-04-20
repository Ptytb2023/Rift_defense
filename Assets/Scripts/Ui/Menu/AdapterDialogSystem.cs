using UnityEngine;

public class AdapterDialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject _enabelGameObject;
    [SerializeField] private ContenerInfo contenerInfo;
    [SerializeField] private DialogSystem _dialogSystem;


    private void OnEnable()
    {
        if (contenerInfo.listenedDialog)
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
    }
}
