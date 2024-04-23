using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _screenMenu;
    [SerializeField] private GameObject _screenLevels;
    //[SerializeField] private AdapterDialogSystem _adapterDialogSystem;

    public static bool OpenLevels = false;


    private void OnEnable()
    {
        _screenMenu.gameObject.SetActive(!OpenLevels);
        _screenLevels.SetActive(OpenLevels);
    }

    private void OnDisable()
    {
        OpenLevels = false;
    }

    //[ContextMenu(nameof(ResetSave))]
    //public void ResetSave()
    //{
    //    //_adapterDialogSystem.Reset();
    //}
}
