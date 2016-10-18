using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Threading.Tasks
{
	internal static class SyncToTaskFactory
	{
		public static Task<T> CreateTask<T>(Func<T> action)
		{
			var tcs = new TaskCompletionSource<T>();

			Task.Factory.StartNew(
				() => {
					try
					{
						var result = action();
						tcs.SetResult(result);
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				}
			);

			return tcs.Task;
		}

		public static async Task CreatTask(Action action)
		{
			var tcs = new TaskCompletionSource<bool>();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			Task.Factory.StartNew(
				() => {
					try
					{
						action();
						tcs.SetResult(true);
					}
					catch (Exception ex)
					{
						tcs.SetException(ex);
					}
				}
			);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

			await tcs.Task;
			return;
		}
	}
}
