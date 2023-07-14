using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TutorialPart2 : MonoBehaviour
{
    public GameObject PutThemTogether;
    public GameObject SpawnOtherDominoAgain;
    public GameObject TurnDegrees;
    public GameObject TemporalArchonIntro;
    public GameObject TemporalArchonPush;
    public GameObject TemporalArchonObject;
    public GameObject Domino3;
    public string TutorialPart2Scene;

    public bool collisiontut;

    private void Update() {
        if (Domino3.activeInHierarchy)
        {
            SpawnOtherDominoAgain.SetActive(false);
            TurnDegrees.SetActive(true);
        }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                TemporalArchonIntro.SetActive(true);
                TemporalArchonObject.SetActive(true);
            } 

            if(TemporalArchonObject.activeInHierarchy)
            {
                TurnDegrees.SetActive(false);

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    TemporalArchonIntro.SetActive(false);
                    SceneManager.LoadScene(TutorialPart2Scene);
                    //TemporalArchonPush.SetActive(true);
                }
            }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Number6"))
        {
            Debug.Log("collision for tutorial");
            PutThemTogether.SetActive(false);
            SpawnOtherDominoAgain.SetActive(true);
            collisiontut = true;
        }
    }
}
