using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawn : MonoBehaviour
{
    public GameObject dominoPrefab1; // Prefab of the first domino object
    public GameObject dominoPrefab2; // Prefab of the second domino object
    public GameObject dominoPrefab3; // Prefab of the third domino object

    public float minX = -10f; // Minimum X-axis value
    public float maxX = 10f; // Maximum X-axis value
    public float minY = -5f; // Minimum Y-axis value
    public float maxY = 5f; // Maximum Y-axis value

    private int tabCount = 0; // Counter for Tab key presses

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ObjectCopier();
        }
    }

    public void ObjectCopier()
    {
        if (tabCount < 3)
        {
            GameObject dominoObject;

            if (tabCount == 0)
            {
                dominoObject = Instantiate(dominoPrefab1);
            }
            else if (tabCount == 1)
            {
                dominoObject = Instantiate(dominoPrefab2);
            }
            else
            {
                dominoObject = Instantiate(dominoPrefab3);
            }

            dominoObject.SetActive(true);
            dominoObject.name = "Domino " + (tabCount + 1);

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            float zPos = dominoObject.transform.position.z;
            dominoObject.transform.position = new Vector3(randomX, randomY, zPos);

            tabCount++;
        }
    }
}