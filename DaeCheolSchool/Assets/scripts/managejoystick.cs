using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class managejoystick : MonoBehaviour, IDragHandler
{
    public Image joystickbg;
    public Image joystick;
    private Vector2 posInput;

    // Start is called before the first frame update
    void Start()
    {
        joystickbg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickbg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput))
        {
            posInput.x = posInput.x / (joystickbg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (joystickbg.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());
        }

        if (posInput.magnitude > 1.0f)
        {
            posInput = posInput.normalized;
        }

        joystick.rectTransform.anchoredPosition = new Vector2(
            posInput.x * (joystickbg.rectTransform.sizeDelta.x / 4),
            posInput.y * (joystickbg.rectTransform.sizeDelta.y / 4));
    }
}
