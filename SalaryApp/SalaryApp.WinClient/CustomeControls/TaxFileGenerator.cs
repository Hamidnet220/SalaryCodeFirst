using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Windows.Forms;
using SalaryApp.DataLayer.Core.Domain;
using SalaryApp.DataLayer.Persistence;
using System.Linq;
using StructureMap.TypeRules;

namespace SalaryApp.WinClient.CustomeControls
{
    public class TaxFileGenerator<TEntity> where TEntity:class ,IPayDetails
    {
        private SalaryContext context;
        private DbSet<TEntity> dbSet;
        private Pay pay;
        public TaxFileGenerator(Pay pay)
        {
            this.pay = pay;
            this.context=new SalaryContext();
            this.dbSet = context.Set<TEntity>();
        }

        public void GenerateTaxFiles()
        {
            RetriveData();
        }

        private void RetriveData()
        {
            using (var context = new SalaryContext())
            {
                
                var salarylist =
                   dbSet.Where(sd => sd.PayId== pay.Id);
                var employees = new List<Employee>();
                foreach (var item in salarylist)
                    employees.Add(item.Employee);

                var personFileLines = new List<string>();
                foreach (var employee in employees)
                    personFileLines.Add(
                        $"1,1,{employee.Person.NationalCode},{employee.Person.Firstname},{employee.Person.Lastname},103,0,2,نگهبان,2,,{employee.Person.InsuranceId},,,13960801,1,{employee.Workplace.Title},2,1,,1,,");


                var path = GetFilePath("Persons.txt");
                if (path == null)
                    return;
                File.WriteAllLines(path, personFileLines);
            }
        }

        private string GetFilePath(string filename)
        {
            var browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.Cancel)
                return null;
            var taxDirectory = Directory.CreateDirectory(browserDialog.SelectedPath);
            var path = Path.Combine(taxDirectory.FullName, filename);

            return path;
        }
    }
}
