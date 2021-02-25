using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SizePanelSetting : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [Header("UI體積最小值")]
    public Vector2 minSize = new Vector2(0, 0);
    [Header("UI體積最大值")]
    public Vector2 maxSize = new Vector2(500, 500);


    RectTransform panelRectTransform;
    Vector2 originalLocalPointerPosition;
    Vector2 originalSizeDelta;
    bool isUpLeft = false;
    bool UImove = false;
    bool UIresize = false;
    Vector2 UIsize;
    Vector2 UIposition;
    void Start()
    {
        panelRectTransform = transform.GetComponent<RectTransform>();
        if (PlayerPrefs.HasKey("SizePanelSettingX"))
        {
            UIsize.x = PlayerPrefs.GetFloat("SizePanelSettingX");
            UIsize.y = PlayerPrefs.GetFloat("SizePanelSettingY");
            panelRectTransform.sizeDelta = UIsize;
        }
        if (PlayerPrefs.HasKey("MovePanelSettingX"))
        {
            UIposition.x = PlayerPrefs.GetFloat("MovePanelSettingX");
            UIposition.y = PlayerPrefs.GetFloat("MovePanelSettingY");
            panelRectTransform.position = UIposition;
            UIposition.x = PlayerPrefs.GetFloat("MovePanelSettingAX");
            UIposition.y = PlayerPrefs.GetFloat("MovePanelSettingAY");
            panelRectTransform.anchoredPosition = UIposition;
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (UIresize)
        {
            originalSizeDelta = panelRectTransform.sizeDelta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
            if ((originalLocalPointerPosition.x - originalLocalPointerPosition.y) < 0)
            {
                isUpLeft = true;
            }
            else
            {
                isUpLeft = false;
            }
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (UIresize)
        {
            if (panelRectTransform == null)
                return;
            Vector2 localPointerPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out localPointerPosition);
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            Vector2 sizeDelta = originalSizeDelta + new Vector2(offsetToOriginal.x, -offsetToOriginal.y) * (isUpLeft == true ? -1 : 1);
            sizeDelta = new Vector2(
                    Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
                    Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
            );
            panelRectTransform.sizeDelta = sizeDelta;
            PlayerPrefs.SetFloat("SizePanelSettingX", panelRectTransform.sizeDelta.x);
            PlayerPrefs.SetFloat("SizePanelSettingY", panelRectTransform.sizeDelta.y);
        }
        if (UImove)
        {
            var mousePosition = Input.mousePosition;
            var normalizedMousePosition = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);
            if (normalizedMousePosition.x > panelRectTransform.anchorMin.x &&
                normalizedMousePosition.x < panelRectTransform.anchorMax.x &&
                normalizedMousePosition.y > panelRectTransform.anchorMin.y &&
                normalizedMousePosition.y < panelRectTransform.anchorMax.y)
            {
                transform.position = mousePosition;
                UIposition = panelRectTransform.position;
                PlayerPrefs.SetFloat("MovePanelSettingX", UIposition.x);
                PlayerPrefs.SetFloat("MovePanelSettingY", UIposition.y);
                UIposition = panelRectTransform.anchoredPosition;
                PlayerPrefs.SetFloat("MovePanelSettingAX", UIposition.x);
                PlayerPrefs.SetFloat("MovePanelSettingAY", UIposition.y);
            }
        }
    }
    public void isUIresize()
    {
        UIresize = true;
    }
    public void noUIresize()
    {
        UIresize = false;
    }
    public void isUImove()
    {
        UImove = true;
    }
    public void noUImove()
    {
        UImove = false;
    }
}