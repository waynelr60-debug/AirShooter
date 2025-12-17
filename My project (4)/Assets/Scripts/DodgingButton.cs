using UnityEngine;

public class DodgingButton : MonoBehaviour
{
    public float dodgeDistance = 100f;   // jarak sensor dodge
    public RectTransform canvasRect;     // canvas

    private RectTransform buttonRect;

    void Start()
    {
        buttonRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            Input.mousePosition,
            null,
            out mousePos
        );

        float distance = Vector2.Distance(buttonRect.anchoredPosition, mousePos);

        if (distance < dodgeDistance)
        {
            Dodge();
        }
    }

    void Dodge()
    {
        float x = Random.Range(
            canvasRect.rect.xMin + buttonRect.rect.width / 2,
            canvasRect.rect.xMax - buttonRect.rect.width / 2
        );

        float y = Random.Range(
            canvasRect.rect.yMin + buttonRect.rect.height / 2,
            canvasRect.rect.yMax - buttonRect.rect.height / 2
        );

        buttonRect.anchoredPosition = new Vector2(x, y);
    }
}
