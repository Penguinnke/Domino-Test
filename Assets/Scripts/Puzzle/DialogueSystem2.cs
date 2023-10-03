//Made by Penguinnke, do not use without permission
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueManager
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string dialogueText;
        public bool isSad;
        public bool isHappy;
        public bool isConfused;
        public bool isNeutral;
        public bool isAngry;
    }

    [System.Serializable]
    public class CharacterData
    {
        public string characterName;
        public GameObject characterObject;
        public Sprite sadSprite;
        public Sprite happySprite;
        public Sprite confusedSprite;
        public Sprite neutralSprite;
        public Sprite angrySprite;
    }

    [ExecuteInEditMode]
    public class DialogueSystem2 : MonoBehaviour
    {
        public TMPro.TMP_Text dialogueText;
        public TMPro.TMP_Text speakerNameText;
        public DialogueLine[] dialogueLines;
        public string sceneToLoad = "SceneName";
        public float typingSpeed = 0.05f; // Typing speed for dialogue animation

        public List<CharacterData> characters = new List<CharacterData>();

        private int currentLine = 0;
        private Coroutine typingCoroutine;
        private Dictionary<string, GameObject> characterObjects = new Dictionary<string, GameObject>();
        private Dictionary<string, SpriteRenderer> characterSpriteRenderers = new Dictionary<string, SpriteRenderer>();
        private Dictionary<string, Dictionary<string, Sprite>> characterSprites = new Dictionary<string, Dictionary<string, Sprite>>();

        private void Start()
        {
            foreach (CharacterData character in characters)
            {
                characterObjects.Add(character.characterName, character.characterObject);
                characterSpriteRenderers.Add(character.characterName, character.characterObject.GetComponent<SpriteRenderer>());

                Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
                sprites.Add("sadSprite", character.sadSprite);
                sprites.Add("happySprite", character.happySprite);
                sprites.Add("confusedSprite", character.confusedSprite);
                sprites.Add("neutralSprite", character.neutralSprite);
                sprites.Add("angrySprite", character.angrySprite);

                characterSprites.Add(character.characterName, sprites);
            }

            DisplayDialogueLine();
        }

        private void Update()
        {
            if (Application.isPlaying)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(0))
                    {
                        // Triple-click detected, jump to the end of the text
                        JumpToEndOfText();
                    }
                    else
                    {
                        // Single-click detected, skip to the end of the current line
                        StopTypingAnimation();
                        dialogueText.text = dialogueLines[currentLine].dialogueText;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // Enter key pressed, go to the next line
                    NextLine();
                }
            }
        }

        private void NextLine()
        {
            currentLine++;

            if (currentLine < dialogueLines.Length)
            {
                DisplayDialogueLine();
            }
            else
            {
                // Dialogue is finished
                EndDialogue();
            }
        }

        private void DisplayDialogueLine()
        {
            if (currentLine < dialogueLines.Length)
            {
                string dialogue = dialogueLines[currentLine].dialogueText;
                string speakerName = dialogueLines[currentLine].speakerName;

                speakerNameText.text = speakerName;

                StopTypingAnimation();
                typingCoroutine = StartCoroutine(TypeDialogue(dialogue));

                SetSpriteBasedOnDialogue(dialogueLines[currentLine]);
            }
            else
            {
                // Dialogue is finished
                EndDialogue();
            }
        }

        private IEnumerator TypeDialogue(string dialogue)
        {
            dialogueText.text = "";

            for (int i = 0; i < dialogue.Length; i++)
            {
                dialogueText.text += dialogue[i];

                if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(0))
                {
                    // Double-click detected, jump to the end of the text
                    JumpToEndOfText();
                    yield break;
                }

                yield return new WaitForSeconds(typingSpeed);
            }
        }

        private void JumpToEndOfText()
        {
            StopTypingAnimation();
            dialogueText.text = dialogueLines[currentLine].dialogueText;
        }

        private void StopTypingAnimation()
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
        }

        private void SetSpriteBasedOnDialogue(DialogueLine dialogueLine)
        {
            foreach (KeyValuePair<string, GameObject> characterObject in characterObjects)
            {
                characterObject.Value.SetActive(false);
            }

            if (!characterObjects.ContainsKey(dialogueLine.speakerName))
            {
                Debug.LogWarning("Character with the name '" + dialogueLine.speakerName + "' is not found.");
                return;
            }

            GameObject activeCharacter = characterObjects[dialogueLine.speakerName];
            SpriteRenderer activeSpriteRenderer = characterSpriteRenderers[dialogueLine.speakerName];

            if (characterSprites.TryGetValue(dialogueLine.speakerName, out Dictionary<string, Sprite> sprites))
            {
                activeSpriteRenderer.sprite = GetSpriteForDialogueLine(sprites, dialogueLine);
            
            }
               activeCharacter.SetActive(true);
    }

    private Sprite GetSpriteForDialogueLine(Dictionary<string, Sprite> sprites, DialogueLine dialogueLine)
    {
        if (dialogueLine.isSad && sprites.TryGetValue("sadSprite", out Sprite sprite))
        {
            return sprite;
        }
        else if (dialogueLine.isHappy && sprites.TryGetValue("happySprite", out sprite))
        {
            return sprite;
        }
        else if (dialogueLine.isConfused && sprites.TryGetValue("confusedSprite", out sprite))
        {
            return sprite;
        }
        else if (dialogueLine.isNeutral && sprites.TryGetValue("neutralSprite", out sprite))
        {
            return sprite;
        }
        else if (dialogueLine.isAngry && sprites.TryGetValue("angrySprite", out sprite))
        {
            return sprite;
        }

        return null;
    }

    private void EndDialogue()
    {
        Debug.Log("Dialogue ended");

        dialogueText.gameObject.SetActive(false);
        speakerNameText.gameObject.SetActive(false);

        //Deactivate all character objects
        foreach (GameObject characterObject in characterObjects.Values)
        {
            characterObject.SetActive(false);
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
}