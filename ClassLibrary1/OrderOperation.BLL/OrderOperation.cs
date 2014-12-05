using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPCApp.Data.Model;
using CPCApp.Data.DAL;
using CPCApp.Data.IDAL;

namespace MobileWebSite.BLL.OrderOperation.BLL
{
    public class GetDatabaseNum
    {
        public int orderID;
        public string orderNum;
        public string orderStatus;
        public string orderSupplier;
        public int category;
        public int partner;
    }
    public class GetOrderDetails
    {
        public int orderID;
        public string orderNum;
        public string orderSupplier;
        public int category;
        public string orderName;
        public string orderContent;
        public string orderTime;
    }
    public class GetChat
    {
        public string chatTime;
        public string charSender;
        public string chatContent;
        public string chatReceiver;
    }
    public class OrderSta
    {
        public string orderTime;
        public int status;
        public string statusContent;
    }
    public class OrderOperation : IOrderOperation
    {
        public string getStatus(int option)
        {
            switch (option)
            {
                case 0:
                    return "未完成";
                case 1:
                    return "未完成";
                case 2:
                    return "未完成";
                case 3:
                    return "未完成";
                case 4:
                    return "未完成";
                case 5:
                    return "未完成";
                case 6:
                    return "完成";
                default:
                    return null;
            }
        }
        //根据status content id 返回相应的状态内容
        public string getStatusContent(int option)
        {
            switch (option)
            {
                case 0:
                    return "合同未签订";
                case 1:
                    return "合同签订";
                case 2:
                    return "订单正在生产";
                case 3:
                    return "订单生产完成";
                case 4:
                    return "配送完成";
                case 5:
                    return "客户全部签收";
                case 6:
                    return "客户已评论";
                default:
                    return null;
            }
        }

        private OrderRepository orderRep = new OrderRepository();
        private EnterpriseRepository enterRep = new EnterpriseRepository();
        private OrderStatusRepository statusRep = new OrderStatusRepository();
        private DistributionRepository disRep = new DistributionRepository();
        private ChatRecordRepository chatRep = new ChatRecordRepository();
        // private GetDatabaseNum getdata = new GetDatabaseNum();


        //根据combox选项获取相应公司的各个状态的订单，option表示combox选取的值
        public List<GetDatabaseNum> GetOrderLists(int companyId, int category, int option)
        {
            // var orderlist = orderRep.LoadEntities((Order => Order.ProviderEnterprise_ID == companyId)).ToList();
            //   var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == companyId)).ToList();
            //0代表发布方，1代表承接方
            if (category == 0)
            {
                var orderlist = orderRep.LoadEntities((Order => Order.PublisherEnterprise_ID == companyId)).ToList();

                switch (option)
                {
                    case 0:
                        {
                            var templist = new List<GetDatabaseNum>();
                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.category = 1;
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus(orderStatContent);
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 1:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 6:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 3:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 2:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 4:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 5:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    default:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).ProviderEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                //因为登陆的是发布方显示的是承接方
                                getdata.category = 1;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                templist.Add(getdata);
                            }
                            return templist;
                        }
                }
            }
            else
            {
                //因为登陆的是承接方显示的是发布方
                var orderlist = orderRep.LoadEntities((Order => Order.ProviderEnterprise_ID == companyId)).ToList();
                switch (option)
                {
                    case 0:
                        {
                            var templist = new List<GetDatabaseNum>();
                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 0;
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus(orderStatContent);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 1:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 6:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 3:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 2:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 4:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    case 5:
                        {

                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                int orderStatContent = (int)statuslist[statusnum].OrderStatus_Content;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                if (orderStatContent == option)
                                {
                                    templist.Add(getdata);
                                }
                            }
                            return templist;
                        }
                    default:
                        {
                            var templist = new List<GetDatabaseNum>();

                            for (int i = 0; i < orderlist.Count; i++)
                            {

                                GetDatabaseNum getdata = new GetDatabaseNum();
                                getdata.orderID = orderlist.ElementAt(i).Order_ID;
                                getdata.partner = orderlist.ElementAt(i).PublisherEnterprise_ID; ;
                                var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == getdata.partner)).ToList();
                                getdata.category = 0;
                                var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == getdata.orderID)).ToList();
                                int statusnum = statuslist.Count - 1;
                                getdata.orderNum = orderlist.ElementAt(i).Order_Code;
                                getdata.orderStatus = getStatus((int)statuslist[statusnum].OrderStatus_Content);

                                getdata.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                                templist.Add(getdata);
                            }
                            return templist;
                        }
                }
            }

        }


        /// <summary>
        /// 获取订单的详细信息
        /// </summary>
        /// <param name="category"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<GetOrderDetails> GetOrderDetailByOrderId(int category, int orderId)
        {

            var orderlist = orderRep.LoadEntities((Orders => Orders.Order_ID == orderId)).ToList();
            var supplierid = 0;
            if (category == 0)
            {
                supplierid = orderlist.ElementAt(0).ProviderEnterprise_ID;
            }
            else
            {
                supplierid = orderlist.ElementAt(0).PublisherEnterprise_ID;
            }
            var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == supplierid)).ToList();
            if (category == 0)
            {
                var templist = new List<GetOrderDetails>();
                GetOrderDetails orderDetails = new GetOrderDetails();
                orderDetails.category = 0;
                orderDetails.orderID = orderlist.ElementAt(0).Order_ID;
                orderDetails.orderName = orderlist.ElementAt(0).Order_Name;
                orderDetails.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                orderDetails.orderTime = orderlist.ElementAt(0).Order_Time;
                orderDetails.orderNum = orderlist.ElementAt(0).Order_Code;
                orderDetails.orderContent = orderlist.ElementAt(0).Order_Content;
                templist.Add(orderDetails);
                return templist;
            }
            else
            {
                var templist = new List<GetOrderDetails>();
                GetOrderDetails orderDetails = new GetOrderDetails();
                orderDetails.category = 1;
                orderDetails.orderID = orderlist.ElementAt(0).Order_ID;
                orderDetails.orderName = orderlist.ElementAt(0).Order_Name;
                orderDetails.orderSupplier = enterlist.ElementAt(0).Enterprise_Name;
                orderDetails.orderTime = orderlist.ElementAt(0).Order_Time;
                orderDetails.orderNum = orderlist.ElementAt(0).Order_Code;
                orderDetails.orderContent = orderlist.ElementAt(0).Order_Content;
                templist.Add(orderDetails);
                return templist;
            }

        }
        public List<Order> SearchOrderLists(string keywords)
        {
            return null;
        }


        //获取订单的最近一项状态
        public OrderStatus.orderStatusType GetLatestStatus(int orderid)
        {
            var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == orderid)).ToList();
            int statusnum = statuslist.Count - 1;
            OrderStatus.orderStatusType orderStatContent = statuslist[statusnum].OrderStatus_Content;
            return orderStatContent;
        }

        //获取订单的下一个状态
        public string GetNextStatus(int orderid)
        {
            var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == orderid)).ToList();
            int statusnum = statuslist.Count;
            return getStatusContent(statusnum);
        }

        //获取订单的所有状态变化
        public List<OrderSta> GetOrderStatus(int orderid)
        {
            var orderlist = orderRep.LoadEntities((Orders => Orders.Order_ID == orderid)).ToList();
            var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == orderid)).ToList();
            var templist = new List<OrderSta>();
            for (int i = 0; i < statuslist.Count; i++)
            {
                OrderSta orderS = new OrderSta();
                orderS.orderTime = statuslist.ElementAt(i).OrderStatus_Time;
                orderS.status = (int)statuslist.ElementAt(i).OrderStatus_Content;
                orderS.statusContent = getStatusContent(orderS.status);
                templist.Add(orderS);
            }
            ////返回下一个状态
            //OrderSta orderStat = new OrderSta();
            //orderStat.orderTime = "0";
            //orderStat.status = 0;
            //orderStat.statusContent = GetNextStatus(orderid);
            //templist.Add(orderStat);

            return templist;
        }
        public List<OrderSta> GetOrderStatus2(int orderid)
        {
            var orderlist = orderRep.LoadEntities((Orders => Orders.Order_ID == orderid)).ToList();
            var statuslist = statusRep.LoadEntities((OrderStatus => OrderStatus.Order_ID == orderid)).ToList();
            var templist = new List<OrderSta>();
            for (int i = 0; i < statuslist.Count; i++)
            {
                OrderSta orderS = new OrderSta();
                orderS.orderTime = statuslist.ElementAt(i).OrderStatus_Time;
                orderS.status = (int)statuslist.ElementAt(i).OrderStatus_Content;
                orderS.statusContent = getStatusContent(orderS.status);
                templist.Add(orderS);
            }
            //返回下一个状态
            OrderSta orderStat = new OrderSta();
            orderStat.orderTime = "0";
            orderStat.status = 0;
            orderStat.statusContent = GetNextStatus(orderid);
            templist.Add(orderStat);

            return templist;
        }

        //获取某个公司的对话
        public List<GetChat> GetChartByCompanyId(int companyid)
        {
            var chatlist = chatRep.LoadEntities((ChatRecords => ChatRecords.SendEnterprise_ID == companyid)).ToList();
            var enterlist = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == companyid)).ToList();

            var templist = new List<GetChat>();
            for (int i = 0; i < chatlist.Count; i++)
            {
                GetChat chat = new GetChat();
                chat.charSender = enterlist.ElementAt(0).Enterprise_Name;
                chat.chatContent = chatlist.ElementAt(i).Chat_Content;
                chat.chatTime = chatlist.ElementAt(i).Chat_Time;
                int receiver = chatlist.ElementAt(i).ReceiveEnterprise_ID;
                var receivername = enterRep.LoadEntities((Enterprises => Enterprises.Enterprise_ID == receiver)).ToList();
                chat.chatReceiver = receivername.ElementAt(0).Enterprise_Name;
                templist.Add(chat);
            }
            return templist;
        }


        //获取公司订单数量信息 
        // category 0代表订单发布方 1代表承接方
        //option 0 代表未完成的订单 1代表已完成的订单
        public int GetOrderNum(int EnterpriseId, int category, int option)
        {
            if (category == 0)
            {
                int compelete = 0;
                int notcompelete = 0;
                try
                {
                    var tempOrderList = orderRep.LoadEntities(Order => Order.PublisherEnterprise_ID == EnterpriseId).ToList();
                    foreach (var tempOrder in tempOrderList)
                    {
                        var statuslist = statusRep.LoadEntities(OrderStatus => OrderStatus.Order_ID == tempOrder.Order_ID).ToList();

                        int lastStatus = (int)statuslist.LastOrDefault().OrderStatus_Content;
                        if (lastStatus == 6)
                        {
                            compelete++;
                        }
                        else
                        {
                            notcompelete++;
                        }
                    }
                    if (option == 0)
                    {
                        return notcompelete;
                    }
                    else
                    {
                        return compelete;
                    }
                }
                catch (System.Exception ex)
                {
                    return 0;
                }

            }
            else if (category == 1)
            {

                int compelete = 0;
                int notcompelete = 0;
                try
                {
                    var tempOrderList = orderRep.LoadEntities(Order => Order.ProviderEnterprise_ID == EnterpriseId).ToList();
                    foreach (var tempOrder in tempOrderList)
                    {
                        var statuslist = statusRep.LoadEntities(OrderStatus => OrderStatus.Order_ID == tempOrder.Order_ID).ToList();
                        int lastStatus = (int)statuslist.LastOrDefault().OrderStatus_Content;
                        if (lastStatus == 6)
                        {
                            compelete++;

                        }
                        else
                        {
                            notcompelete++;
                        }
                    }
                    if (option == 0)
                    {
                        return notcompelete;
                    }
                    else
                    {
                        return compelete;
                    }
                }
                catch (System.Exception ex)
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }
        }
    }
}

