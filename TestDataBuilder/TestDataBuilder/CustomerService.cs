using System;

namespace TestDataBuilder
{
    public class CustomerService
    {
        private EmailService _emailService;
        private ShippingService _shippingService;

        public CustomerService(EmailService emailService, ShippingService shippingService)
        {
            _emailService = emailService;
            _shippingService = shippingService;
        }
        
        public void SendEmail(Customer customer)
        {
            if (customer.IsInvalidEmail())
            {
                throw new CustomerServiceException();
            }
            string emailContent = _emailService.InitMail(customer.FirstName, customer.LastName);
            _emailService.Send(customer.Email, emailContent);
        }

        public void ShipOrder(Customer customer)
        {
            if (customer.IsInvalidAccount())
            {
                throw new CustomerServiceException();
            }
            string shipping = _shippingService.prepareOrder(customer.AccountId);
            _shippingService.ship(customer.Address, shipping);
        }

        public void ValidateEmail(Customer customer)
        {
            if (customer.IsInvalidEmail())
            {
                throw new CustomerServiceException();
            }
            string validationEmailContent = _emailService.InitValidationMail(customer.AccountId);
            _emailService.Send(customer.Email, validationEmailContent);
            
        }
    }

    public class CustomerServiceException : Exception
    {
    }

    public class ShippingService
    {
        public string prepareOrder(string customerAccountId)
        {
            throw new System.NotImplementedException();
        }

        public void ship(string customerAddress, string shipping)
        {
            throw new System.NotImplementedException();
        }
    }

    public class EmailService
    {
        public string InitMail(string customerFirstName, string customerLastName)
        {
            throw new System.NotImplementedException();
        }

        public void Send(string customerEmail, string emailContent)
        {
            throw new System.NotImplementedException();
        }

        public string InitValidationMail(string customerAccountId)
        {
            throw new System.NotImplementedException();
        }
    }
}