using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SingleResponsibility.Models;

namespace SingleResponsibility.Business
{
    public class CustomerManager
    {
        public ResultModel Add(Customer customer)
        {
            ResultModel resultModel = new ResultModel();

            //Tc Kimlik Numarası Kontrol
            if (!TcNumberValidation.Validation(customer.IdentificationNumber))
            {
                resultModel.Message = "Tc Kimlik No Geçersiz!";
                resultModel.Success = false;
                return resultModel;
            }

            //Müşterinin önceden kayıdı var mı?
            if (!CheckIfCustomerExists(customer.IdentificationNumber))
            {
                resultModel.Message = "Müşteri Önceden Kayıt Edilmiş!";
                resultModel.Success = false;
                return resultModel;
            }

            //Veritabanı Kayıt İşlemleri.....
            resultModel.Message = "Müşteri Kayıt Başarılı!";
            resultModel.Success = true;

            return resultModel;
        }

      

        private bool CheckIfCustomerExists(string tcNumber)
        {
            bool result = false;
            //Müşterinin önceden kayıdı var mı?
            var findCustomer = fakeDB().FirstOrDefault(c => c.IdentificationNumber == tcNumber);

            if (findCustomer == null) return true;

            return result;
        }

        public List<Customer> fakeDB()
        {
            //Müşteriler
            List<Customer> customerList = new List<Customer>
            {
                new Customer{Id=1,IdentificationNumber="0000000000", FirstName = "Ayşe",LastName = "Yılmaz"},
                new Customer{Id=2,IdentificationNumber="1111111111", FirstName = "Fatma",LastName = "Kaya"},
                new Customer{Id=3,IdentificationNumber="2222222222", FirstName = "Hayriye",LastName = "Demir"},
                new Customer{Id=4,IdentificationNumber="", FirstName = "KAĞAN",LastName = "SAYGIN"},
            };
            return customerList;
        }

    }
}
