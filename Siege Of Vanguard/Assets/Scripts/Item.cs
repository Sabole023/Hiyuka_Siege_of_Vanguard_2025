using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public ItemScriptableObject item;

    private void Awake()
    {
        spriteRenderer.sprite = item.sprite;
    }
}
