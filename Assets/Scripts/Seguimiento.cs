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

public class Seguimiento : MonoBehaviour
{
    public GameObject personaje;
    public GameObject background;
    public GameObject colissionLeft;
    public GameObject colissionRight;
    public GameObject colissionBottom;
    public GameObject coinDeleter;
    public GameObject topColission;

    float timer = 0;
    public static float mov;
    public Vector2 minCamP, maxCamP;
    public static float endOfCamera;
    public static float posActualCameraX;
    // Start is called before the first frame update
    void Start()
    {
        mov = 1.5f;
        endOfCamera = 8.84f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            endOfCamera = transform.position.x + 8.84f;
            float x = transform.position.x + mov * Time.deltaTime;
            float y = transform.position.y;
            transform.position = new Vector3(x, y, transform.position.z);
            background.transform.position = new Vector3(x, y, background.transform.position.z);

            float xColLeft = colissionLeft.transform.position.x + mov * Time.deltaTime;
            float yColLeft = colissionLeft.transform.position.y;
            colissionLeft.transform.position = new Vector3(xColLeft, yColLeft, colissionLeft.transform.position.z);

            float xColRight = colissionRight.transform.position.x + mov * Time.deltaTime;
            float yColRight = colissionRight.transform.position.y;
            colissionRight.transform.position = new Vector3(xColRight, yColRight, colissionRight.transform.position.z);

            float xColBottom = colissionBottom.transform.position.x + mov * Time.deltaTime;
            float yColBottom = colissionBottom.transform.position.y;
            colissionBottom.transform.position = new Vector3(xColBottom, yColBottom, colissionBottom.transform.position.z);

            float xCoinDel = coinDeleter.transform.position.x + mov * Time.deltaTime;
            float yCoinDel = coinDeleter.transform.position.y;
            coinDeleter.transform.position = new Vector3(xCoinDel, yCoinDel, coinDeleter.transform.position.z);

            float xTop = topColission.transform.position.x + mov * Time.deltaTime;
            float yTop = topColission.transform.position.y;
            topColission.transform.position = new Vector3(xTop, yTop, topColission.transform.position.z);
        }
        posActualCameraX = transform.position.x;
    }
}
