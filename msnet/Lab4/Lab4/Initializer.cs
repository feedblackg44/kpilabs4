using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Initializer
    {
        public Folder CreateDefaultHierarchy()
        { 
            Folder root = new Folder() { Name = "Root" };
            Folder folder1 = new Folder() { Name = "Games" };
            folder1.Add(new File() { Name = "CSGO", Extension = "exe" });
            folder1.Add(new File() { Name = "TBoI", Extension = "exe" });
            folder1.Add(new File() { Name = "FNaF", Extension = "exe" });
            Folder folder2 = new Folder() { Name = "Work" };
            Folder folder3 = new Folder() { Name = "Study" };
            Folder net = new Folder() { Name = ".NET" };
            net.Add(new File() { Name = "Lab1", Extension = "docx" });
            net.Add(new File() { Name = "Lab2", Extension = "docx" });
            net.Add(new File() { Name = "Lab3", Extension = "docx" });
            Folder ipz = new Folder() { Name = "IPZ" };
            File rso = new File() { Name = "rso", Extension = "txt" };
            File music = new File() { Name = "StudyMusic", Extension = "mp3" };
            folder3.Add(net);
            folder3.Add(ipz);
            folder3.Add(music);
            folder3.Add(rso);
            root.Add(folder1);
            root.Add(folder2);
            root.Add(folder3);
            
            return root;
        }
    }
}
