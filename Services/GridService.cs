using GridColor.Models;

namespace GridColor.Services
{
    public class GridService
    {


        public List<GridModel> GetGrid(int Size, int RangeFrom, int RangeTo)
        {
            int numberOfGirds = Size * Size;
            Random random = new Random();
            var list = new List<GridModel>();

            for (int i = 0; i < numberOfGirds; i++)
            {
                list.Add(new GridModel()
                {
                    Number = random.Next(RangeFrom, RangeTo + 1)
                }); ;
            }
            return list;
        }
    }
}
