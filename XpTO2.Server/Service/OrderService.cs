using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XPTOApp.Core;
using XPTOApp.Model;
using XpTO.Server.Data;
using System.Data;
using XpTO2.Server.Service;

namespace XPTOApp.Service
{
    public class OrderService
    {
        Order _order = new Order();
        OrderType _type = new OrderType();

        public string GetOrderTypeToConfirm()
        {
            return _type.VerifyTypeOperation().ToString();
        }

        public BaseViewModel<List<OrderViewModel>> GetAllOrders()
        {

            var data = new Database();

            DataSet ret = data.getData();
            var orderList = _order.ParseDataSetToModel(ret);

            List<OrderViewModel> list = new List<OrderViewModel>();

            foreach (var item in orderList)
            {
                OrderViewModel model = new OrderViewModel();

                model.OrderID = item.Id;

                AccompanimentViewModel accompanimentFood = new AccompanimentViewModel();
                accompanimentFood.Description = item.AccompanimentFood.Description;
                accompanimentFood.Value = item.AccompanimentFood.Value;
                model.AccompanimentFood = accompanimentFood;

                DrinkViewModel drink = new DrinkViewModel();
                drink.Description = item.Drink.Description;
                drink.Value = item.Drink.Value;
                model.Drink = drink;

                MainFoodViewModel mainFood = new MainFoodViewModel();
                mainFood.Description = item.MainFood.Description;
                mainFood.Value = item.MainFood.Value;
                model.MainFood = mainFood;

                DessertViewModel dessert = new DessertViewModel();
                dessert.Description = item.Dessert.Description;
                dessert.Value = item.Dessert.Value;
                model.Dessert = dessert;

                model.TotalValue = item.TotalValue;
                model.CustomerName = item.CustomerName;
                model.CustomerMail = item.CustomerMail;
                model.StartDate = item.StatDate;
                model.ReceivedDate = item.ReceivedDate;
                model.FinishDate = item.FinishDate;
                model.Status = item.Status;
                list.Add(model);
            }

            return new BaseViewModel<List<OrderViewModel>>(true, "operação concluída", "sucesso", list);
        }

        public BaseViewModel<OrderViewModel> InsertOrder(OrderViewModel model)
        {
            var data = new Database();

            if (model.OrderType.ToString() == OrderType._OrderType.Invalid.ToString())
                return new BaseViewModel<OrderViewModel>(
                    false,
                     $"Não é possível inserir um pedido fora do horário padrão [08:00 - 10:00] ou [11:30 - 15:00]",
                    "Erro"
                );

            if (model == null)
                return new BaseViewModel<OrderViewModel>(
                    false, "Não é possível inserir um pedido sem itens", "Erro");


            BaseViewModel<OrderViewModel> typeOrderVerifyReturn = this.TypeOrderValidation(model);

            if (typeOrderVerifyReturn.Success)
            {

                try
                {

                    data.commandInsertOrder =
                        data.commandInsertOrder
                        //.Replace( "OrderId", "0")
                        .Replace("[CustomerName]", "'" + model.CustomerName + "'")
                        .Replace("[CustomerMail]", "'" + model.CustomerMail + "'")
                        .Replace("[DrinkName]", "'" + model.Drink.Description + "'")
                        .Replace("[DrinkValue]", model.Drink.Value.ToString())
                        .Replace("[MainFoodName]", "'" + model.MainFood.Description + "'")
                        .Replace("[MainFoodValue]", model.MainFood.Value.ToString())
                        .Replace("[DessertName]", "'" + model.Dessert.Description + "'")
                        .Replace("[DesserValue]", model.Dessert.Value.ToString())
                        .Replace("[AccompanimentFoodName]", "'" + model.AccompanimentFood.Description + "'")
                        .Replace("[AccompanimentFoodValue]", model.AccompanimentFood.Value.ToString())
                        .Replace("[StatusName]", "'" + model.Status + "'")
                        .Replace("[OrderType]", "'" + model.OrderType.ToString() + "'")
                        .Replace("[TotalValue]", model.TotalValue.ToString())
                        .Replace("[ReceivedDate]", "'" + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'")
                        .Replace("[StatDate]", "'" + null + "'")
                        .Replace("[FinishDate]", "'" + null + "'");

                    /*_order.AddOrderToList(
                      new Order(
                      _order.IncrementIdOrder(),
                      //1,
                      new Drink(model.Drink.Description, model.Drink.Value,
                          (OrderType._OrderType)model.Drink._OrderType
                      ),
                      new MainFood(model.MainFood.Description, model.MainFood.Value,
                          (OrderType._OrderType)model.MainFood._OrderType
                      ),
                      new AccompanimentFood(model.AccompanimentFood.Description, model.AccompanimentFood.Value,
                          (OrderType._OrderType)model.AccompanimentFood._OrderType
                      ),
                      new Dessert(model.Dessert.Description, model.Dessert.Value,
                          (OrderType._OrderType)model.Dessert._OrderType
                      ),              
                      model.Status, model.ReceivedDate,
                      model.StartDate, model.FinishDate,
                      model.CustomerName            
                      ));*/
                    data.setData();

                    Debug.WriteLine(typeOrderVerifyReturn);

                    return new BaseViewModel<OrderViewModel>(true, "Pedido inserido com sucesso", "Sucesso");
                }
                catch (System.Exception ex)
                {
                    return new BaseViewModel<OrderViewModel>(false, $"Erro - Detalhes : {ex.Message}", "Erro");
                }
            }
            else
            {

                Debug.WriteLine(typeOrderVerifyReturn);

                return new BaseViewModel<OrderViewModel>(false, typeOrderVerifyReturn.Message.Description, ""
                 );
            }

        }

        public BaseViewModel<OrderViewModel> TypeOrderValidation(OrderViewModel model)
        {
            /*
            if(model.OrderType.ToString() ==  OrderType._OrderType.Breakfast.ToString()){

              if(model.MainFood._OrderType.ToString() != OrderType._OrderType.Breakfast.ToString())
                    return new BaseViewModel<OrderViewModel>(false, $"{model.MainFood.Description} não é servido às {System.DateTime.Now}", "Erro");  

              if(model.AccompanimentFood._OrderType.ToString() != OrderType._OrderType.Breakfast.ToString())
                   return new BaseViewModel<OrderViewModel>(false, $"{model.AccompanimentFood.Description} não é servido às {System.DateTime.Now}", "Erro");  

               if(model.Dessert._OrderType.ToString() != OrderType._OrderType.Breakfast.ToString())
                   return new BaseViewModel<OrderViewModel>(false, $"{model.Dessert.Description} não é servido às {System.DateTime.Now}", "Erro");  

               if(model.Drink._OrderType.ToString() != OrderType._OrderType.Breakfast.ToString())
                    return new BaseViewModel<OrderViewModel>(false, $"{model.Dessert.Description} não é servido às {System.DateTime.Now}", "Erro");  
            }

           if(model.OrderType.ToString() ==  OrderType._OrderType.Lunch.ToString()){

               if(model.MainFood._OrderType.ToString() != OrderType._OrderType.Lunch.ToString())
                   return new BaseViewModel<OrderViewModel>(false, $"{model.MainFood.Description} não é servido às {System.DateTime.Now}", "Erro");  

               if(model.AccompanimentFood._OrderType.ToString() != OrderType._OrderType.Lunch.ToString())
                 return new BaseViewModel<OrderViewModel>(false, $"{model.AccompanimentFood.Description} não é servido às {System.DateTime.Now}", "Erro");  

               if(model.Dessert._OrderType.ToString() != OrderType._OrderType.Lunch.ToString())
                    return new BaseViewModel<OrderViewModel>(false, $"{model.Dessert.Description} não é servido às {System.DateTime.Now}", "Erro");  

                if(model.Drink._OrderType.ToString() != OrderType._OrderType.Lunch.ToString())
                   return new BaseViewModel<OrderViewModel>(false, $"{model.Dessert.Description} não é servido às {System.DateTime.Now}", "Erro");  
            }
            */
            var messages = "";

            DateTime now = System.DateTime.Now;

            DateTime breakfastStart = new DateTime(now.Year,now.Month, now.Day, int.Parse(_type.StartHoursBreakFast), 00, 00);
            DateTime breakfastEnd = new DateTime(now.Year, now.Month, now.Day, int.Parse(_type.EndHoursBreakfast), 00, 00);

            DateTime lunchStart = new DateTime(now.Year, now.Month, now.Day, int.Parse(_type.StartHoursLunch), 30, 00);
            DateTime lunchEnd = new DateTime(now.Year, now.Month, now.Day, int.Parse(_type.EndHoursLunch), 00, 00);

            var breakfastCondition = now > breakfastStart && now < breakfastEnd;
            var lunchCondition = now > lunchStart && now < lunchEnd;

            //BREAKFAST

            if (model.MainFood.Description.ToString() == "Bacon" && !breakfastCondition)
                messages += $"{model.MainFood.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.AccompanimentFood.Description.ToString() == "Torrada" && !breakfastCondition)
                messages += $"{model.AccompanimentFood.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.Dessert.Description.ToString() == "" && !breakfastCondition)
                messages += $"{model.Dessert.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.Drink.Description.ToString() == "Café" && !breakfastCondition)
                messages += $"{model.Drink.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            //LUNCH

            if (model.MainFood.Description.ToString() == "Bife" && !lunchCondition)
                messages += $"{model.MainFood.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.AccompanimentFood.Description.ToString() == "Salada" && !lunchCondition)
                messages += $"{model.AccompanimentFood.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.Dessert.Description.ToString() == "Bolo" && !lunchCondition)
                messages += $"{model.Dessert.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if (model.Drink.Description.ToString() == "Refrigerante" && !lunchCondition)
                messages += $"{model.Drink.Description} não é servido às {System.DateTime.Now.ToString("dd/MM/yyy HH:mm")} \n";

            if(messages == null)
            return new BaseViewModel<OrderViewModel>(true,"Pedido inserido com sucesso", "Sucesso");
            else
            return new BaseViewModel<OrderViewModel>(false, messages, "Erro");

        }

        public BaseViewModel<OrderViewModel> UpdateStatus (OrderViewModel order, int orderid)
        {
            MailService mail = new MailService();

            try
            {
                var data = new Database();
                data.commandUpdateOrder = data.commandUpdateOrder
                .Replace("#finishDate", "'" + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'" )
                .Replace("#ID", orderid.ToString());

                data.updateData();
                mail.SendEmail(order);

                return new BaseViewModel<OrderViewModel>(true);
            }
            catch (Exception)
            {
                return new BaseViewModel<OrderViewModel>(false);
                throw;                   
            }
        }
    }
}