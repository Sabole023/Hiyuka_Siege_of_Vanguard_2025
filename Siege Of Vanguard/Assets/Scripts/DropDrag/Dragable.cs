using System;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    #region Variables

    [Header("References")]
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private Transform DefaultPosition;

    [Header("Attributes")]
    private bool isPressed = false;
    private bool isCollided = false;
    private GameObject GOCollided;
    [SerializeField] private string tagToCollide;

    [SerializeField] private float speed = 40f;

    [SerializeField]private float timeWaitToReturn = 0.5f;
    private float timeFromLastPress = 0f;

    #endregion

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        //Begin Drag
        isPressed = true;
    }
    private void OnMouseUp()
    {
        //End Drag
        isPressed = false;
    }

    private void Update()
    {
        //On Drag
        if(isPressed)
        {
            Draging();

            return;
        }

        //Handle collision with other objects
        if(isCollided && GOCollided != null)
        {
            if(HandleCollision())
            {
                return;
            }
        }

        //If there is no default position
        if(DefaultPosition == null)
        {
            return;
        }

        //Move to default position after few seconds
        if(timeFromLastPress >= timeWaitToReturn)
        {
            transform.position = Vector2.MoveTowards(transform.position, DefaultPosition.position, speed * Time.deltaTime);
        }
        else
        {
            //Prevent collision with other objects
            col.enabled = false;
        }

        if(Vector2.Distance(transform.position, DefaultPosition.position) < 0.1f)
        {
            col.enabled = true;
        }

        timeFromLastPress += Time.deltaTime;
    }

    private void Draging()
    {
        timeFromLastPress = 0f;

        FollowMouse();
    }

    private bool HandleCollision()
    {
        //Check if the object is an item
        Item equipment = gameObject.GetComponent<Item>();
        if(equipment != null && ItemCollidedNpc(equipment))
        {
            return true;
        }

        return false;
    }

    private bool ItemCollidedNpc(Item e)
    {
        NPCEquipment NPCe = GOCollided.GetComponent<NPCEquipment>();
        if(NPCe != null && NPCe.AddEquipment(e))
        {
            EquipRespawnManager.main.UpdateCurrentEquipment(-1);
            Destroy(gameObject);

            return true;
        }

        return false;
    }

    private void FollowMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float halfCameraHeight = Camera.main.orthographicSize;
        float HalfCameraWidth = halfCameraHeight * Camera.main.aspect;
            
        mousePos.x = Mathf.Clamp(mousePos.x, -HalfCameraWidth, HalfCameraWidth);
        mousePos.y = Mathf.Clamp(mousePos.y, -halfCameraHeight, halfCameraHeight);
            
        transform.position = mousePos;
    }

    public void SetDefaultPosition(Transform position)
    {
        DefaultPosition = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(tagToCollide != "" && collision.gameObject.CompareTag(tagToCollide))
        {
            GOCollided = collision.gameObject;
            isCollided = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        GOCollided = null;
        isCollided = false;
    }
}
