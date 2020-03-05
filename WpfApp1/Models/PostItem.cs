using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class PostItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Favorite { get; set; }

        public static IEnumerable<PostItem> GenerateRandomList(int count = 20)
        {
            Random r = new Random();
            int id = 0;

            return Enumerable.Range(0, count).Select(s =>
            {
                bool fav = (r.Next(0, 2) > 0) ? true : false;
                return new PostItem() { Title = $"Title - {s}", Favorite = fav, Id = id++ };
            });
        }
    }
}
