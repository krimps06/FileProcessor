using FileProcessor.Services;
using FileProcessor.TextProcessor.TextFilter;

namespace FileProcessorTest
{
    [TestFixture]
    public class FileServiceTests
    {
        private IFileService _fileService;
        private List<IFilter> _filters;
        [SetUp]
        public void Setup()
        {
            _filters = new List<IFilter>
            {
                new VowelInMiddleFilter(),
                new LengthLessThanThreeFilter(),
                new CharTFilter()
            };
            _fileService = new FileService(_filters);

        }

        [Test]
        public void FileService_ValidFile_Test()
        {
            string input = "Alice was beginning to get very tired. So she decided to go to the playground.";
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, input);

            string result = _fileService.processFilters(tempFile);

            Assert.That(result.ToLower(), Is.EqualTo("beginning, she, playground"));

            File.Delete(tempFile);
        }

        [Test]
        public void FileService_FileNotFound_Test()
        {
            string tempFile = "invalidPath.txt";
            
            var ex = Assert.Throws<FileNotFoundException>(() => _fileService.processFilters(tempFile));
            Assert.That(ex.Message, Is.EqualTo("The specified file does not exist."));
        }

        [Test]
        public void FileService_EmptyFile_Test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "");

            var ex = Assert.Throws<ArgumentNullException>(() => _fileService.processFilters(tempFile));
            Assert.That(ex.Message, Is.EqualTo("Input file cannot be empty or only white spaces."));

            File.Delete(tempFile);
        }

        [Test]
        public void FileService_EmptyPath_Test()
        {
            string tempFile = "";

            var ex = Assert.Throws<ArgumentNullException>(() => _fileService.processFilters(tempFile));
            Assert.That(ex.Message, Is.EqualTo("The file path cannot be is empty or white spaces."));
        }
    }
}