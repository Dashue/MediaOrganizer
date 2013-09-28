using System.Management.Automation;
using PhotoUtil.Enums;

namespace PhotoUtil.Cmdlets
{
	[Cmdlet(VerbsCommon.Rename, "Photos")]
	public class RenamePhotos : PSCmdlet
	{
		protected override void ProcessRecord()
		{
			var path = SessionState.Path.CurrentLocation.Path;
			
			base.ProcessRecord();
			PhotoUtility.FixPhotos(path, PhotoAction.Rename);
		}
	}
}