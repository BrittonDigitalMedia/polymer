
using Machine.Specifications;
using System.IO;

namespace polymer.tests.ravendb.for_RavenFS
{
	public class when_adding_a_new_file : given.a_raven_file_system
	{
		Establish context = () =>
		{

		};

		Because because = async () =>
		{
			_stream = new FileStream(_testFile, FileMode.Open);
			using (var session = _fileStore.OpenAsyncSession())
			{
				session.RegisterUpload(_testFile, _stream);
				await session.SaveChangesAsync();
			}
		};

		It should_pass = () => true.ShouldBeTrue();
		It should_contain_file_in_database =  () =>
		{
			using (var session = _fileStore.OpenAsyncSession())
			{
				var fileTask = session.Query().WhereEquals(x => x.Name, "test.txt").FirstOrDefaultAsync();
				fileTask.Wait();
				var file = fileTask.Result;
				file.ShouldNotBeNull();
			}
		};
		private static FileStream _stream;
	}
}
