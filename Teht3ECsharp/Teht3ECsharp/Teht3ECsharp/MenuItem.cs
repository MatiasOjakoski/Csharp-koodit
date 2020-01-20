using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht3ECsharp
{
    class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public event EventHandler<MenuItemEventArgs> ItemSelected;

        public void Select()
        {
            ItemSelected(this, new MenuItemEventArgs() { ItemId = Id });
        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
