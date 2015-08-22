using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ResourceHandler : MonoBehaviour 
{
	float maxResource;
	float curResource;
	string resourceType;
	Text resourceText;

	public ResourceHandler(Text resourceText, float curResource, float maxResource, string resourceType)
	{
		this.resourceText = resourceText;
		this.curResource = curResource;
		this.maxResource = maxResource;
		this.resourceType = resourceType;

		updateUI();
	}

	public void changeResource(float change)
	{
		maxResource += change;
		updateUI();
	}

	public bool maxedResource()
	{
		return curResource >= maxResource;
	}

	private void updateUI()
	{
		resourceText.text = resourceType + ": " + curResource + " / " + maxResource;
	}
}
