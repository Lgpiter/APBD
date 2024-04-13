using System;

namespace LegacyApp
{
    public class UserService
    {

        private Client _client;
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            //Data validation 
            if (!checUserEmail(email) | checkUserName(firstName, lastName) | !isOldEnough(dateOfBirth))
            {
                return false;
            }

            // Clinet Download
            _client = GetClient(clientId);
            if (_client == null)
            {
                return false;
            }

            var user = CreateUser(firstName, lastName, email, dateOfBirth, _client);
           

            //limit credit setting
            SetCreditLimit(user);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        
        public bool checkUserName(string firstName, string lastName)
        {
            return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
        }
        
        public bool checUserEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool isOldEnough(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age >= 21;
        }
        
        private Client GetClient(int clientId)
        {
            var clientRepository = new ClientRepository();
            return clientRepository.GetById(clientId);
        }
        
        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
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
            else
            {
                user.HasCreditLimit = true;
            }

            return user;
        }
        
        private void SetCreditLimit(User user)
        {
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (_client.Type.Equals("ImportantClient"))
                {
                    user.CreditLimit *= 2;
                }
                user.CreditLimit = creditLimit;
            }
        }

      
    }
}
