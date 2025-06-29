using System;
using UnityEngine;

public class PurposeDatabase : ScriptableObject
{
	[Serializable]
	public class Purpose
	{
		public string purposeNameJap;

		public string purposeNameEng;

		public string[] purposeExplainJap;

		public string[] purposeExplainEng;

		public Texture2D purposePicture;

		public int enableSwitchId;

		public int appearSwitchId;

		public int disappearSwitchId;

		public bool subPurposeFlag;

		public bool deleteFlag;
	}

	public Purpose[] purposes;

	public int[] purposeSortNumber;
}
