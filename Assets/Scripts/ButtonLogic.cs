using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    public void toMain() {
        SceneManager.LoadSceneAsync(0);
    }

    public void toEasy() {
        SceneManager.LoadSceneAsync(1);
    }

    public void exitGame() {
        Application.Quit();
    }

}
