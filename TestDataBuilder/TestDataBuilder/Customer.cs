namespace TestDataBuilder
{
    public class Customer
    {
        public Customer(string accountId, string firstName, string lastName, string address, string email)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
        }

        public string AccountId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Email { get; }

        public bool IsInvalidEmail()
        {
            return string.IsNullOrEmpty(Email);
        }
        
        public bool IsInvalidAccount()
        {
            return AccountId == null || AccountId.Length != 8;
        }

    }
}