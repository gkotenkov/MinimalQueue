using Veregant.MQ.Core.Backup.Core;

namespace Veregant.MQ.Core.Backup.SQLBackup
{
	internal class SQLBackup : IMQBackupIO
	{
		public Task LoadBackupAsync()
		{
			throw new NotImplementedException();
		}

		public Task SaveBackupAsync()
		{
			throw new NotImplementedException();
		}
	}
}
