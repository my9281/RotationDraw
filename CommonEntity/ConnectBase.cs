using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntity
{
    public class ConnectBase<T> where T : class
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
