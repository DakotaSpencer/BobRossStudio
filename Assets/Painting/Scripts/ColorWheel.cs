using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorWheel2 : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    //[SerializeField] private Transform _tip;
    RectTransform Rect;
    bool temp;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
    }

    private void UpdateColor()
    {
        Vector2 delta;
        /*this will be the state of wher ethe contoller is for no it will be mouse */
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);
        Color color = Color.HSVToRGB(0.222f, 0.2f, 021f);//numbers there are temporary
                                                         //_tip.GetComponent<Renderer>().material.color = color;

    }


    // Update is called once per frame
    void Update()
    {
        if (temp == true)//check if the controller pointing with the board 
        {
            Vector2 delta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);
            float width = Rect.rect.width;
            float height = Rect.rect.height;
            delta += new Vector2(width * .5f, height * .5f);

            float x = Mathf.Clamp(delta.x / width, 0f, 1f);//check teh 
            float y = Mathf.Clamp(delta.y / height, 0f, 1f);
        }


    }
}
