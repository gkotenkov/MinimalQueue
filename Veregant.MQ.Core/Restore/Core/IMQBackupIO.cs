using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veregant.MQ.Core.Backup.Core
{
	internal interface IMQBackupIO
	{
		public Task SaveBackupAsync();

		public Task LoadBackupAsync();
	}
}
