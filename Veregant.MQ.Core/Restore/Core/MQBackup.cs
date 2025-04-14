using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veregant.MQ.Core.Backup.Core
{
	internal class MQBackup
	{
		private IMQBackupIO mQBackupIO { get; set; }

		public MQBackup(IMQBackupIO _mQBackupIO) 
		{
			mQBackupIO = _mQBackupIO;
		}

		public async Task SaveBackupAsync() 
		{
			await mQBackupIO.SaveBackupAsync();
		}

		public async Task LoadBackupAsync() 
		{

			await mQBackupIO.LoadBackupAsync();
		}
	}
}
