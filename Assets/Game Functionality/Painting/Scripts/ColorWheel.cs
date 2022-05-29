using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }
public class ColorWheel : MonoBehaviour
{

    public XRRayInteractor rayInteractor;
    public GameObject cursor;
    [SerializeField] GameObject ColorCanvas;


    public TextMeshProUGUI debugText;
    [SerializeField] private GameObject _tip;
    [SerializeField] private GameObject _brushtip;
    Texture2D ColorTexture;
    public ColorEvent onColorpreview;

    public RaycastHit PointerPosition;

    RectTransform Rect;
    bool temp;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }
    //switch where Input.MousePosition with the controller point, might also have a designated contorller

    // Update is called once per frame
    void Update()
    {
        RaycastResult res;
        if (rayInteractor.TryGetCurrentUIRaycastResult(out res))
        {
            cursor.transform.position = res.worldPosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(Rect,cursor.transform.position))//check if the controller pointing with the board 
            {
                Vector2 delta;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, cursor.transform.position, null, out delta);
                float width = Rect.rect.width;
                float height = Rect.rect.height;
                delta += new Vector2(width * .5f, height * .5f);

                float x = Mathf.Clamp(delta.x / width, 0f, 1f);//from here
                float y = Mathf.Clamp(delta.y / height, 0f, 1f);//
                int texX = Mathf.RoundToInt(x * ColorTexture.width);
                int texY= Mathf.RoundToInt(y * ColorTexture.height);
                Color color = ColorTexture.GetPixel(texX, texY);//to here is the color logic
                //this will make lil johnny cube that color you point at
                onColorpreview?.Invoke(color);

                _tip.GetComponent<Renderer>().material.color = color;
                _brushtip.GetComponent<Renderer>().material.color = color;
            }
        }
    }
}
