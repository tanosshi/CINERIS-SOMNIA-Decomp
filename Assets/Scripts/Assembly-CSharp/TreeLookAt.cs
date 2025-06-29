using UnityEngine;

[ExecuteInEditMode]
public class TreeLookAt : MonoBehaviour
{
	private void Update()
	{
		base.transform.LookAt(Camera.main.transform, Vector3.up);
	}
}
