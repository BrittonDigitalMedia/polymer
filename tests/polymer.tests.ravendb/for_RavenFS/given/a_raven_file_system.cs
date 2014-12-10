using Machine.Specifications;
using Raven.Client.FileSystem;
using System;
using System.IO;

namespace polymer.tests.ravendb.for_RavenFS.given
{
	public class a_raven_file_system
	{
		Establish context = () =>
		{
			_fileStore = new FilesStore() { Url = "http://localhost:8088", DefaultFileSystem = "TST" };
			_fileStore.Initialize();
			_currentDir = AppDomain.CurrentDomain.BaseDirectory;
			_testFile = Path.Combine(_currentDir, "_assets", "test.txt");
		};

		protected static IFilesStore _fileStore;
		protected static string _currentDir;
		protected static string _testFile;
	}
}
