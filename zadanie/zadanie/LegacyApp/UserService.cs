using System;

namespace LegacyApp
{
    public class UserService
    { 
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;

        public UserService(IClientRepository clientRepository, ICreditLimitService creditLimitService)
        {
            _clientRepository = clientRepository;
            _creditLimitService = creditLimitService;
        }
        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!Valid.AllValid(firstName,lastName,email,dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                {
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                {
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
            
            _creditLimitService.Dispose();

            if (Valid.UserServiseValid(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
    public interface IClientRepository
    {
        Client GetById(int clientId);
    }

    public interface ICreditLimitService: IDisposable
    {
        int GetCreditLimit(string lastName, DateTime dateOfBirth);
    }
}
