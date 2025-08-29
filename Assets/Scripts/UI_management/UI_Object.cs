using UnityEngine;

public class UI_Object : MonoBehaviour
{
    public Animator UI_animator;
    public bool DefaultOpen;

    private void Start() {
        if (DefaultOpen == true)
        {
            OpenUI();
        }
    }

    public void OpenUI()
    {
        UI_animator.SetBool("active", true);
    }
    public void CloseUI()
    {
        UI_animator.SetBool("active", false);
    }
}
