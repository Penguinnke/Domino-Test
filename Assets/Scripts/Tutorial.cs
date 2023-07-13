using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TabControl;
    public GameObject DragDomino;
    public GameObject SpawnOtherDomino;
    public GameObject PutThemTogether;

    public GameObject SpawnOtherDominoAgain;
    public GameObject TurnDegrees;

    public GameObject TemporalArchonIntro;
    public GameObject TemporalArchonPush;

    public GameObject MoveCamera;
    public GameObject ControlScreen;
    public GameObject MoveToGame;

    public GameObject TemporalArchonObject;

    public bool isTabPressed;
    public bool isMouseButtonClicked;
    public bool IsCollided;
    public bool isEnterPressed;

    public GameObject Domino1;
    public GameObject Domino2;
    
    private void Start() 
    {
        TabControl.SetActive(true);
        isTabPressed = false;
        isMouseButtonClicked = false;
        isEnterPressed = false;
        IsCollided = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TabControl.SetActive(false);
            DragDomino.SetActive(true);

            isTabPressed = true;
            isMouseButtonClicked = false;
        } 
        
        if (isTabPressed && Input.GetMouseButtonDown(0))
        {
            DragDomino.SetActive(false);
            SpawnOtherDomino.SetActive(true);

            isMouseButtonClicked = true;
            isTabPressed = false;
        } 
        
        if (isMouseButtonClicked && Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnOtherDomino.SetActive(false);
            PutThemTogether.SetActive(true);

            isMouseButtonClicked = false;
            isTabPressed = true;
            IsCollided = false;
        } 
        
        if (IsCollided)
       {
            PutThemTogether.SetActive(false);
            SpawnOtherDominoAgain.SetActive(true);

            isTabPressed = false;
            IsCollided = false;
            isMouseButtonClicked = false;
       } 
       
       if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnOtherDominoAgain.SetActive(false);
            TurnDegrees.SetActive(true);

            isTabPressed = true;
            IsCollided = false;
            isMouseButtonClicked = false;
        } 
        
        if (Input.GetKeyDown(KeyCode.Return) && Input.GetMouseButtonDown(0))
        {
            TurnDegrees.SetActive(false);
            TemporalArchonIntro.SetActive(true);
            TemporalArchonObject.SetActive(true);

            isMouseButtonClicked = true;
            isEnterPressed = true;
            isTabPressed = false;
        } 
        
        if(TemporalArchonIntro.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TemporalArchonIntro.SetActive(false);
                TemporalArchonPush.SetActive(true);

                isMouseButtonClicked = false;
                isEnterPressed = false;
            }
        } 
        
        if(MoveCamera.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveCamera.SetActive(false);
                ControlScreen.SetActive(true);
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ControlScreen.SetActive(false);
            MoveToGame.SetActive(true);
        }
      
    }

        void OnCollisionEnter(Collision collision)
       {
            if (collision.gameObject == Domino1 && collision.gameObject == Domino2)
            {
                IsCollided = true;
                isTabPressed = false;
                isMouseButtonClicked = false;
            }

            if (collision.gameObject == TemporalArchonObject)
            {
                MoveCamera.SetActive(true);
            }
       }
}
