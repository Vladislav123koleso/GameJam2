using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Card
{
    public Sprite frontSprite; // Спрайт лицевой стороны карты
    //public Color frontColor;
    public bool isMatched; // Флаг, указывающий, совпала ли карта с другой
    public int matchesCount; // Счетчик совпадений с другими картами

    /*public Card(Sprite frontSprite)
    {
        
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }*/
    /*public Card(Color frontColor)
    {
        //this.frontSprite = frontSprite;
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }*/
    public Card(Sprite frontSprite)
    {
        
        this.frontSprite = frontSprite;
        this.isMatched = false;
        this.matchesCount = 0;
    }


}




public class cardLogic : MonoBehaviour
{
    public Card card; // Ссылка на объект карты


    public Sprite backSprite; // Спрайт рубашки
    public SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer
    //private Image cardImage;

    public Color backColor = Color.black; // Цвет для рубашки карты

    private bool isFlipped = false; // Флаг, указывающий, перевернута ли карта
    private bool isClickable = true; // Флаг, указывающий, можно ли кликнуть на карту
    private CardManager cardManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cardManager = FindObjectOfType<CardManager>();
        /*cardImage = GetComponent<Image>();
        if(cardImage == null)
        {
            Debug.LogError("Image component not found on the card!");
        }*/
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down event detected on card.");

        // Проверяем, можно ли кликнуть на карту и перевернуть её
        if (!isClickable || cardManager.CountFlippedCards() >= 2 || isFlipped)
        {
            return;
        }

        FlipCard();
        cardManager.AddFlippedCard(this);
    }

    // Метод для переворота карты
    public void FlipCard()
    {
        if (!isFlipped)
        {
            spriteRenderer.sprite = card.frontSprite; // Показываем лицевую сторону
            Debug.Log("Card flipped to front.");
        }
        else
        {
            spriteRenderer.sprite = backSprite; // Показываем рубашку
            Debug.Log("Card flipped to back.");
        }

        isFlipped = !isFlipped;
    }

    // Метод для блокировки кликов на карту
    public void SetClickable(bool clickable)
    {
        isClickable = clickable;
        Debug.Log("Clickable set to: " + clickable);
    }

}
