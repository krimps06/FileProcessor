using FileProcessor.TextProcessor.TextFilter;

namespace FileProcessorTest
{
    [TestFixture]
    public class LengthLessThanThreeFilterTests
    {
        [Test]
        public void LengthLessThanThreeFilter_FailsShortWords()
        {
            var filter = new LengthLessThanThreeFilter();
            Assert.IsFalse(filter.Filter("is"));
            Assert.IsFalse(filter.Filter("g"));
        }

        [Test]  
        public void LengthLessThanThreeFilter_PassesLongWords()
        {
            var filter = new LengthLessThanThreeFilter();
            Assert.IsTrue(filter.Filter("cleaner"));
            Assert.IsTrue(filter.Filter("the"));
        }

    }
}