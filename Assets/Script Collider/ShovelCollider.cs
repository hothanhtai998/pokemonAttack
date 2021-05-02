using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCollider : MonoBehaviour
{
    private Vector2 screenPoint;
    private Vector2 startPosition;
    private Vector2 dropPlacePosition;
    private bool isCorrectPlace = false;

    void Start()
    {
        dropPlacePosition = this.gameObject.transform.position;
    }

    void OnMouseDown()
    {
        startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseUp()
    {
        if (isCorrectPlace == true)
        {
            this.gameObject.transform.position = dropPlacePosition;
        }
        else
        {
            this.gameObject.transform.position = startPosition;
        }
    }

    void OnMouseDrag()
    {
        //Debug.Log("Drag");
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        this.transform.position = curPosition;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            Destroy(otherObject);
            isCorrectPlace = true;
            FindObjectOfType<StarDisplay>().AddStars((FindObjectOfType<Defender>().GetStarsCost()) / 2);
        }
    }
}
