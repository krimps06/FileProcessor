using FileProcessor.TextProcessor.TextFilter;

namespace FileProcessorTest
{
    [TestFixture]
    public class VowelInMiddleFilterTests
    {     
        [Test]
        public void VowelInMiddleFilter_OddLength()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsFalse(filter.Filter("clean"));
            Assert.IsTrue(filter.Filter("the"));
        }

        [Test]
        public void VowelInMiddleFilter_EvenLength()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsFalse(filter.Filter("what"));
            Assert.IsTrue(filter.Filter("rather"));
        }

        [Test]  
        public void VowelInMiddleFilter_ProcessesShortWords()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsFalse(filter.Filter("is"));
            Assert.IsTrue(filter.Filter("g"));
        }
    }
}