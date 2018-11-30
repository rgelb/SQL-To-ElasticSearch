using System;
using System.Linq;
using System.Threading.Tasks;

namespace SqlToElasticSearchConverter {
    public class SelectItem {
        public string Column { get; set; }
        public bool IsComplete {
            get {
                return Column != null;
            }
        }
    }
}
