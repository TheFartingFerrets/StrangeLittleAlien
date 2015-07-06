using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class WorldButton : MonoBehaviour 
{
	[SerializeField]
	public WorldPrefix WorldType = WorldPrefix.Maths;

	public Text story;
	public Text howTo;

	[TextArea(3,10)]
	public string Maths_Story = "";
	[TextArea(3,10)]
	public string Physics_Story = "";
	[TextArea(3,10)]
	public string Reflex_Story = "";
	[TextArea(3,10)]
	public string Collect_Story = "";

	[TextArea(3,10)]
	public string Maths_How_To = "";
	[TextArea(3,10)]
	public string Physics_How_To = "";
	[TextArea(3,10)]
	public string Reflex_How_To = "";
	[TextArea(3,10)]
	public string Collect_How_To = "";

	public void WorldSelect()
	{
		this.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play ();
		GameObject.FindObjectOfType<GameController>().StartCoroutine("SetWorld", WorldType.ToString());
		//GameObject.FindObjectOfType<GameController>().SetWorld(WorldType.ToString());
		storyChanger ();
	}
	public void ToggleLevelSelection(bool value)
	{
		GameObject.Find("LevelSelection").GetComponent<CanvasGroup>().ToggleCanvasGroup(value);
	}
	public void storyChanger(){
		
		switch (WorldType)
		{
		case WorldPrefix.Maths:
			//Console.WriteLine("Case 1");
			story.text = Maths_Story;
			howTo.text = Maths_How_To;
			break;
		case WorldPrefix.Physics:
			story.text = Physics_Story;
			howTo.text = Physics_How_To;
			//Console.WriteLine("Case 2");
			break;
		case WorldPrefix.Collect:
			story.text = Collect_Story;
			howTo.text = Collect_How_To;
			break;
		case WorldPrefix.Reflex:
			story.text = Reflex_Story;
			howTo.text = Reflex_How_To;
			break;
			// default:
			// //Console.WriteLine("Default case");
			// break;
		}
	}
}