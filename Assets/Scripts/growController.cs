using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class growController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Animator barAnim;
    public SpriteRenderer barSprite;
    public Sprite[] sprites;
    int imgNum = 0;
    bool canClick = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

    }
    private void OnMouseUp()
    {
        if (spriteRenderer != null && canClick)
        {
            imgNum++;
            if (imgNum >= sprites.Length)
            {
                spriteRenderer.enabled = false;
                barSprite.enabled = false;
                barAnim.enabled = false;
            }
            else
            {
                canClick = false;
                StartCoroutine(Grow());
                barSprite.enabled = true;
                barAnim.enabled = true;
            }
        }
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(5);
        spriteRenderer.sprite = sprites[imgNum];
        canClick = true;
        barSprite.enabled = false;
        barAnim.enabled = false;
    }
}
