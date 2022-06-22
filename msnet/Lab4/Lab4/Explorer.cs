using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Explorer
    {
        private IList<Folder> hierarchy;
        public Folder Active
        {
            get
            {
                if (hierarchy.Count == 0)
                    return null;
                else
                    return hierarchy[hierarchy.Count - 1];
            }
        }
        public Explorer(Folder folder)
        { 
            hierarchy = new List<Folder>() { folder };
        }
        public string Open(string name)
        {
            List<Component> temp = Active.Childs.ToList();
            var query = temp.Where(x => x.Name == name);
            if (query.Any())
            {
                if (query.First() is Folder folder)
                    hierarchy.Add(folder);
                return query.First().Info();
            }
            return "";
        }
        public void Back()
        {
            if (hierarchy.Count > 0)
                hierarchy.RemoveAt(hierarchy.Count - 1);
        }
        public string Ls()
        {
            return Active.Info();
        }
        public void CreateFolder(string name)
        { 
            Folder folder = new Folder() { Name = name };
            Active.Add(folder);
        }
        public void CreateFile(string name, string extension)
        {
            File file = new File() { Name = name, Extension = extension };
            Active.Add(file);
        }
        public void Delete(string name)
        {
            Active.RemoveByName(name);
        }
    }
}
