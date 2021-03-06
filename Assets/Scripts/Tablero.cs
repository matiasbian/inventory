﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {
	public int lenghtX,lenghtY;
	public static Vector2Int position;
	public static bool[,] board;
	public static int headerX, headerY;
	public static int lenghtXS, lenghtYS;
	// Use this for initialization
	void Start () {
		board = new bool[lenghtX, lenghtY];
		lenghtXS = lenghtX;
		lenghtYS = lenghtY;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			moveTo (5, 5);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log (getPosition ());
			Debug.Log (getBoardLenght ());
		}
	}

	public static Vector2Int getPosition(){
		return position;
	}

	public static Vector2Int getBoardLenght(){
		return new Vector2Int(board.GetLength (0),board.GetLength(1));
	}

	public static void moveTo(int X, int Y){
		if (between (X, 0, lenghtXS - 1) && between (Y, 0, lenghtYS - 1)) {
			position = new Vector2Int (X, Y);
		} else {
			Debug.LogError ("out of board");
		}
	}
		


	#region auxiliares
	static bool between(int valor,int min, int max){
		return valor >= min && valor <= max;
	}

	#endregion}

}


