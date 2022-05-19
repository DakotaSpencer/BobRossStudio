using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }
public class ColorWheel : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    //[SerializeField] private Transform _tip;
    Texture2D ColorTexture;
    public ColorEvent onColorpreview;

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

        if (RectTransformUtility.RectangleContainsScreenPoint(Rect,Input.mousePosition))//check if the controller pointing with the board 
        {
            Vector2 delta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);
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
            
            if (temp == true) //check for controller input 
            {
            
            }
        }


    }
}
