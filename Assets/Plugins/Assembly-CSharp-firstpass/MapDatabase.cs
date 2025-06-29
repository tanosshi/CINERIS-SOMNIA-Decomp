using System;
using UnityEngine;

public class MapDatabase : ScriptableObject
{
	[Serializable]
	public class Map
	{
		public Texture2D[] mapPicture;

		public int enableSwitchId;

		public int[] getSwitchId;
	}

	public Map[] maps;
}
