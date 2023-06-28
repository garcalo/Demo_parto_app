using UnityEngine;

public class ToggleModelVisibility : MonoBehaviour
{
    public GameObject model;

    public void ToggleVisibility()
    {
        model.SetActive(!model.activeSelf);
    }
}
