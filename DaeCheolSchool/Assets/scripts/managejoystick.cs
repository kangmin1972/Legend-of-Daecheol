using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class managejoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
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
        }

        if (posInput.magnitude > 1.0f)
        {
            posInput = posInput.normalized;
        }

        joystick.rectTransform.anchoredPosition = new Vector2(
            posInput.x * (joystickbg.rectTransform.sizeDelta.x / 2),
            posInput.y * (joystickbg.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
