using UnityEngine;
using mset;

public class BlendList : MonoBehaviour
{
	public Sky[] skyList;

	public float blendTime = 3f;

	private float blendStamp;

	private int currSky;

	private SkyManager manager;

	private void Start()
	{
		manager = SkyManager.Get();
		manager.BlendToGlobalSky(skyList[currSky], blendTime);
		blendStamp = Time.time;
	}

	private void Update()
	{
		if (Time.time - blendStamp > blendTime + 1f)
		{
			currSky = (currSky + 1) % skyList.Length;
			blendStamp = Time.time;
			manager.BlendToGlobalSky(skyList[currSky], blendTime);
		}
	}
}
