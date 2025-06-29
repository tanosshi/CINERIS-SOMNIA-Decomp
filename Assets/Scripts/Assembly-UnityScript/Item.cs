using System;
using UnityEngine;

[Serializable]
public class Item
{
	public string itemNameJap;

	public string itemNameEng;

	public Texture2D picture;

	public string[] itemExplainJap;

	public string[] itemExplainEng;

	public bool callCommon;

	public int commonId;

	public int switchId;
}
