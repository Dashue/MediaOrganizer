using System.Management.Automation;
using MediaOrganizer.Core;
using MediaOrganizer.Core.Enums;

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