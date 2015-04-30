using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelCrushers.LoveHate
{

	/// <summary>
	/// Unity Event system event handler interface for OnShareRumors(FactionMember).
	/// </summary>
	public interface IShareRumorsEventHandler : IEventSystemHandler 
	{

		void OnShareRumors(FactionMember other);

	}

}
