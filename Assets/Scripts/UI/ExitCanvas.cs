using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitCanvas : MonoBehaviour
{
    public Button btn_cancel, btn_confirm;

    private void Start()
    {
        btn_cancel.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        btn_confirm.onClick.AddListener(() =>
        {
            //Scene current = SceneManager.GetActiveScene();
            //SceneManager.UnloadSceneAsync(current);
            SceneManager.LoadScene(0);
        });
    }
}
