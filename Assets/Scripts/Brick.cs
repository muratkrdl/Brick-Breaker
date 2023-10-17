using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum ColorEnum
{
    blue,
    green,
    yellow,
    orange,
    red
}

public class Brick : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite blueSprite;
    [SerializeField] Sprite greenSprite;
    [SerializeField] Sprite yellowSprite;
    [SerializeField] Sprite orangeSprite;
    [SerializeField] Sprite redSprite;

    [SerializeField] ColorEnum state;

    void OnCollisionEnter2D(Collision2D other) 
    {
        switch(state)
        {
            case ColorEnum.red:
                spriteRenderer.sprite = orangeSprite;
                state = ColorEnum.orange;
                GameManager.Instance.IncreaseScore(50);
                break;
            case ColorEnum.orange:
                spriteRenderer.sprite = yellowSprite;
                state = ColorEnum.yellow;
                GameManager.Instance.IncreaseScore(40);
                break;
            case ColorEnum.yellow:
                spriteRenderer.sprite = greenSprite;
                state = ColorEnum.green;
                GameManager.Instance.IncreaseScore(30);
                break;
            case ColorEnum.green:
                spriteRenderer.sprite = blueSprite;
                state = ColorEnum.blue;
                GameManager.Instance.IncreaseScore(20);
                break;
            case ColorEnum.blue:
                this.gameObject.GetComponent<Brick>().enabled = false;
                this.gameObject.SetActive(false);
                GameManager.Instance.IncreaseScore(10);
                break;
        }
    }

}
