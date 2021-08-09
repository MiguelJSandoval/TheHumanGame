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

public class Controller : MonoBehaviour
{
    private bool isJumping;
    private bool canJump;
    private int contJumps = 0;
    public static float moving;
    public GameObject sound;
    public GameObject sounDead;

    // Start is called before the first frame update
    void Start()
    {
        moving = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a") || BtnLeftController.isLeftPressed)
        { 
            gameObject.transform.Translate(-moving * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if (Input.GetKey("right") || Input.GetKey("d") || BntRigthController.isRightPressed)
        {
            gameObject.transform.Translate(moving * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if ((!Input.GetKey("right") && !Input.GetKey("left")) && (!Input.GetKey("a") && !Input.GetKey("d")) 
            && !BntRigthController.isRightPressed && !BtnLeftController.isLeftPressed)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("space") || isJumping || Input.GetKeyDown("w")) && (canJump || contJumps <= 1))
        {
            isJumping = false;
            contJumps++;
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 950f));
        }
    }

    public void jump()
    {
        if (canJump || contJumps <= 1)
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false;
            contJumps = 0;
            canJump = true;
        }

        if (collision.gameObject.CompareTag("deadzone"))
        {
            Destroy(Instantiate(sounDead), 1f);
            Seguimiento.mov = 0;
            GrassSpawner.canGenerate = false;
            StartCoroutine(DelayGame(true));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bomb"))
        {
            Destroy(Instantiate(sound), 4f);
            gameObject.GetComponent<Animator>().SetBool("dead", true);
            Seguimiento.mov = 0;
            GrassSpawner.canGenerate = false;
            StartCoroutine(DelayGame(true));
        }
    }

    IEnumerator DelayGame(bool destroy)
    {
        yield return new WaitForSeconds(0.8f);
        LoadGameOver.ShowDlg();
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
