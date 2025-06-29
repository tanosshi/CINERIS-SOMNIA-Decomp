using UnityEngine;

public class JigglyBlendShapeAnimation : MonoBehaviour
{
	public float speed = 3f;

	private SkinnedMeshRenderer smr;

	private int shape1;

	private int shape2;

	private void Start()
	{
		smr = GetComponent<SkinnedMeshRenderer>();
		int blendShapeCount = smr.sharedMesh.blendShapeCount;
		shape1 = Random.Range(0, blendShapeCount);
		shape2 = Random.Range(0, blendShapeCount);
		while (shape1 == shape2)
		{
			shape2 = Random.Range(0, blendShapeCount);
		}
		speed *= Random.Range(0.8f, 1.2f);
	}

	private void Update()
	{
		float num = 50f * (Mathf.Sin(Time.time * speed) + 1f);
		smr.SetBlendShapeWeight(shape1, num);
		smr.SetBlendShapeWeight(shape2, 100f - num);
	}
}
