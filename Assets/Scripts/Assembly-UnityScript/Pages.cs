using System;
using UnityEngine;

[Serializable]
public class Pages
{
	public bool show;

	public Transform objectTransform;

	public Conditions conditions;

	public Trigger trigger;

	public ActionText actionText;

	public int[] itemId;

	public Contents[] contents;
}
