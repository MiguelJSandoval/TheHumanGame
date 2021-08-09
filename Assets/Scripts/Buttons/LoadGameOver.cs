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

public class LoadGameOver : MonoBehaviour
{
    public static GameObject dlgGameOver;
    public GameObject dlgPause;
    // Start is called before the first frame update
    void Start()
    {
        dlgGameOver = GameObject.Find("CanvasGameOver");
        dlgGameOver.GetComponent<Canvas>().enabled = false;
        dlgPause.GetComponent<Canvas>().enabled = false;
    }


    public static void ShowDlg()
    {
        BtnManager.banEndGame = true;
        dlgGameOver.GetComponent<Canvas>().enabled = true;
    }
}
