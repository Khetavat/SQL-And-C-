using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database3
{
    public class Class1
    {
        public static List<Vishal_Authentication> GetLogin()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var LoginList = db.Vishal_Authentication.ToList();
                return LoginList;

            }
        }

        public static void InsertIntoArea(string areaNameInput, int agentIdInput)
        {
            using(NorthwindEntities2 db = new NorthwindEntities2())
            {
                Vishal_Areas areas = new Vishal_Areas();
                areas.AreaName = areaNameInput;
                areas.AgentId = agentIdInput;

                db.Vishal_Areas.Add(areas);
                db.SaveChanges();
                
            }
        }

        public static void InsertIntoAgent(string firstNameInput, string lastNameInput,string username,string password)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_InsertIntoUsersReferenceWithAgent(2,firstNameInput,lastNameInput,username,password);
                db.SaveChanges();

            }
        }

        public static void InsertIntoPackage(int planCost,int customerId)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                Vishal_Plans plans = new Vishal_Plans();
                plans.PlanCost = planCost;
                plans.CustomerId = customerId;
                db.Vishal_Plans.Add(plans);
                db.SaveChanges();

            }
        }

        public static void InsertIntoCustomer(string firstNameInput, string lastNameInput,string dateOfBirth,string dateOfConnection,int planId,int areaId ,string username, string password)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_InsertIntoUsersReferenceWithCustomers(3,firstNameInput,lastNameInput,dateOfBirth,dateOfConnection,planId,areaId,username,password);
                db.SaveChanges();

            }
        }

        public static void RaiseComplaint(int? customerId,string description)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_RaiseComplaint(customerId,description);
                db.SaveChanges();

            }
        }

        public static void ResolveComplaint(int complaintId,string multipleExpenses,int agentId)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_CompanitMultipleExpense(complaintId, multipleExpenses, agentId);
                db.SaveChanges();

            }
        }

        public static void AddPayment(string year,int monthId, int customerIdInput, string statusInput, int? paymentMethodidInput)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_InsertIntoPayments(year, monthId, customerIdInput, statusInput, paymentMethodidInput);
                db.SaveChanges();

            }
        }

        public static List<Vishal_Plans> GetPlan()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_Plans.ToList();
                return List;

            }
        }

        public static List<Vishal_Areas> GetArea()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_Areas.ToList();
                return List;

            }
        }
        public static List<Vishal_AgentEfficiency_Result> GetAgentEfficiency()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_AgentEfficiency().ToList();
                return List;

            }
        }

        public static List<Vishal_TodayComplaint_Result> GetTodayComplaint()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_TodayComplaint().ToList();
                return List;

            }
        }

        public static void IsActive(string username,string password)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_IsActive(username, password);
                db.SaveChanges();

            }
        }

        public static void Logout(string username, string password)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                db.Vishal_Logout(username, password);
                db.SaveChanges();

            }
        }

        public static List<Vishal_CustomerProfitLossReport_Result> GetCustomerProfitLoss()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List =db.Vishal_CustomerProfitLossReport().ToList();
                return List;

            }
        }

        public static List<Vishal_PaymentPendingReportYearWise_Result> GetPaymentPendingReport(int? year,string customerId,string agentId)
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_PaymentPendingReportYearWise(year,customerId,agentId).ToList();
                return List;

            }
        }

        public static List<Vishal_Customers> GetCustomers()
        {
            using(NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_Customers.ToList();
                return List;
            }
        }

        public static List<Vishal_Agents> GetAgents()
        {
            using (NorthwindEntities2 db = new NorthwindEntities2())
            {
                var List = db.Vishal_Agents.ToList();
                return List;
            }
        }
    }
    
}
