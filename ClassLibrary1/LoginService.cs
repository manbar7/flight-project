using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LoginService : ILoginService
    {
        private DAOs.IAirlineDAO _airlineDAO;

        private DAOs.ICustomerDAO _customerDAO;




        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            if (userName == Administrator.Username && password == Administrator.Password)
            {
                token = new LoginToken<Administrator>();
                token.User = new Administrator();
                return true;
            }
            else
            {
                token = null;
                return false;
            }
        }

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {
            AirlineCompany airlineCompany = _airlineDAO.GetAirlineByUserame(userName);
            if (airlineCompany != null)
            {
                if ((userName == airlineCompany.USERNAME) && (password == airlineCompany.PASSWORD))
                {
                    token = new LoginToken<AirlineCompany>();
                    token.User = airlineCompany;
                    return true;
                }
                else
                {
                    throw new WrongPasswordException();

                }

            }
            else
            {
                token = null;
                return false;
            }

        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            Customer customer = _customerDAO.GetCustomerByUserame(userName);
            if (customer != null)
            {
                if ((userName == customer.USERNAME && (password == customer.PASSWORD))
                {
                    token = new LoginToken<Customer>();
                    token.User = customer;
                    return true;

                }
                else
                {
                    throw new WrongPasswordException();
                }

            }
            else
            {
                
                token = null;
                return false;
            }

        }
    }
}
