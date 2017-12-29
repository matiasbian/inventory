using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour {
	public GameObject prefabCell;
	public GridLayoutGroup grid;
	// Use this for initialization
	void Start () {
		Invoke ("drawBoard", 1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void drawBoard(){
		grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		grid.constraintCount = Tablero.board.GetLength (0);
		for (int i = 0; i < Tablero.board.GetLength (1); i++) {
			drawLine (Tablero.board.GetLength (0));
		}
		paintItem (4, 2);
	}


	void paintItem(int longX, int longY,int offsetX = 0 , int offsetY = 0){
		for (int i = offsetY; i < longY; i++) {
			paintALine (longX, i, offsetX);
		}
	}

	void paintALine(int longX,int posY,int offsetX = 0){
		for (int i = offsetX; i < longX; i++) {
			paintACell (i, posY);
		}
	}

	public void paintACell(int x, int y){
		Tablero.board.SetValue (true, x, y);
		getCell (x, y).color = Color.black;

	}


	#region
	void drawLine(int lenght){
		for (int i = 0; i < lenght; i++) {
			GameObject cell = Instantiate (prefabCell, prefabCell.transform.position, prefabCell.transform.rotation);
			cell.transform.SetParent( grid.transform );
		}
	}

	Image getCell (int x, int y){
		foreach (Image celda in grid.GetComponentsInChildren<Image>()) {
			if (celda.transform.GetSiblingIndex () == obtainSilbing (x, y)) {
				Debug.Log ("RETORNECELDA");
				return celda;
			}
		}
		Debug.Log ("NORETORNECELDA");
		return null;
	}

	int obtainSilbing(int x, int y){
		int longX = Tablero.board.GetLength (0);
		return ((longX * (y+1)) - (longX - (x +1) ))  ;
	}
	#endregion
}
