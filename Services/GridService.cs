using GridColor.Models;

namespace GridColor.Services
{
    public class GridService
    {


        public List<GridModel> GetGrid(int Size, int RangeFrom, int RangeTo)
        {
            if(Size > 100)
            {
                Size = 100;
            }

            int numberOfGirds = Size * Size;
            Random random = new Random();
            var list = new List<GridModel>();

            for (int i = 0; i < numberOfGirds; i++)
            {
                var rndNumber = random.Next(RangeFrom, RangeTo + 1);
                list.Add(new GridModel()
                {
                    Number = rndNumber,
                    Lightness = GetLightNess(RangeFrom, RangeTo, rndNumber)

                });
            }
            return list;
        }

        public int GetLightNess(int RangeFrom, int RangeTo, int CurrentNumber)
        {
            return (int)Math.Round(((double)(RangeTo - CurrentNumber) / (double)(RangeTo - RangeFrom)) * 100);
        }
    }
}
