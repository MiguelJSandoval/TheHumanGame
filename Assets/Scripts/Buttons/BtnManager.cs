/*
 * Copyright (c) 2021, DevMJS. All rights reserved.
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * This code is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This code is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this code.  If not, see <https://www.gnu.org/licenses/>.
 *
 * Please contact DevMJS on contact.devmjs@gmail.com if you need
 * additional information or have any questions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject canvasInfo;
    public GameObject canvasHelp;
    public GameObject dlgGameOver;
    public GameObject btnSound;
    public GameObject dlgPause;
    public static bool banEndGame = false;

    public void LoadPause()
    {
        if (!banEndGame)
        {
            Time.timeScale = 0;
            dlgPause.GetComponent<Canvas>().enabled = true;
        }
    }

    public void DismissPause()
    {
        Time.timeScale = 1f;
        dlgPause.GetComponent<Canvas>().enabled = false;
    }

    public void LoadMenuFromPause()
    {
        Time.timeScale = 1f;
        Destroy(Instantiate(btnSound), 0.5f);
        StartCoroutine(LoadMenuAndGame(1));
    }

    public void LoadGame()
    {
        banEndGame = false;
        Destroy(Instantiate(btnSound), 0.5f);
        StartCoroutine(LoadMenuAndGame(2));
    }

    public void LoadMenu()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        StartCoroutine(LoadMenuAndGame(1));
    }

    IEnumerator LoadMenuAndGame(int i)
    {
        yield return new WaitForSeconds(0.3f);
        switch (i)
        {
            case 1:
                Destroy(ScoreManager.scoreManager.gameObject);
                SceneManager.LoadScene("MainMenu");
                break;
            case 2:
                SceneManager.LoadScene("Level1");
                break;
            case 3:
                Application.Quit();
                break;
        }
    }

    public void ExitGame()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        StartCoroutine(LoadMenuAndGame(3));
    }

    public void LoadInfo()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        if (canvasInfo == null)
        {
            Instantiate(canvasInfo);
            canvasInfo.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            canvasInfo.GetComponent<Canvas>().enabled = true;
        }
    }

    public void DismissInfo()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        canvasInfo.GetComponent<Canvas>().enabled = false;
    }

    public void LoadHelp()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        if (canvasInfo == null)
        {
            Instantiate(canvasHelp);
            canvasHelp.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            canvasHelp.GetComponent<Canvas>().enabled = true;
        }
    }

    public void DismissHelp()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        canvasHelp.GetComponent<Canvas>().enabled = false;
    }

    public void DismissGameOver()
    {
        Destroy(Instantiate(btnSound), 0.5f);
        dlgGameOver.GetComponent<Canvas>().enabled = false;
        LoadMenu();
    }
}
