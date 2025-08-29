using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BingoFieldButton : MonoBehaviour
{
    public Button fieldButton;
    public TextMeshProUGUI buttonLabel;
    public Vector3 fieldPosition;
    public bool clicked;

    public void LoadButton(string text)
    {
        buttonLabel.text = text;
        fieldButton.onClick.AddListener(OnClick);
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
    }
}
