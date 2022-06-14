using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Classes;

namespace Lab2
{
    public class DataCreator
    {
        public void CreateSpecialities(List<Speciality> specs, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", filename), settings))
            {
                writer.WriteStartElement(filename);
                foreach (var spec in specs)
                {
                    writer.WriteStartElement("speciality");
                    writer.WriteElementString("number", spec.Number.ToString());
                    writer.WriteElementString("name", spec.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void CreateWorkers(List<Worker> workers, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", filename), settings))
            {
                writer.WriteStartElement(filename);
                foreach (var worker in workers)
                {
                    string fullname = string.Format("{0} {1} {2}", 
                                                    worker.Surname,
                                                    worker.Name,
                                                    worker.Patronymic);
                    writer.WriteStartElement("worker");
                    writer.WriteElementString("name", worker.Name);
                    writer.WriteElementString("surname", worker.Surname);
                    writer.WriteElementString("fullname", fullname);
                    writer.WriteElementString("patronymic", worker.Patronymic);
                    writer.WriteElementString("birthdate", worker.Birthdate.ToShortDateString());
                    writer.WriteElementString("personnelid", worker.PersonnelId.ToString());
                    writer.WriteElementString("cardnum", worker.Cardnum.ToString());
                    writer.WriteElementString("workstartdate", worker.WorkStartDate.ToShortDateString());
                    writer.WriteElementString("education", worker.Education.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void CreateSalary(List<SalaryByMonth> salaries, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", filename), settings))
            {
                writer.WriteStartElement(filename);
                foreach (var salary in salaries)
                {
                    writer.WriteStartElement("salarybymonth");
                    writer.WriteElementString("cardnum", salary.Cardnum.ToString());
                    writer.WriteElementString("month", salary.Month.ToString());
                    writer.WriteElementString("year", salary.Year.ToString());
                    writer.WriteElementString("salary", salary.Salary.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void CreateLinks(List<WorkerSpecLink> links, string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", filename), settings))
            {
                writer.WriteStartElement(filename);
                foreach (var link in links)
                {
                    writer.WriteStartElement("workerspeclink");
                    writer.WriteElementString("cardnum", link.Cardnum.ToString());
                    writer.WriteElementString("specnum", link.Specnum.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    }
}
