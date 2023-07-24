using DataBase_LINQ;
using System;
using System.Collections;
using System.Linq;
using System.Net;

class Process
{
    static void Main()
    {
        /*using(var dbContext = new AdventureEntity())
        {
            var items = dbContext.Employees.Where(i=>i.MaritalStatus=="S").OrderBy(i=>i.LoginID).ThenBy(i=>i.BusinessEntityID);
            foreach(var item in items)
            {
                Console.WriteLine(item.LoginID+" "+item.Gender+" "+item.BusinessEntityID);
            }
            
        }*/

        /*using (var dbContext = new AdventureEntity())
        {
            var items = dbContext.Employees.Join(dbContext.EmployeeDepartmentHistories,
                e => e.BusinessEntityID,
                ed => ed.BusinessEntityID,
                (e,ed) => new
                {
                    LoginId = e.LoginID,
                    Jobtitle = e.JobTitle,
                    DepartmentId = ed.DepartmentID,
                    BusinessEntityId = e.BusinessEntityID
                }).Join(dbContext.Departments, e => e.DepartmentId, d => d.DepartmentID, (e, d) => new
                {
                    BusinessEntityId = e.BusinessEntityId,
                    LoginId = e.LoginId,
                    Jobtitle = e.Jobtitle,
                    DepartmentId = d.DepartmentID,
                    DepartmentName = d.Name
                }).Join(dbContext.EmployeePayHistories, e => e.BusinessEntityId, ep => ep.BusinessEntityID, (e, ep) => new
                {
                    bid = e.BusinessEntityId,
                    pay = ep.Rate
                }).Where(i => i.bid == 1);

            foreach (var item in items)
            {
                //Console.WriteLine(item.LoginId + "\t\t" + item.Jobtitle + "\t\t" + item.DepartmentId + "\t" + item.DepartmentName);
                Console.WriteLine(item.bid + "  " + item.pay);
            }

        }*/
        /*using (var dbContext = new AdventureEntity())
        {
            var items = dbContext.Employees.GroupJoin(dbContext.EmployeeDepartmentHistories,
                e => e.BusinessEntityID,
                ed => ed.BusinessEntityID,
                (e, ed) => new
                {
                    DepartmentHistory = ed,
                    JobTitle = e.JobTitle
                });
            foreach(var item in items)
            {
                Console.WriteLine(item.JobTitle);
                foreach(var item2 in item.DepartmentHistory)
                {
                    Console.WriteLine(item2.BusinessEntityID);
                }
            }
  
        }*/
        /*using (var dbContext = new AdventureEntity())
        {
            var items = dbContext.Employees.GroupBy(s => s.JobTitle);
            foreach (var item in items)
            {
                Console.WriteLine(item.Count());
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.LoginID);
                }
            }

        }*/


        /*using(var dbContext = new WorldEntities())
        {
            double avg = dbContext.People_Archive.Average(i=>i.PersonID);
            Console.WriteLine(avg);
            double sm = dbContext.People_Archive.Sum(i => i.PersonID);
            Console.WriteLine(sm);
            double mx = dbContext.People_Archive.Max(i => i.PersonID);
            Console.WriteLine(mx);
            double cnt = dbContext.People_Archive.Count(i => i.PersonID>=1);
            Console.WriteLine(cnt);

        }*/

        //Insert 
        /*using (var dbContext = new TestDBEntities())
        {
            UserDetail obj = new UserDetail();
            obj.FirstName = "Test";
            obj.LastName = "ing";
            dbContext.UserDetails.Add(obj);
            dbContext.SaveChanges();
        }*/
        /*//update
        using (var dbContext = new TestDBEntities())
        {
            var items = dbContext.UserDetails;
            foreach (var item in items)
            {
                item.LastName = "Changed";
            }
            
            dbContext.SaveChanges();
        }*/

        /*//delete
        using(var dbContext = new TestDBEntities())
        {
            UserDetail obj=new UserDetail();
            obj = dbContext.UserDetails.Single(e => e.UserID == 2);
            dbContext.UserDetails.Remove(obj);
            dbContext.SaveChanges();
        }*/

        //left outer join
        /*using (var dbContext = new WorldEntities())
        {
            var items = from c in dbContext.Customers
                        join p in dbContext.People_Archive on c.CustomerID equals p.PersonID into cp
                        from x in cp.DefaultIfEmpty()
                        select new
                        {
                            FullName = x == null ? "Empty" : x.FullName,
                            CustomerName = c.CustomerName
                        };

            foreach (var item in items)
            {
                Console.WriteLine(item.CustomerName+" "+item.FullName);
            }
        }
*/
        //stored procedure
        /*using(var dbContext = new TestDBEntities())
        {
            var items = dbContext.GetData();
            foreach(var item in items)
            {
                Console.WriteLine(item.FirstName);
            }
        }*/

        /*using (var dbContext = new TestDBEntities())
        {
            var items = dbContext.GetDetailsById(3);
            foreach (var item in items)
            {
                Console.WriteLine(item.FirstName);
            }
        }*/
        /*//view
        using (var dbContext = new TestDBEntities())
        {
            var items = dbContext.GetDetails;
            foreach (var item in items)
            {
                Console.WriteLine(item.FirstName);
            }
        }*/
        //subquery
        /*using (var dbContext = new TestDBEntities())
        {
            string x= dbContext.GetDetailsById(1).Select(j => j.FirstName).Single();
            var items = dbContext.UserDetails.Where(i =>dbContext.UserDetails.Where(r => r.UserID == 1).Select(j=>j.FirstName).ToList().Contains(i.FirstName));

            foreach (var item in items)
            {
                Console.WriteLine(item.FirstName);
            }
        }*/


        Console.ReadLine();
    }
}
