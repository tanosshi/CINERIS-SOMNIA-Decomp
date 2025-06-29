using System;

[Serializable]
public enum eventType
{
	ShowText = 0,
	ShowChoices = 1,
	ControlSwitches = 2,
	ControlVariables = 3,
	ConditionalBranch = 4,
	ExitEventProcessing = 5,
	JumpToNumber = 6,
	ChangeLevel = 7,
	SetObjectTransform = 8,
	SetMoveRoute = 9,
	FadeScreen = 10,
	FlashScreen = 11,
	Wait = 12,
	ShowPicture = 13,
	MovePicture = 14,
	ErasePicture = 15,
	PlayBGMorBGS = 16,
	FadeoutBGMorBGS = 17,
	PlaySE = 18,
	ChangePlayerControlable = 19,
	ChangeCameraControlable = 20,
	ChangeMenuAccess = 21,
	ChangeCameraInfo = 22,
	ChangeLightInfo = 23,
	PlayAnimation = 24,
	SetHeadLookTarget = 25,
	SetFootstepId = 26,
	SendExtraMessage = 27,
	GetItem = 28,
	ChangeActive = 29,
	DestroyObjects = 30,
	InputNumber = 31
}
