using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickupClip, _dropClip;

    private bool _dragging, _placed;
    private Vector2 _offset, _orginalPosition;
    
    private PuzzleSlot _slot;

    public void Init(PuzzleSlot slot){
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }

    private void Awake() {
        _orginalPosition = transform.position;
    }

    private void Update() {
        if(_placed) return;
        if(!_dragging) return;
        
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown() 
    {
        _dragging = true;
        _source.PlayOneShot(_pickupClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() {
        if(Vector2.Distance(transform.position, _slot.transform.position) < 3)
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;
        } else {
            transform.position = _orginalPosition;
            _source.PlayOneShot(_dropClip);
            _dragging = false;

        }
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
