using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementplayer : MonoBehaviour {
    public GameObject MyJr;
    Vector3 playerStart;
    public int gridSize = 2;
    public GameObject winSpot;
	public GameObject enemy;
    public int maxGrid = 8;
    public int minGrid = 0;
    public GameObject backGround;
	public int score;
	public Text scoreText;
	public float enemySpeed;
    public AudioClip musicClip;
    public AudioClip winclip;
    public AudioClip loser;
    public AudioSource audioS;
    public AudioSource audioP;
    public AudioSource audioL;

    // Use this for initialization
    void Start()
    {
        scoreText.text = score.ToString();
        playerStart = MyJr.transform.position;
        int randoX = (int)(Random.Range(minGrid, maxGrid / gridSize));
        Debug.Log(randoX);
        randoX *= gridSize;

        int randoZ = (int)(Random.Range(minGrid, maxGrid / gridSize));
        Debug.Log(randoZ);
        randoZ *= gridSize;
        winSpot.transform.position = new Vector3(randoX, winSpot.transform.position.y, randoZ);

        while (randoX == winSpot.transform.position.x && randoZ == winSpot.transform.position.z)
        {

            randoX = (int)(Random.Range(minGrid, maxGrid / gridSize));

            randoX *= gridSize;

            randoZ = (int)(Random.Range(minGrid, maxGrid / gridSize));

            randoZ *= gridSize;
        }
        enemy.transform.position = new Vector3(randoZ, enemy.transform.position.y, randoX);
    }
		
    

    // Update is called once per frame
    void Update () {
        movementInput();
        checkBounds();
		checkWin();
		lose ();
		//moveEnemy ();
    }
	void lose()
	{
		if (MyJr.transform.position == enemy.transform.position)
		{
           
            score--;
            audioL.Play();
            //MyJr.transform.localScale *= 1.01f;
            MyJr.transform.position = playerStart;
            enemy.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            backGround.GetComponent<MeshRenderer>().material.color =Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			Start();
		}
	}
    

    void checkWin(){
        if (MyJr.transform.position == winSpot.transform.position)
        {
			score++;
            audioP.Play();
            //MyJr.transform.localScale *= 1.01f;
            MyJr.transform.position = playerStart;
            winSpot.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            backGround.GetComponent<MeshRenderer>().material.color =Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Start();

        }
    }
	/*void moveEnemy(){
		enemy.transform.position += new Vector3 ((float)gridSize / enemySpeed, 0, 0);

		if (enemy.transform.position.x > maxGrid){
			enemy.transform.position = new Vector3(minGrid, enemy.transform.position.y, enemy.transform.position.z);
		}
		if (enemy.transform.position.z < minGrid){
			enemy.transform.position = new Vector3(minGrid, enemy.transform.position.y, maxGrid);
		}
	}*/
    void movementInput()
    {
        //Z MOVEMENT OF MY GRID
        if (Input.GetKeyDown(KeyCode.W))
            
        {
            audioS.Play();
            MyJr.transform.position += new Vector3(0, 0, gridSize);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            audioS.Play();
            MyJr.transform.position += new Vector3(0, 0, -gridSize);
        }
        //X MOVEMENT ON MY GRID
        if (Input.GetKeyDown(KeyCode.D))
        {
            audioS.Play();
            MyJr.transform.position += new Vector3(-gridSize, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioS.Play();
            MyJr.transform.position += new Vector3(gridSize, 0, 0);
        }
    }

    void checkBounds()
    {
        if (MyJr.transform.position.z > maxGrid)
        {
			MyJr.transform.position = new Vector3(MyJr.transform.position.x, MyJr.transform.position.y, minGrid);
        }
        if (MyJr.transform.position.z < minGrid)
        {
			MyJr.transform.position = new Vector3(MyJr.transform.position.x, MyJr.transform.position.y, maxGrid);
        }

        if (MyJr.transform.position.x > maxGrid)
        {
			MyJr.transform.position = new Vector3(minGrid, MyJr.transform.position.y, MyJr.transform.position.z);
        }
        if (MyJr.transform.position.x < minGrid)
        {
			MyJr.transform.position = new Vector3(maxGrid, MyJr.transform.position.y, MyJr.transform.position.z);

        }


    }
}

