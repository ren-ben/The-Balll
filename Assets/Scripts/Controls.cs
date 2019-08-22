using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Controls : MonoBehaviour
{
    #region Variables
    Vector2 startPos;
    Vector2 endPos;
    Vector2 targetPos;
    bool directionChosen;
    public int health = 3;
    public static int DefaultHealth = 3;
    public static int healthForSpawnerReset = 3;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int healthAmount = 3;
    public float Yincrement = 5f;
    public GameObject effectForChangingPosition;
    public Animator camAnim;
    public GameObject PlayerMoveSound;
    public GameObject GameOverSound;
    public static int score;
    public GameObject timer;
    public float timerfill;

    #endregion

    private void Start()
    {
        PlayerPrefs.SetInt("scorePrefs", score);
    }

    void Update()
    {
        TouchControls();
        KeyboardControls();
        Death();
    }
    public void Death()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
            Instantiate(GameOverSound, transform.position, Quaternion.identity);
        }
        
    }
    private void KeyboardControls()
    {
        //Where does it move
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //Up Arrow
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(PlayerMoveSound, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Instantiate(effectForChangingPosition, transform.position, Quaternion.identity);
        }
        //Down Arrow
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(PlayerMoveSound, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(effectForChangingPosition, transform.position, Quaternion.identity);
        }
    }
    private void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Ended:
                    endPos = touch.position;
                    directionChosen = true;
                    break;

            }
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (directionChosen)
        {
            if (startPos.y < endPos.y && transform.position.y < maxHeight)
            {
                Instantiate(PlayerMoveSound, transform.position, Quaternion.identity);
                camAnim.SetTrigger("Shake");
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                Instantiate(effectForChangingPosition, transform.position, Quaternion.identity);

            }
            else if(startPos.y > endPos.y && transform.position.y > minHeight)
            {
                Instantiate(PlayerMoveSound, transform.position, Quaternion.identity);
                camAnim.SetTrigger("Shake");
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                Instantiate(effectForChangingPosition, transform.position, Quaternion.identity);
            }

            directionChosen = false;
        }
    }
}