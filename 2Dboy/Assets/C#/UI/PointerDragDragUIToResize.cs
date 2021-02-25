using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public class PointerDragDragUIToResize : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        [Header("UI體積最小值")]
        public Vector2 minSize = new Vector2(0, 0);
        [Header("UI體積最大值")]
        public Vector2 maxSize = new Vector2(500, 500);

        // UI 的 RectTransform
        RectTransform panelRectTransform;

        // 滑鼠按下的時候紀錄滑鼠位置以便計算UI大小
        Vector2 originalLocalPointerPosition;

        // 滑鼠按下的時候紀錄UI原来的大小
        Vector2 originalSizeDelta;

        // 判斷滑鼠的點擊位置，是左上還是右上（滑鼠向内drag是變小，向外drag是變大）
        bool isUpLeft = false;
        bool UImove = false;
        //讀取UI的大小
        Vector2 UIsize;
        Vector2 UIposition;
        void Start()
        {
            panelRectTransform = transform.GetComponent<RectTransform>();
            if (PlayerPrefs.HasKey("UIsizeX"))
            {
                UIsize.x = PlayerPrefs.GetFloat("UIsizeX");
                UIsize.y = PlayerPrefs.GetFloat("UIsizeY");
                panelRectTransform.sizeDelta = UIsize;
            }
            
            if (PlayerPrefs.HasKey("UImoveX"))
            {
                UIposition.x = PlayerPrefs.GetFloat("UImoveX");
                UIposition.y = PlayerPrefs.GetFloat("UImoveY");
                panelRectTransform.position = UIposition;
                UIposition.x = PlayerPrefs.GetFloat("UImoveAX");
                UIposition.y = PlayerPrefs.GetFloat("UImoveAY");
                panelRectTransform.anchoredPosition = UIposition;
            }
        }

    public void OnPointerDown(PointerEventData data)// 判斷鼠标按在UI的哪裡
    {
            // 紀錄按下滑鼠時UI的大小
            originalSizeDelta = panelRectTransform.sizeDelta;

            // 紀錄按下滑鼠的位置(要點擊的UI Rect,螢幕座標,攝影機,要將位置輸出給誰)
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);

        // 判斷滑鼠點擊位置在左上半部或右下半部(左下至右上對角線法)
        if ((originalLocalPointerPosition.x - originalLocalPointerPosition.y) < 0)
        {
            isUpLeft = true;
        }
        else
        {
            isUpLeft = false;
        }
    }

        public void OnDrag(PointerEventData data)// 拖拽調整大小計算
    {
            // UI 的安全檢查 如果UI的Rect沒被記錄到則跳出
            if (panelRectTransform == null)
                return;

            // 給滑鼠按下與拖曳時紀錄位置用
            Vector2 localPointerPosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out localPointerPosition);

        // 讓UI大小根據現在的大小去調整(不會每次調整都從0開始縮放)
        Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;

            // 點擊UI拖曳滑鼠放大縮小 （注意點擊在左上和右下的區别）
            Vector2 sizeDelta = originalSizeDelta + new Vector2(offsetToOriginal.x, -offsetToOriginal.y) * (isUpLeft == true ? -1 : 1);
            sizeDelta = new Vector2(//限制UI的調整最大與最小
                    Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
                    Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
            );

            //將計算完的值給UI 實現調整大小
            panelRectTransform.sizeDelta = sizeDelta;
        PlayerPrefs.SetFloat("UIsizeX", panelRectTransform.sizeDelta.x);
        PlayerPrefs.SetFloat("UIsizeY", panelRectTransform.sizeDelta.y);
        if (UImove)
        {   
            //讓UI跟者滑鼠移動並限制其移動
            var mousePosition = Input.mousePosition;
             var normalizedMousePosition = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);//讀取滑鼠位置
             if (normalizedMousePosition.x > panelRectTransform.anchorMin.x &&//將滑鼠的移動限制在UI內
                 normalizedMousePosition.x < panelRectTransform.anchorMax.x &&//限制的範圍為panelRectTransform所抓取到的範圍
                 normalizedMousePosition.y > panelRectTransform.anchorMin.y &&
                 normalizedMousePosition.y < panelRectTransform.anchorMax.y)
             {
                panelRectTransform.position = mousePosition;
             }
            UIposition = panelRectTransform.position;//讀取UI位置以便存檔
            PlayerPrefs.SetFloat("UImoveX", UIposition.x);
            PlayerPrefs.SetFloat("UImoveY", UIposition.y);
            UIposition = panelRectTransform.anchoredPosition;//UI還要再多存一個錨點座標
            PlayerPrefs.SetFloat("UImoveAX", UIposition.x);
            PlayerPrefs.SetFloat("UImoveAY", UIposition.y);
        }
    }


    }