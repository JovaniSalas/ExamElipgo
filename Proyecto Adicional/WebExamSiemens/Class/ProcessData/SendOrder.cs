using Business_Entities.Northwind;
using Business_Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.ProcessData
{
    public class SendOrder: ISendOrder
    {
        readonly INorthwind repNorthwind = new Northwind();
        public SendOrder()
        {

        }

        public BaseModel InsertDataOrder(OrderModel orderModel)
        {
            BaseModel baseModel = new BaseModel();
            try
            {
                baseModel.IsOk = repNorthwind.InsertOrder(orderModel);
            }
            catch (Exception er)
            {
                baseModel.ExistError = true;
                baseModel.Error = er.Message;
            }
            return baseModel;
        }

    }
}