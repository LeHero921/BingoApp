using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BingoFieldButton : MonoBehaviour
{
    public Button fieldButton;
    public TextMeshProUGUI buttonLabel;
    public Vector3 fieldPosition;
    public bool clicked;

    public Animator animator;

    public void LoadButton(string text)
    {
        Debug.Log("Is button " + buttonLabel.text + " clicked? : " + clicked);
        buttonLabel.text = text;
        fieldButton.onClick.AddListener(OnClick);
        animator.SetBool("complete", clicked);
    }

    public void OnClick()
    {
        if (clicked == false)
        {
            clicked = true;
        }else
        {
            clicked = false;
        }
        animator.SetBool("complete", clicked);
        Actions.OnBingoFieldButtonClicked();
    }
}
