﻿/*
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

public class SoundMenuController : MonoBehaviour
{
    public GameObject musicMenu;
    public static bool canPlay = true;
    Object o;
    void Start()
    {
        if (canPlay)
        {
            o = Instantiate(musicMenu);
        }
    }

    public void StopAudio()
    {
        Destroy(o);
        canPlay = false;
    }

    public void PlayAudio()
    {
        canPlay = true;
        if (o == null)
        {
            o = Instantiate(musicMenu);
        }  
    }
}
