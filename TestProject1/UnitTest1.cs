using GridColor.Models;
using GridColor.Services;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        GridService _gridService;
        public UnitTest1()
        {
            _gridService = new GridService();
        }

        [TestMethod]
        public void GetGrid_ReturnsCorrectNumberOfGrids()
        {
            int size = 5;
            int rangeFrom = 1;
            int rangeTo = 100;

            List<GridModel> result = _gridService.GetGrid(size, rangeFrom, rangeTo);

            Assert.AreEqual(size * size, result.Count);
        }

        [TestMethod]
        public void GetGrid_ReturnsCorrectRangeOfNumbers()
        {
            int size = 5;
            int rangeFrom = 1;
            int rangeTo = 100;

            List<GridModel> result = _gridService.GetGrid(size, rangeFrom, rangeTo);

            foreach (var grid in result)
            {
                Assert.IsTrue(grid.Number >= rangeFrom && grid.Number <= rangeTo);
            }
        }
    }
}