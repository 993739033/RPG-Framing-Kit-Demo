using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Actions/New Game" )]
public class ActionNewGame : ScriptableObject
{
    //save index
    [SerializeField]
    private IntVariable saveSlot;
    
    //firstScene: farm
    [SerializeField]
    private StringVariable firstScene;
    
    //player :Core
    [SerializeField]
    private StringVariable playerScene;

    public void Execute()
    {
        int availableSaveSlot = SaveUtility.GetAvailableSaveSlot();

        saveSlot.Value = availableSaveSlot;

        SceneManager.LoadScene(firstScene.Value);
        SceneManager.LoadScene(playerScene.Value, LoadSceneMode.Additive);
    }
}
