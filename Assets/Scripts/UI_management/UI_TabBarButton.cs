using UnityEngine;

public class UI_TabBarButton : MonoBehaviour
{
    public UI_TabBar TabBar;
    public UI_View AssignedView;

    /// <summary>
    /// Use in UI tab buttons
    /// </summary>
    public void ButtonPressed()
    {
        TabBar.GetButtonPress(this);
    }
}
