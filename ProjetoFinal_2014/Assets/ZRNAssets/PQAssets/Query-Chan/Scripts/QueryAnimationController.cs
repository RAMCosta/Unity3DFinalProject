using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueryAnimationController : MonoBehaviour {

	[SerializeField]
	GameObject queryBodyParts;
	[SerializeField]
	GameObject[] queryHandParts;
	
	public enum QueryChanAnimationType
	{
		// Normal motion
		STAND = 1,
		IDLE = 2,
		WALK = 3,
		RUN = 4,
		JUMP = 5,
		POSE = 6,

		// Fly motion
		FLY_IDLE = 7,
		FLY_STRAIGHT = 8,
		FLY_TORIGHT = 9,
		FLY_TOLEFT = 10,
		FLY_UP = 11,
		FLY_DOWN = 12,
		FLY_ITEMGET = 13,
		FLY_ITEMGET_LOOP = 14,
		FLY_DAMAGE = 15,
		FLY_DISAPPOINTMENT = 16,
		FLY_DISAPPOINTMENT_LOOP = 17

	}

	public enum QueryChanHandType
	{

		NORMAL = 0,
		STONE = 1,
		PAPER = 2

	}


	public void ChangeAnimation (QueryChanAnimationType animNumber)
	{

		switch (animNumber)
		{
		case QueryChanAnimationType.FLY_STRAIGHT:
		case QueryChanAnimationType.FLY_TORIGHT:
		case QueryChanAnimationType.FLY_TOLEFT:
		case QueryChanAnimationType.FLY_UP:
			changeHandPart (QueryChanHandType.PAPER);
			this.GetComponent<QueryEmotionalController>().ChangeEmotion(QueryEmotionalController.QueryChanEmotionalType.NORMAL_EYEOPEN_MOUTHCLOSE);
			break;

		case QueryChanAnimationType.FLY_ITEMGET:
		case QueryChanAnimationType.FLY_ITEMGET_LOOP:
			changeHandPart (QueryChanHandType.STONE);
			this.GetComponent<QueryEmotionalController>().ChangeEmotion(QueryEmotionalController.QueryChanEmotionalType.FUN_EYECLOSE_MOUTHOPEN);
			break;

		case QueryChanAnimationType.FLY_DAMAGE:
			changeHandPart (QueryChanHandType.NORMAL);
			this.GetComponent<QueryEmotionalController>().ChangeEmotion(QueryEmotionalController.QueryChanEmotionalType.SURPRISED_EYEOPEN_MOUTHOPEN_MID);
			break;

		case QueryChanAnimationType.FLY_DISAPPOINTMENT:
		case QueryChanAnimationType.FLY_DISAPPOINTMENT_LOOP:
			changeHandPart (QueryChanHandType.STONE);
			this.GetComponent<QueryEmotionalController>().ChangeEmotion(QueryEmotionalController.QueryChanEmotionalType.SAD_EYECLOSE_MOUTHOPEN);
			break;

		default:
			changeHandPart (QueryChanHandType.NORMAL);
			this.GetComponent<QueryEmotionalController>().ChangeEmotion(QueryEmotionalController.QueryChanEmotionalType.NORMAL_EYEOPEN_MOUTHCLOSE);
			break;
		}
		

		List<string> targetAnimations = new List<string>();
		foreach (AnimationState targetState in queryBodyParts.animation)
		{
			targetAnimations.Add(targetState.name);
		}
		targetAnimations.Sort();

		queryBodyParts.animation.CrossFade(targetAnimations[(int)animNumber]);

	}


	public void changeHandPart (QueryChanHandType handNumber) {

		foreach (GameObject targetHandPart in queryHandParts)
		{
			targetHandPart.SetActive(false);
		}
		queryHandParts[(int)handNumber].SetActive(true);

	}

}
