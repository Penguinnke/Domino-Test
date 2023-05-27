using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public DraggingDomino Dragging;
    public DraggingDomino Placed;

    private Vector2 _offset, _orginalPosition;

    // private GameObject targetTransform;
    // private Transform targetObject;

    public float stickDistance = 1f;

    public string _dominoTag = "Domino1";

    // Start is called before the first frame update
    void Start()
    {
        bool _ddReference = Dragging._dragging;
        bool _pReference = Placed._placed;
        // targetTransform = GameObject.FindGameObjectWithTag(_dominoTag);
        // targetObject = targetTransform.GetComponent<Transform>();
    }

    // private void Awake() {
    //     _orginalPosition = transform.position;
    // }


    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTag)
        {
            Debug.Log("Collision!");
            Dragging._dragging = false;
            Placed._placed = true;
            // CalculatePos();
            // _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        } else {
            Debug.Log("Not The Correct Block!");
            Dragging._dragging = false;
            Placed._placed = false;
        }
    }

    // private void CalculatePos()
    // {
    //     Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
    //     transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    // }

}
