using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Folder : Component
    {
        private IList<Component> childs = new List<Component>();
        public IList<Component> Childs { get => childs; }
        public int ChildsAmount { get => childs.Count; }
        public override int Size 
        {
            get
            {
                int tempSize = 0;
                foreach (Component child in childs)
                    tempSize += child.Size;
                return tempSize;
            }
        }
        public override string Name { get; set; } = "New Folder";
        public override string Info(int spaces = 0)
        {
            StringBuilder strOut = new StringBuilder();
            string end = ".";
            if (childs.Count > 0)
                end = ":\n";
            strOut.Append(string.Format("Папка \"{0}\" размером {1} байт{2}",
                                        Name, Size, end));
            spaces += 2;
            StringBuilder builder = new StringBuilder();
            builder.Append(' ', spaces);
            for (int i = 0; i < ChildsAmount; i++)
            {
                string temp = "\n";
                if (i == ChildsAmount - 1)
                    temp = "";
                strOut.Append(string.Format("{2}{0}{3}", childs[i].Info(spaces), i + 1, builder.ToString(), temp));
            }
            return strOut.ToString();
        }
        public void Add(Component component)
        { 
            if (childs.Where(x => x.Name == component.Name).Any())
            {
                int i = 1;
                while (childs.Where(x => x.Name == component.Name + " " + i.ToString()).Any())
                    i++;
                component.Name = component.Name + " " + i.ToString();
            }
            childs.Add(component);
        }
        public void RemoveByName(string name)
        {
            if (childs.Where(x => x.Name == name).Any())
                childs.Remove(childs.Where(x => x.Name == name).First());
        }
    }
}
