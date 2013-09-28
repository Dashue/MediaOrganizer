using System.Management.Automation;
using PhotoUtil.Enums;

namespace PhotoUtil.Cmdlets
{
	[Cmdlet(VerbsCommon.Move, "Photos")]
	public class MovePhotos : PSCmdlet
	{
		protected override void ProcessRecord()
		{
			var path = SessionState.Path.CurrentLocation.Path;

			base.ProcessRecord();
			PhotoUtility.FixPhotos(path, PhotoAction.Move);
		}
	}
}