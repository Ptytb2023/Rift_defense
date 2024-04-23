using UnityEngine;

public class AdapterDialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject _enabelGameObject;
    [SerializeField] private ContenerInfo contenerInfo;
    [SerializeField] private DialogSystem _dialogSystem;


    private static int LisenensDialog;

    private void OnEnable()
    {
        //GetSave();

        //if (LisenensDialog == 1)
        //{
        //    _enabelGameObject.SetActive(true);
        //    gameObject.SetActive(false);
        //    return;
        //}

        ShowDialog();
    }

    private void OnDisable()
    {
        _dialogSystem.EndDialog -= OnEndDialog;
    }

    private void OnEndDialog()
    {
        _enabelGameObject.SetActive(true);

        gameObject.SetActive(false);

        //Save();
    }

    public void ShowDialog()
    {
        _dialogSystem.gameObject.SetActive(true);
        _dialogSystem.EndDialog += OnEndDialog;
        contenerInfo.listenedDialog = true;
    }


    //private void GetSave()
    //{
    //    LisenensDialog = PlayerPrefs.GetInt(nameof(LisenensDialog), 0);
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetInt(nameof(LisenensDialog), 1);
    //}

    //[ContextMenu(nameof(RessetingSave))]
    //public void RessetingSave()
    //{
    //    PlayerPrefs.SetInt(nameof(LisenensDialog), 0);
    //}
}
