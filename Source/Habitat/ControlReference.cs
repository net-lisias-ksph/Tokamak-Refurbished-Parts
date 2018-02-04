using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Habitat
{
	public class ControlReference : PartModule
	{
		[KSPField]
		public string controlTransformName = "";
		public Transform controlTransform;

		public override void OnStart(PartModule.StartState state)
		{
			var modCommand = part.FindModuleImplementing<ModuleCommand> ();
			if (modCommand != null) {
				var crEvent = Events["MakeReference"];
				var mcEvent = modCommand.Events["MakeReference"];
				// easy way out of translation issues :)
				crEvent.guiName = mcEvent.guiName;
				// hide the command module's version so ours can take over
				mcEvent.guiActive = false;
			}

			controlTransform = part.transform;
			if (!String.IsNullOrEmpty(controlTransformName)) {
				Transform xform = part.FindModelTransform (controlTransformName);
				if (controlTransform == null) {
					Debug.LogWarning ("[ControlReference] No control transform found with the name " + controlTransformName, part.gameObject);
				} else {
					controlTransform = xform;
				}
			}
		}

		[KSPEvent(guiName = "Control From Here", guiActive = true)]
		public virtual void MakeReference()
		{
			//ensure the part's reference transform is the one we want
			part.SetReferenceTransform (controlTransform);
			vessel.SetReferenceTransform(part);
		}
	}
}
