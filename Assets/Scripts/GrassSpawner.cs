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

public class GrassSpawner : MonoBehaviour
{
    public GameObject grassPrefab;
    public GameObject coinPrefab;
    public GameObject bombPrefab;

    float timer;
    float pivot = -1.925f;
    float tamCell = 1.155f;
    float[] positionsY = {-3.909f, -0.75f, 1.44f};
    float[] positionsCoinY = {-1.51f, 1.92f, 3.76f};
    float actualEndOfTiles;

    public static bool canGenerate;
    bool[] probability = {true, true, false, false, false, false, 
        false, true, false, false, true, true, false, true, true, false, false, false};
    bool[] probabilityBombs = {false, false, false, false, false, false,
        false, true, false, false, true, true, false, false, true, false, false, false};

    readonly ArrayList positionsTiles = new ArrayList();

    static readonly Cell m1_1 = new Cell(1, 0, true);
    static readonly Cell m1_2 = new Cell(3, 1, true);
    static readonly Cell m1_3 = new Cell(5, 1, true);
    static readonly Cell m1_4 = new Cell(7, 2, true);
    static readonly Cell m1_5 = new Cell(9, 2, true);
    static readonly Cell m1_6 = new Cell(11, 0, true);
    readonly Cell[] m1 = { m1_1, m1_2, m1_3, m1_4, m1_5, m1_6 };

    static readonly Cell m2_1 = new Cell(1, 1, true);
    static readonly Cell m2_2 = new Cell(3, 1, true);
    static readonly Cell m2_3 = new Cell(5, 0, true);
    static readonly Cell m2_4 = new Cell(7, 1, true);
    static readonly Cell m2_5 = new Cell(9, 2, true);
    static readonly Cell m2_6 = new Cell(11, 1, true);
    readonly Cell[] m2 = { m2_1, m2_2, m2_3, m2_4, m2_5, m2_6 };

    static readonly Cell m3_1 = new Cell(1, 0, true);
    static readonly Cell m3_2 = new Cell(3, 0, true);
    static readonly Cell m3_3 = new Cell(5, 1, true);
    static readonly Cell m3_4 = new Cell(7, 2, true);
    static readonly Cell m3_5 = new Cell(9, 2, true);
    static readonly Cell m3_6 = new Cell(11, 0, true);
    readonly Cell[] m3 = { m3_1, m3_2, m3_3, m3_4, m3_5, m3_6 };

    static readonly Cell m4_1 = new Cell(1, 1, true);
    static readonly Cell m4_2 = new Cell(3, 0, true);
    static readonly Cell m4_3 = new Cell(5, 0, true);
    static readonly Cell m4_4 = new Cell(7, 1, true);
    static readonly Cell m4_5 = new Cell(9, 2, true);
    static readonly Cell m4_6 = new Cell(11, 2, true);
    readonly Cell[] m4 = { m4_1, m4_2, m4_3, m4_4, m4_5, m4_6 };

    static readonly Cell m5_1 = new Cell(1, 1, true);
    static readonly Cell m5_2 = new Cell(3, 0, false);
    static readonly Cell m5_3 = new Cell(5, 0, true);
    static readonly Cell m5_4 = new Cell(7, 1, true);
    static readonly Cell m5_5 = new Cell(9, 2, true);
    static readonly Cell m5_6 = new Cell(11, 2, true);
    readonly Cell[] m5 = { m5_1, m5_2, m5_3, m5_4, m5_5, m5_6 };

    static readonly Cell m6_1 = new Cell(1, 0, false);
    static readonly Cell m6_2 = new Cell(3, 1, true);
    static readonly Cell m6_3 = new Cell(5, 1, true);
    static readonly Cell m6_4 = new Cell(7, 2, true);
    static readonly Cell m6_5 = new Cell(9, 1, true);
    static readonly Cell m6_6 = new Cell(11, 1, true);
    readonly Cell[] m6 = { m6_1, m6_2, m6_3, m6_4, m6_5, m6_6 };

    static readonly Cell m7_1 = new Cell(1, 1, true);
    static readonly Cell m7_2 = new Cell(3, 0, false);
    static readonly Cell m7_3 = new Cell(5, 1, true);
    static readonly Cell m7_4 = new Cell(7, 0, false);
    static readonly Cell m7_5 = new Cell(9, 0, true);
    static readonly Cell m7_6 = new Cell(11, 0, true);
    readonly Cell[] m7 = { m7_1, m7_2, m7_3, m7_4, m7_5, m7_6 };

    static readonly Cell m8_1 = new Cell(1, 0, true);
    static readonly Cell m8_2 = new Cell(3, 0, false);
    static readonly Cell m8_3 = new Cell(5, 1, true);
    static readonly Cell m8_4 = new Cell(7, 2, true);
    static readonly Cell m8_5 = new Cell(9, 0, false);
    static readonly Cell m8_6 = new Cell(11, 0, true);
    readonly Cell[] m8 = { m8_1, m8_2, m8_3, m8_4, m8_5, m8_6 };

    private void Start()
    {
        canGenerate = true;
        Instantiate(grassPrefab, new Vector3(-7.7f, -3.909f, 0), new Quaternion());
        Instantiate(grassPrefab, new Vector3(-5.39f, -3.909f, 0), new Quaternion());
        Instantiate(grassPrefab, new Vector3(-3.08f, -3.909f, 0), new Quaternion());
        positionsTiles.Add(m1);
        positionsTiles.Add(m2);
        positionsTiles.Add(m3);
        positionsTiles.Add(m4);
        positionsTiles.Add(m5);
        positionsTiles.Add(m6);
        positionsTiles.Add(m7);
        positionsTiles.Add(m8);
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Seguimiento.posActualCameraX + 27.72f >= actualEndOfTiles) && canGenerate)
        {
            generate();
        }
    }

    void generate()
    {
        Cell[] selected = (Cell[])positionsTiles[Random.Range(0, positionsTiles.Count)];
        bool canDisplayBomb = true;

        for (int i = 0; i < selected.Length; i++)
        {
            if (selected[i].isDisplayable())
            {
                canDisplayBomb = i < selected.Length - 1 ? selected[i].getLevel() == selected[i + 1].getLevel() ? false : true : true;
                float posX = pivot + (tamCell * selected[i].getMultiplicator());
                canDisplayBomb = generateCoins(posX - tamCell, posX + tamCell, selected[i].getLevel(), canDisplayBomb);
                Instantiate(grassPrefab, new Vector3(posX, positionsY[selected[i].getLevel()], 0), new Quaternion());
            }
        }
        pivot += tamCell * (selected[selected.Length - 1].getMultiplicator() + 1);
        actualEndOfTiles = pivot;
    }

    bool generateCoins(float start, float end, int level, bool canDpB)
    {
        bool loadCoin = probability[Random.Range(0, probability.Length)];
        if (loadCoin)
        {
            float pos = Random.Range(start, end);
            float posY = positionsCoinY[level];
            Instantiate(coinPrefab, new Vector3(pos, posY, 0), new Quaternion());
            return true;
        }
        else
        {
            loadCoin = probabilityBombs[Random.Range(0, probabilityBombs.Length)];
            if (loadCoin && level != 2 && canDpB)
            {
                float posY = level == 1 ? positionsCoinY[level] - 1f : positionsCoinY[level] - 0.7f;
                Instantiate(bombPrefab, new Vector3(end - 0.4f, posY, 0), new Quaternion());
                return false;
            }
        }
        return false;
    }

    public class Cell
    {
        int multiplicator;
        int level;
        bool displayable;

        public Cell(int multiplicator, int level, bool displayable)
        {
            this.multiplicator = multiplicator;
            this.level = level;
            this.displayable = displayable;
        }

        public int getMultiplicator()
        {
            return this.multiplicator;
        }
        public int getLevel()
        {
            return this.level;
        }

        public bool isDisplayable()
        {
            return this.displayable;
        }
    }
}
