using UnityEngine;  
using UnityEditor;  
using UnityEditorInternal;

namespace PixelCrushers.LoveHate
{
	
	[CustomEditor(typeof(GreetingTrigger))]
	[CanEditMultipleObjects]
	public class GreetingTriggerEditor : AbstractGreetingTriggerEditor
	{
	}
	
}