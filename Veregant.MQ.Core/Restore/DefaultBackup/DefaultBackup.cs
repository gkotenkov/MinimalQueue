﻿using Veregant.MQ.Core.Backup.Core;

namespace Veregant.MQ.Core.Backup.DefaultBackup
{
	internal class DefaultBackup : IMQBackupIO
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
