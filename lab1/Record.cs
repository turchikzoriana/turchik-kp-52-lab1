class Record
{
    public int CardNumber;
    public string LastName;
    public string FirstName;
    public string District;

    public Record(int cardNumber, string lastName, string firstName, string district)
    {
        CardNumber = cardNumber;
        LastName = lastName;
        FirstName = firstName;
        District = district;
    }

    public override string ToString()
    {
        return $"{CardNumber} | {LastName} {FirstName} | {District}";
    }
}