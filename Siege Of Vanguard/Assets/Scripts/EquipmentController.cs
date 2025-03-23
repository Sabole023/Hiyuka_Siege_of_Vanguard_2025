using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private Transform DefaultPosition;
    [SerializeField]private Equipment itself;
    private NPC npcInteracting;

    [Header("Attributes")]
    [SerializeField] private float speed = 40f;

    [SerializeField]private float timeWaitToReturn = 0.5f;
    private float timeFromLastPress = 0f;

    private bool isPressed = false;
    private bool isCollideWithNPC = false;

    void OnMouseDown()
    {
        isPressed = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            timeFromLastPress = 0f;

            FollowMouse();

            return;
        }

        if(isCollideWithNPC && npcInteracting !=null && itself != null)
        {
            if(npcInteracting.AddEquipment(itself))
            {   
                EquipRespawnManager.main.UpdateCurrentEquipment(-1);
                gameObject.SetActive(false);
                Destroy(gameObject);

                return;
            }
        }

        if(timeFromLastPress >= timeWaitToReturn)
        {
            transform.position = Vector2.MoveTowards(transform.position, DefaultPosition.position, speed * Time.deltaTime);
        }
        else
        {
            col.enabled = false;
        }

        if(Vector2.Distance(transform.position, DefaultPosition.position) < 0.1f)
        {
            col.enabled = true;
        }

        timeFromLastPress += Time.deltaTime;
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
        npcInteracting = collision.gameObject.GetComponent<NPC>();
        isCollideWithNPC = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        npcInteracting = null;
        isCollideWithNPC = false;
    }
}
