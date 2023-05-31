using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public DraggingDomino Dragging;
    public DraggingDomino Placed;

    private Vector2 _offset, _orginalPosition;

    public float stickDistance = 1f;

    public string _dominoTag = "Domino1";

    // Start is called before the first frame update
    void Start()
    {
        bool _ddReference = Dragging._dragging;
        bool _pReference = Placed._placed;
    }


    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTag)
        {
            Debug.Log("Collision!");
            Dragging._dragging = false;
            Placed._placed = true;
        } else {
            Placed._placed = true;

            Debug.Log("Not The Correct Block!");
            Dragging._dragging = false;
            Placed._placed = false;

        }
    }
}
