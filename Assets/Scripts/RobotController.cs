using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

	[SerializeField] private Animator RobotAnimator;
	[SerializeField] private ActionState[] sequencing;
	[SerializeField] private AudioSource RobotAS,LoopAS;
	public int CurAction = -1;
	private ActionState robotState;
	public enum ActionState {
		None,
		Iddle,
		Action1,
		Action2,
		Emergence,
		Disappearance
	}

	private ActionState RobotState{
		get{
			return robotState;
		}
		set{ 
			switch (value) {
			case ActionState.None:
				RobotAnimator.SetTrigger("Disappearance");
				break;
			case ActionState.Iddle:
				break;
			case ActionState.Emergence:
				RobotAnimator.SetTrigger("Emergence");
				break;
			case ActionState.Disappearance:
				RobotAnimator.SetTrigger("Disappearance");
				break;
			case ActionState.Action1:
				RobotAnimator.SetTrigger("Action1");
				break;
			case ActionState.Action2:
				RobotAnimator.SetTrigger("Action2");
				break;
			}
		}

	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ShowRobot(){
		ChangeActionState ();
		LoopAS.Play();
	}

	public void ChangeActionState(){
		if (CurAction < sequencing.Length-1) {
			RobotState = sequencing [++CurAction];
		} else {
			CurAction = sequencing.Length-1;

		}

	}

	public void PlaySound(AudioClip clip)
	{
		RobotAS.PlayOneShot(clip);
	}


		
}
