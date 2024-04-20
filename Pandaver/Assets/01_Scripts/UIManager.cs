using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject overPanel;

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
	}

	public void GameOver()
    {
        overPanel.transform.DOLocalMoveY(0, 1f);
    }

    public void SceneChange(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
