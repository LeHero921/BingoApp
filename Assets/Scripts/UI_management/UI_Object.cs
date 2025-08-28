using UnityEngine;

public class UI_Object : MonoBehaviour
{
    public Animator UI_animator;

    public void OpenUI()
    {
        UI_animator.SetBool("active", true);
    }
    public void CloseUI()
    {
        UI_animator.SetBool("active", false);
    }
}
