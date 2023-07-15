using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TabControl;
    public GameObject DragDomino;
    public GameObject SpawnOtherDomino;
    public GameObject PutThemTogether;


    public bool isTabPressed;
    public bool isMouseButtonClicked;
    public bool IsCollided;
    public bool isEnterPressed;
    public bool SpawnOtherDominobool;

    private void Start() 
    {
        TabControl.SetActive(true);
        isTabPressed = false;
        isMouseButtonClicked = false;
        isEnterPressed = false;
        IsCollided = false;
        SpawnOtherDominobool = false;
        Debug.Log("TabControl");
    }

    private void Update()
    {
        if (!isTabPressed && !isMouseButtonClicked && !isEnterPressed && !IsCollided && Input.GetKeyDown(KeyCode.Tab))
        {
            TabControl.SetActive(false);
            DragDomino.SetActive(true);

            isTabPressed = true;
            isMouseButtonClicked = false;
            Debug.Log("DragDomino");
        } 

            if (!isMouseButtonClicked && isTabPressed && !isEnterPressed && !IsCollided && Input.GetMouseButtonDown(0))
            {
                DragDomino.SetActive(false);
                SpawnOtherDomino.SetActive(true);

                isMouseButtonClicked = true;
                isTabPressed = false;
                Debug.Log("SpawnOtherDomino"); 
                SpawnOtherDominobool = true;
            } 

        if (SpawnOtherDominobool && !isTabPressed && isMouseButtonClicked && Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnOtherDomino.SetActive(false);
            DragDomino.SetActive(false);
            PutThemTogether.SetActive(true);

            isMouseButtonClicked = true;
            isTabPressed = true;
            IsCollided = false;
            SpawnOtherDominobool = false;
            Debug.Log("PushthemtogetherDomino");
        }
}
}
