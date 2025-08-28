using UnityEngine;

public class UI_TabBar : MonoBehaviour
{
    public UI_TabBarButton[] TabBar_Buttons;
    public UI_View currentTab;

    private void Start() {
        currentTab = TabBar_Buttons[0].AssignedView;
        currentTab.UI_animator.SetBool("active", true);
    }

    public void GetButtonPress(UI_TabBarButton button)
    {
        if (button != currentTab)
        {
            SwitchTab(button.AssignedView);
        }
    }
    
    public void SwitchTab(UI_View next)
    {
        if (currentTab != next)
        {
            currentTab.UI_animator.SetBool("active", false);
            next.UI_animator.SetBool("active", true);
            currentTab = next;
        }
    }
}