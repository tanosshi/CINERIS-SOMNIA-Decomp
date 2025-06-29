using System;
using UnityEngine;

[Serializable]
public class FileItem
{
	public string fileNameJap;

	public string fileNameEng;

	public string[] fileExplainJap;

	public string[] fileExplainEng;

	public bool callCommon;

	public int commonId;

	public AudioClip showSE;

	public FileText[] fileTextJap;

	public FileText[] fileTextEng;

	public bool pictureFlag;

	public Texture2D picture;
}
