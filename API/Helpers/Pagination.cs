using System.Collections.Generic;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pazeSize, int itemCount, IReadOnlyList<T> data )
        {
            this.PageIndex = pageIndex;
            this.PazeSize = pazeSize;
            this.ItemCount = itemCount;
            this.Data= data;
        }
        public int PageIndex { get; set; }
        public int PazeSize { get; set; }
        public int ItemCount { get; set; }

        public IReadOnlyList<T> Data { get; set; }

    }
}