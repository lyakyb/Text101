using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{
	public Text text;
	private enum States
	{
		cell,
		mirror,
		sheets_0,
		lock_0,
		cell_mirror,
		sheets_1,
		lock_1,
		freedom}
	;
	private States myState;

	// Use this for initialization
	void Start ()
	{
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheet_0 ();
		} else if (myState == States.sheets_1) {
			state_sheet_1 ();
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		} else if (myState == States.lock_1) {
			state_lock_1 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror ();
		} else if (myState == States.freedom) {
			state_freedom ();
		}
	}

	void state_cell ()
	{
		text.text = "You are in a prison cell, and you realize that you actually want to escape from the cell."
			+ "There are some dirty sheets on the bed, a mirror on the wall, and the door " 
			+ "is locked from the outside \n\n"
			+ "Press S to view Sheets, M to view Mirror and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	void state_mirror ()
	{
		text.text = "You almost got a heartattack from looking at the disgusting look " +
			"that appears on the mirror. The prison had done you one thing good... it " +
			"allowed you to run away from reality.\n\n" +
			"Press T to Take the mirror, or R to Return to cell.";
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_cell_mirror ()
	{
		text.text = "You are still stuck in your bloody cell, and you surprisingly STILL " +
			"want to escape! There are some bed dirty sheets on the floor, and the door " +
			"is still locked, or at least it looks like it.\n\n"
			+ "Press S to view Sheets, or L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		}
	}


	void state_sheet_0 ()
	{
		text.text = "These are not bed sheets, these are human skins." +
			"You are utterly disgusted by the fact that you have been sleeping " +
			"in these skins. \n\n" +
			"Press R to Return to roaming your room.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 
	}

	void state_sheet_1 ()
	{
		text.text = "This is actually a clean bed sheet. " +
			"That's what you must have hoped, sadly it is not. " +
			"This is a flattened out dry turd.\n\n" +
			"Press R to Return to roaming your room.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}

	}

	void state_lock_0 ()
	{
		text.text = "Completely hopeless. This lock is one of those fancy finger print locks. " +
			"Maybe if you are lucky enough you might happen to find a cut finger with the right " +
			"finger print to open the door. \n\n" +
			"Press R to Return to roaming your room.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 
	}

	void state_lock_1 ()
	{
		text.text = "You could not control your anger and smashed the mirror on the lock. " +
			"Then you noticed that the door was actually never locked. The door slowly opens.\n\n" +
			"Press O to Open, or R to Return to your cell";

		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_freedom ()
	{
		text.text = "YOU ARE FREE. OOPS. YOU HAVE BEEN FREE THE ENTIRE TIME. \n\n" +
			"Press P to Play again.";

		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		}
	}
}
