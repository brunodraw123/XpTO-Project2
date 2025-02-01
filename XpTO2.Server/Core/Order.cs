using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOApp.Core
{
    public class Order
    {
        public Order(int id, Drink drink, MainFood mainFood, AccompanimentFood accompanimentFood,
        Dessert dessert, string status, DateTime receivedDate, DateTime startDate, DateTime finishDate, string customerName)
        {
            Id = id;
            Drink = drink;
            MainFood = mainFood;
            AccompanimentFood = accompanimentFood;
            Dessert = dessert;
            Status = status;
            ReceivedDate = System.DateTime.Now;
            StatDate = startDate;
            FinishDate = finishDate;
            CustomerName = customerName;
            TotalValue = mainFood.Value + accompanimentFood.Value + dessert.Value + drink.Value;
        }
        public Order()
        {

        }
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        private string _customerMail;
        public string CustomerMail
        {
            get { return _customerMail; }
            set { _customerMail = value; }
        }

        private Drink? _drink;

        public Drink? Drink
        {
            get { return _drink; }
            set { _drink = value; }
        }
        private MainFood? _mainFood;

        public MainFood? MainFood
        {
            get { return _mainFood; }
            set { _mainFood = value; }
        }
        private AccompanimentFood? _accompanimentFood;

        public AccompanimentFood? AccompanimentFood
        {
            get { return _accompanimentFood; }
            set { _accompanimentFood = value; }
        }
        private Dessert? _dessert;

        public Dessert? Dessert
        {
            get { return _dessert; }
            set { _dessert = value; }
        }
        private string? _status;

        public string? Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private DateTime _receivedDate;

        public DateTime ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }
        private DateTime _statDate;

        public DateTime StatDate
        {
            get { return _statDate; }
            set { _statDate = value; }
        }
        private DateTime _finishDate;

        public DateTime FinishDate
        {
            get { return _finishDate; }
            set { _finishDate = value; }
        }

        private string _orderType;
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private decimal _totalValue;
        public decimal TotalValue
        {
            get { return _totalValue; }
            set { _totalValue = value; }
        }

        public List<Order> orderList = new List<Order>();

        public int IncrementIdOrder()
        {
            if (orderList.Count == 0)
                return 0;

            return int.Parse(
                orderList.MaxBy(x => x.Id).Id
                .ToString()) + 1;
        }

        public void AddOrderToList(Order item)
        {
            orderList.Add(item);
        }

        public List<Order> ParseDataSetToModel(DataSet ds)
        {
            List<Order> list = new List<Order>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Order order = new Order();

                order.Id = int.Parse(row["OrderId"].ToString());

                order.Drink = new Drink(
                    row["DrinkName"].ToString(),
                    decimal.Parse(row["DrinkValue"].ToString()),
                    null);

                order.MainFood = new MainFood(
                    row["MainFoodName"].ToString(),
                    decimal.Parse(row["MainFoodValue"].ToString()),
                    null);

                order.Dessert = new Dessert(
                    row["DessertName"].ToString(),
                    decimal.Parse(row["DesserValue"].ToString()),
                    null);


                order.AccompanimentFood = new AccompanimentFood(
                    row["AccompanimentFoodName"].ToString(),
                    decimal.Parse(row["AccompanimentFoodValue"].ToString()), 
                    null);

                order.StatDate = DateTime.Parse(row["StatDate"].ToString());
                order.FinishDate = DateTime.Parse(row["FinishDate"].ToString());
                order.ReceivedDate = DateTime.Parse(row["ReceivedDate"].ToString());
                order.OrderType = row["OrderType"].ToString();
                order.TotalValue = decimal.Parse(row["TotalValue"].ToString());
                order.Status = row["StatusName"].ToString();
                order.CustomerName = row["CustomerName"].ToString();
                order.CustomerMail = row["CustomerMail"].ToString();

                list.Add(order);
            }

            return list;

        }
    }

}
