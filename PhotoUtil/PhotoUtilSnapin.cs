using System.ComponentModel;
using System.Management.Automation;

namespace PhotoUtil
{
	[RunInstaller(true)]
	public class PhotoUtilSnapin : PSSnapIn
	{
		public override string Description
		{
			get { return "Cmdlets to move and rename photos based on exif info"; }
		}

		public override string Name
		{
			get { return "PhotoUtilSnapin"; }
		}

		public override string Vendor
		{
			get { return "johanilsson.com"; }
		}
	}
}