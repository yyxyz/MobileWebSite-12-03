using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPCApp.Data.Model;
using MobileWebSite.BLL.OrderOperation.BLL;


namespace MobileWebSite.Controllers
{
    public class OrderDemoController : Controller
    {
        private CPCAppDataContext db = new CPCAppDataContext();
        private OrderOperation orderoper = new OrderOperation();

        //0代表发布方，1代表承接方
        // GET: /OrderDemo/
        // public  int category=0;
        public ActionResult Index()
        {

            return View();
        }
        //根据orderid来获取订单详情
        public ActionResult OrderDetails(int option, int category)
        {
            var tempList = orderoper.GetOrderDetailByOrderId(category, option);
            ViewBag.OrderNum = tempList[0].orderNum;
            ViewBag.OrderName = tempList[0].orderName;
            ViewBag.OrderSupplier = tempList[0].orderSupplier;
            ViewBag.OrderContent = tempList[0].orderContent;
            ViewBag.OrderTime = tempList[0].orderTime;

            ViewBag.Category = category;


            var tempListStatus = orderoper.GetOrderStatus(option);
            ViewBag.templist = tempListStatus;
            var NextStatus = orderoper.GetNextStatus(option);
            ViewBag.NextSta = NextStatus;

            return View();
        }

        //通过combox查找相应的订单
        public JsonResult GetOrderList(int option, int category, string content)
        {
            int enterpriseID = int.Parse(Session["userId"].ToString().Trim());   //获得当前session中的企业id
            List<GetDatabaseNum> tempList;
            if (content == "")
            {
                tempList = orderoper.GetOrderLists(enterpriseID, category, option);
            }
            else
            {
                tempList = orderoper.GetOrderBySearch(enterpriseID, option, category, content);
            }
            return Json(tempList, JsonRequestBehavior.AllowGet);
        }

        //通过搜索查找订单
        public JsonResult GetOrderBySearch(int option, int category, string content)
        {
            int enterpriseID = int.Parse(Session["userId"].ToString().Trim());


            List<GetDatabaseNum> tempList = orderoper.GetOrderBySearch(enterpriseID, category, option, content);
            return Json(tempList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult OrderDetailed(int option)
        {
            var tempList = orderoper.GetOrderDetailByOrderId(0, option);
            return Json(tempList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult OrderChat()
        {
            var tempList = orderoper.GetChartByCompanyId(10001);
            return Json(tempList, JsonRequestBehavior.AllowGet);
        }

        //OrderChat2加入了total统计数据个数，rows具体的条目
        public JsonResult OrderChat2()
        {
            var tempList = orderoper.GetChartByCompanyId(10001);
            var jsonResult = new { total = tempList.Count(), rows = tempList };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        //获取所有的Status
        public JsonResult OrderStatusChange(int option)
        {
            var tempListStatus = orderoper.GetOrderStatus2(option);
            //var nextStatus= orderoper.GetNextStatus(option);
            var jsonResult = new { total = tempListStatus.Count(), rows = tempListStatus };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }



        //改变订单的状态
        public JsonResult changeStatus(int option)
        {

            OrderStatus request = new OrderStatus();
            request.Order_ID = option;
            request.OrderStatus_Time = DateTime.Now.ToString("f");
            request.OrderStatus_Content = orderoper.GetLatestStatus(option) + 1;
            db.OrderStatus.Add(request);

            var tempList = new List<OrderStatus>();
            tempList.Add(request);
            int count = db.SaveChanges();
            if (count > 0)
            {
                //  this.ConvertFile(file,request.RequestDetectionID,uploadpath);
                return Json(tempList, JsonRequestBehavior.AllowGet); ;
            }

            return null;


        }
        public JsonResult AddChat(string comment)
        {
            ChatRecord request = new ChatRecord();
            request.Chat_Content = comment;
            request.ChatRecord_ID = 1;
            // request.Chat_Time = content[1];
            request.Chat_Time = DateTime.Now.ToString("f");
            request.ReceiveEnterprise_ID = 10002;
            request.Read = true;
            request.Receive_Enterprise_Del = false;
            request.Receive = null;
            request.Send = null;
            request.Send_Enterprise_Del = false;
            request.SendEnterprise_ID = 10001;

            var tempList = new List<ChatRecord>();
            tempList.Add(request);
            db.ChatRecords.Add(request);
            Console.WriteLine("dsaglsgjewhghewiohg");
            int count = db.SaveChanges();
            if (count > 0)
            {
                //  this.ConvertFile(file,request.RequestDetectionID,uploadpath);
                return Json(tempList, JsonRequestBehavior.AllowGet); ;
            }

            return null;
        }


    }
}
