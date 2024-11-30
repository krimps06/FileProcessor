using FileProcessor.TextProcessor.TextFilter;

namespace FileProcessorTest
{
    [TestFixture]
    public class CharTFilterTests
    {
        [Test]
        public void CharTFilter_PassesWordsWithoutT()
        {
            var filter = new CharTFilter();
            Assert.IsTrue(filter.Filter("happy"));
            Assert.IsTrue(filter.Filter("is"));
        }

        [Test]
        public void CharTFilter_FailsWordsWithT()
        {
            var filter = new CharTFilter();
            Assert.IsFalse(filter.Filter("The"));
            Assert.IsFalse(filter.Filter("what"));
        }
    }
}