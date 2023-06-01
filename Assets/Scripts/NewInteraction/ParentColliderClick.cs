using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentColliderClick : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayer; // ссылка на слой "Clickable"

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, clickableLayer);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Interaction>().OnMouseDownCustom();
            }
        }
    }
}
